using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabs {
    [Serializable]
    class TabButton : Button {

        // This is just a regular button

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
