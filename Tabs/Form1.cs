using System.Windows.Forms;

namespace Tabs {
    public partial class Form1 : Form {
        private TabControl TabCtrl = new TabControl();

        public Form1() {
            InitializeComponent();

            // Selecting a tab will fire the event
            tabControl1.Add(new string[] {
                "Home",
                "Add",
                "Remove",
                "Twitter",
                "Facebook"
            }).Select("Home"); 
        }

        private void TabControl1_TabControlClick(object source, string key) {
            txtLabel.Text = key;

            if (key == "Remove") tabControl1.Remove("Remove").Select("Home");
            if (key == "Add")    tabControl1.Add("New");
        }
    }
}
