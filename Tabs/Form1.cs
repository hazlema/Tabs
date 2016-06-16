using System;
using System.Windows.Forms;

namespace Tabs {
    [Serializable]
    public partial class Form1 : Form {
        private TabControl TabCtrl = new TabControl();

        public Form1() {
            InitializeComponent();
        }

        private void TabControl1_TabControlClick(object source, string key) {
            TabSelected.Text = key;
        }

        private void Clock_Tick(object sender, System.EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
            tabControl1.Select("Clock"); // Selecting a tab will fire the event
        }
    }
}
