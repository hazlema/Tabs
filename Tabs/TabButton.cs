using System.Windows.Forms;
using System.Drawing;

namespace Tabs {
    class TabButton : Button {
        public TabButton(string tabName) {
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10);
            TextAlign = ContentAlignment.MiddleCenter;
            AutoSize = true;

            Name = tabName;
            Text = tabName;
        }
    }
}
