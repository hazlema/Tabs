using System.Windows.Forms;
using System.Drawing;

namespace Tabs {
    class TabButton : Button {
        public TabButton(string tabName) {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            TextAlign = ContentAlignment.MiddleCenter;
            AutoSize = true;

            Name = tabName;
            Text = tabName;
        }
    }
}
