using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Tabs {
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    class TabControl : PictureBox {
        public delegate void TabControlClickHandler(object source, string key);

        [Browsable(true)]
        public event TabControlClickHandler TabControlClick;

        public TabControl() {
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(255, 40, 40, 40);
            this.BorderStyle = BorderStyle.None;
            this.Paint += TabControl_Paint;
        }

        // Properties
        public Color btnMouseDown    { get; set; } = Color.FromArgb(255, 80, 80, 80);
        public Color btnMouseOver    { get; set; } = Color.FromArgb(255, 60, 60, 60);
        public Color btnForeground   { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public Color btnSeleced      { get; set; } = Color.FromArgb(255, 60, 60, 60);
        public Font  btnFont         { get; set; } = new Font("Segoe UI", 10);
        public bool  useAsMenu       { get; set; } = false;
        private int savedHeight = 30;

        // Had to for design time support
        private string[] tabs;
        public string[] Tabs {
            get { return tabs; }
            set { tabs = value;
                  RenderTabs();
            }
        }

        // Had to for design time support
        private Color linecolor = Color.FromArgb(255, 120, 150, 240);
        public Color LineColor {
            get { return linecolor; }
            set { linecolor = value;
                  Invalidate();
            }
        }

        // Add a tab
        public TabControl Add(string[] names) {
            foreach (string name in names) {
                Add(new TabButton(name));
            }

            return this;
        } 
        public TabControl Add(string name) {
            Add(new TabButton(name));

            return this;
        }
        public TabControl Add(string name, string key) {
            Add(new TabButton(name, key));

            return this;
        }
        public TabControl Add(TabButton btn) {
            btn.Click += Btn_TabClick;     // Add the event
            Controls.Add(btn);             // Add the button
            alignButtons();                // Line em' up
            setColors();                   // Enforce Colors

            if (savedHeight < btn.Height) savedHeight = btn.Height;

            return this;
        }

        // Remove by name
        public TabControl Remove(string key) {
            if (Controls.ContainsKey(key)) Controls.RemoveByKey(key);
            alignButtons();                // Line em' up
            return this;
        }

        // Set the active tab
        public void Select(string key) {
            if (Controls.ContainsKey(key)) {
                int index = Controls.IndexOfKey(key);
                Select((TabButton)Controls[index]);
            }
        }

        // Select Tab
        public void Select(TabButton tab) {
            setColors();

            tab.BackColor = btnSeleced;
            tab.FlatAppearance.MouseDownBackColor = btnSeleced;
            tab.FlatAppearance.MouseOverBackColor = btnSeleced;
            tab.Cursor = Cursors.Arrow;

            if (TabControlClick != null) TabControlClick(tab, tab.Name);
        }

        // Line up the buttons and make sure they are the same height
        private void alignButtons() {
            int lastPosition = 0;

            foreach (Control btn in Controls) {
                btn.Left = lastPosition;
                btn.Height = savedHeight;

                lastPosition += btn.Width;
            }
            this.Height = savedHeight + 1;
        }

        // Design Time workaround
        private void RenderTabs() {
            Controls.Clear();
            foreach (string tabs in Tabs) Add(tabs);
        }

        // Add the stylish line
        private void TabControl_Paint(object sender, PaintEventArgs e) {
                
            e.Graphics.DrawRectangle(new Pen(LineColor, 1), 
                new Rectangle(0, this.Height - 1, this.Width, this.Height));
        }

        // Colorize the buttons
        private void setColors() {
            foreach (TabButton t in Controls) {
                t.Font = btnFont;
                t.FlatAppearance.MouseDownBackColor = btnMouseDown;
                t.FlatAppearance.MouseOverBackColor = btnMouseOver;
                t.ForeColor = btnForeground;
                t.BackColor = Color.Transparent;
                t.Cursor = Cursors.Hand;
            }
        }

        // Tab Clicked Event
        private void Btn_TabClick(object source, System.EventArgs args) {
            TabButton tab = (TabButton)source;

            if (!useAsMenu) {
                Select(tab);
            } else {
                if (TabControlClick != null) TabControlClick(tab, tab.Name);
            }
        }
    }
}