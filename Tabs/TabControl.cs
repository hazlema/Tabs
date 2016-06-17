using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Tabs {
    class TabControl : PictureBox {
        public delegate void TabControlSelectedHandler(object source, string key);

        // Events
        [Browsable(true)]
        public event TabControlSelectedHandler TabControlSelected;

        // Public Properties
        [Description("Tabs mouse down color"), Category("Tabs")]
        public Color TabMouseDown { get; set; } = Color.FromArgb(255, 80, 80, 80);

        [Description("Tabs mouse over color"), Category("Tabs")]
        public Color TabMouseOver { get; set; } = Color.FromArgb(255, 60, 60, 60);

        [Description("Tabs foreground color"), Category("Tabs")]
        public Color TabForeground { get; set; } = Color.FromArgb(255, 255, 255, 255);

        private Padding btnpadding { get; set; } = new Padding(0);
        [Description("Tabs padding"), Category("Tabs")]
        public Padding TabPadding {
            get {
                return btnpadding;
            }
            set {
                btnpadding = value;
                updateAll();
            }
        }

        [Description("Tabs selected background color"), Category("Tabs")]
        public Color TabSeleced { get; set; } = Color.FromArgb(255, 60, 60, 60);

        public Font tabFont = new Font("Segoe UI", 10);
        [Description("Tabs Font"), Category("Tabs")]
        public Font TabFont {
            get {
                return tabFont;
            }
            set {
                tabFont = value;
                updateAll();
            }
        }

        private bool tabstickybackgrounds = true;
        [Description("Tabs remember selected (sticky backgrounds)"), Category("Tabs")]
        public bool TabStickyBackgrounds {
            get { return tabstickybackgrounds; }
            set { tabstickybackgrounds = value;
                  updateAll();
            }
        }

        private string[] tabs;
        [Description("Tabs Collection"), Category("Tabs")]
        public string[] Tabs {
            get { return tabs; }
            set {
                tabs = value;
                renderTabs();
                updateAll();
            }
        }

        private string activetab = "";
        [Description("Set the active tab. (0 for none, tab name or index number (1 and up)"), Category("Tabs")]
        public string TabActive {
            get {
                Select(this.activetab);
                return activetab; }
            set {
                activetab = value;
                updateAll();
            }
        }

        private Color linecolor = Color.FromArgb(255, 120, 150, 240);
        [Description("Tabs line color"), Category("Tabs")]
        public Color TabLineColor {
            get { return linecolor; }
            set { linecolor = value;
                updateAll();
                Invalidate();
            }
        }

        // Constructor
        public TabControl() {
            this.Dock = DockStyle.Top;
            this.BackColor = Color.FromArgb(255, 40, 40, 40);
            this.BorderStyle = BorderStyle.None;

            this.Paint += onPaint;
            this.VisibleChanged += onVisibleChanged;
            this.Resize += onResize;
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
            btn.Click += onClick;          // Add the event
            Controls.Add(btn);             // Add the button
            alignButtons();                // Line em' up
            setColors();                   // Enforce Colors

            return this;
        }

        // Remove by name
        public TabControl Remove(string key) {
            if (Controls.ContainsKey(key)) Controls.RemoveByKey(key);
            alignButtons();                // Line em' up
            return this;
        }

        // Update Everything
        private void updateAll() {
            setColors();
            alignButtons();
            Select(TabActive);
        }

        // Colorize the buttons
        private void setColors() {
            foreach (TabButton t in Controls) {
                t.Font = TabFont;
                t.Padding = TabPadding;
                t.FlatAppearance.MouseDownBackColor = TabMouseDown;
                t.FlatAppearance.MouseOverBackColor = TabMouseOver;
                t.ForeColor = TabForeground;
                t.BackColor = Color.Transparent;
                t.Cursor = Cursors.Hand;
            }
        }

        // Select Tab
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
                        }
                    }
                } else {
                    if (Controls.ContainsKey(key)) {
                        int index = Controls.IndexOfKey(key);
                        return Select((TabButton)Controls[index]);
                    }
                }
            }

            return null;
        }
        public TabButton Select(TabButton tab) {
            setColors();

            tab.BackColor = TabSeleced;
            tab.FlatAppearance.MouseDownBackColor = TabSeleced;
            tab.FlatAppearance.MouseOverBackColor = TabSeleced;
            tab.Cursor = Cursors.Arrow;

            return tab;
        }

        // Line up the buttons and make sure they are the same height
        private void alignButtons() {
            int lastleft = 0;
            int tallest = 0;

            // Populate with the changes
            foreach (Control btn in Controls) {
                btn.Padding = btnpadding;
                btn.AutoSize = false;
                btn.Height = 0;
                btn.AutoSize = true;
                if (tallest < btn.Height) tallest = btn.Height;
            }

            // Line them up
            foreach (Control btn in Controls) {
                btn.Left = lastleft;
                btn.Height = tallest;
                lastleft += btn.Width;

            }

            if (tallest == 0)
                Height = 30 + 2;
            else
                Height = tallest + 2;
        }

        // Design Time support
        private void renderTabs() {
            Controls.Clear();
            foreach (string tabs in Tabs) Add(tabs);
        }

        // Add the stylish line
        private void onPaint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(new Pen(TabLineColor, 1),
                new Rectangle(0, this.Height - 2, this.Width, this.Height));
        }

        // Tab Clicked Event
        private void onClick(object source, System.EventArgs args) {
            TabButton tab = (TabButton)source;

            if (TabStickyBackgrounds) Select(tab);
            if (tab != null && TabControlSelected != null) TabControlSelected(tab, tab.Name);
        }

        // Fire Event when rendering control for real
        private void onVisibleChanged(object sender, EventArgs e) {
            if (TabStickyBackgrounds) {
                TabButton t = Select(TabActive);
                if (t != null && TabControlSelected != null) TabControlSelected(t, t.Name);
            }
        }

        private void onResize(object sender, EventArgs e) {
            updateAll();
        }
    }
}
