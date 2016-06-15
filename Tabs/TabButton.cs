using System.Windows.Forms;
using System.Drawing;

namespace Tabs {
    class TabButton : Button {

        public void init() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleCenter;
            AutoSize = true;
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
