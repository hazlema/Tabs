using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Tabs {
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    class TabControl : PictureBox {
        public delegate void TabControlClickHandler(object source, string key);

        public TabControl() {
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(255, 40, 40, 40);
            this.BorderStyle = BorderStyle.None;
            this.Paint += TabControl_Paint;
            this.VisibleChanged += TabControl_VisibleChanged;
        }

        private int savedHeight = 30;

        // Design time support
        private string[] tabs;
        private Color linecolor = Color.FromArgb(255, 120, 150, 240);

        // Events
        [Browsable(true)]
        public event TabControlClickHandler TabControlClick;

        // Public Properties
        [Description("Tabs mouse down color"), Category("Tabs")]
        public Color btnMouseDown    { get; set; } = Color.FromArgb(255, 80, 80, 80);

        [Description("Tabs mouse over color"), Category("Tabs")]
        public Color btnMouseOver    { get; set; } = Color.FromArgb(255, 60, 60, 60);

        [Description("Tabs foreground color"), Category("Tabs")]
        public Color btnForeground   { get; set; } = Color.FromArgb(255, 255, 255, 255);

        [Description("Tabs selected background color"), Category("Tabs")]
        public Color btnSeleced      { get; set; } = Color.FromArgb(255, 60, 60, 60);

        [Description("Tabs Font"), Category("Tabs")]
        public Font  btnFont         { get; set; } = new Font("Segoe UI", 10);

        [Description("Tabs use as menu (sticky backgrounds)"), Category("Tabs")]
        public bool  useAsMenu       { get; set; } = false;

        [Description("Tabs Collection"), Category("Tabs")]
        public string[] Tabs {
            get { return tabs; }
            set {
                tabs = value;
                RenderTabs();
            }
        }

        private string activetab = "";
        [Description("Set the active tab. (0 for none, tab name or index number (1 and up)"), Category("Tabs")]
        public string activeTab {
            get {
                Select(this.activetab);
                return activetab; }
            set {
                activetab = value;
                Select(this.activetab);
            }
        }

        [Description("Tabs line color"), Category("Tabs")]
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
        public TabButton Select(string key) {
            int ndx = 0;
            bool isNum = int.TryParse(key, out ndx);

            if (key == "") {
                setColors();
            } else {
                if (isNum) {
                    if (ndx == 0) {
                        setColors();
                    } else {
                        if (ndx <= Controls.Count) {
                            return Select((TabButton)Controls[ndx - 1]); ;
                        } else {
                            if (Controls.ContainsKey(key)) {
                                int index = Controls.IndexOfKey(key);
                                return Select((TabButton)Controls[index]);
                            }
                        }
                    }
                }
            }

            return null;
        }

        // Select Tab
        public TabButton Select(TabButton tab) {
            setColors();

            tab.BackColor = btnSeleced;
            tab.FlatAppearance.MouseDownBackColor = btnSeleced;
            tab.FlatAppearance.MouseOverBackColor = btnSeleced;
            tab.Cursor = Cursors.Arrow;

            if (TabControlClick != null) TabControlClick(tab, tab.Name);
            return tab;
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

        // Design Time support
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

        // Fire Event when rendering control for real
        private void TabControl_VisibleChanged(object sender, EventArgs e) {
            Select(activeTab);
        }
    }
}
