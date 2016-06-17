using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Tabs {
    [Serializable]
    public partial class Form1 : Form {
        private TabControl TabCtrl = new TabControl();

        public Form1() {
            InitializeComponent();
        }

        private void isSelected(object source, string key) {
            TabSelected.Text = key;
            Debug.WriteLine($"Event Fired for '{key}'");
        }
    }
}
