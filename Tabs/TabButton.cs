using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabs {
    class TabButton : Button {

        // This is just a regular button
        // And we set some of its properties
        // so we can create a bunch of buttons and 
        // avoid having to set each one.

        public void init() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleCenter;
            AutoSize = true;
        }

        public TabButton() {
            init();
        }

        public TabButton(string tabTitle) {
            init();
            Name = tabTitle;
            Text = tabTitle;
        }

        public TabButton(string tabTitle, string tabKey) {
            init();
            Name = tabTitle;
            Text = tabKey;
        }
    }
}
