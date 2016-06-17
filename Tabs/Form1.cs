using System.Diagnostics;
using System.Windows.Forms;

namespace Tabs {
    public partial class Form1 : Form {
        private TabControl TabCtrl = new TabControl();

        public Form1() {
            InitializeComponent();
        }

        private void isSelected(object source, string key) {
            TabSelected.Text = key;
            Debug.WriteLine($"Event Fired for '{key}'");
        }

        private void Form1_Load(object sender, System.EventArgs e) {

        }
    }
}
