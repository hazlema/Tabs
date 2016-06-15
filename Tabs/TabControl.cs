using System.Windows.Forms;
using System.Drawing;

namespace Tabs {
    class TabControl : PictureBox {
        public delegate void TabControlClickHandler(object source, string key);
        public event TabControlClickHandler TabControlClick;

        public TabControl() {
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(255, 40, 40, 40);
            this.BorderStyle = BorderStyle.None;
            this.Paint += TabControl_Paint;
        }

        // Properties
        public Color LineColor     { get; set; } = Color.FromArgb(255, 120, 150, 240);
        public Color btnMouseDown  { get; set; } = Color.FromArgb(255, 80, 80, 80);
        public Color btnMouseOver  { get; set; } = Color.FromArgb(255, 60, 60, 60);
        public Color btnForeground { get; set; } = Color.FromArgb(255, 255, 255, 255);
        public Color btnSeleced    { get; set; } = Color.FromArgb(255, 60, 60, 60);
        public Font  btnFont       { get; set; } = new Font("Segoe UI", 10);
        public bool  useAsMenu     { get; set; } = false;

        private int savedHeight = 30;

        // Add a tab
        public void Add(TabButton btn) {
            btn.Click += Btn_TabClick;     // Add the event
            Controls.Add(btn);             // Add the button
            alignButtons();                // Line em' up
            setColors();                   // Enforce Colors

            if (savedHeight < btn.Height) savedHeight = btn.Height;
        }

        // Remove by name
        public void Remove(string key) {
            if (Controls.ContainsKey(key)) Controls.RemoveByKey(key);
            alignButtons();                // Line em' up
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

        // Add the stylish line
        private void TabControl_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(LineColor, 1), 
                new Rectangle(0, this.Height - 1, this.Width, this.Height));
        }

        // Colorize the buttons
        public void setColors() {
            foreach (TabButton t in Controls) {
                t.Font = btnFont;
                t.FlatAppearance.MouseDownBackColor = btnMouseDown;
                t.FlatAppearance.MouseOverBackColor = btnMouseOver;
                t.ForeColor = btnForeground;
                t.BackColor = Color.Transparent;
                t.Cursor = Cursors.Hand;
            }
        }

        // Set the active tab
        public void selectTab(string key) {
            if (Controls.ContainsKey(key)) {
                int index = Controls.IndexOfKey(key);
                selectTab((TabButton)Controls[index]);
            }
        }
        public void selectTab(TabButton tab) {
            setColors();

            tab.BackColor = btnSeleced;
            tab.FlatAppearance.MouseDownBackColor = btnSeleced;
            tab.FlatAppearance.MouseOverBackColor = btnSeleced;
            tab.Cursor = Cursors.Arrow;

            if (TabControlClick != null) TabControlClick(tab, tab.Name);
        }

        // Tab Clicked Event
        private void Btn_TabClick(object source, System.EventArgs args) {
            TabButton tab = (TabButton)source;

            if (!useAsMenu) {
                selectTab(tab);
            } else {
                if (TabControlClick != null) TabControlClick(tab, tab.Name);
            }
        }
    }
}