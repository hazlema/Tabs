using System.Windows.Forms;

namespace Tabs {
    public partial class Form1 : Form {
        private TabControl TabCtrl = new TabControl();

        public Form1() {
            InitializeComponent();

            tabControl1.TabControlClick += TabControl1_TabControlClick;

            tabControl1.Add(new TabButton("Home"));
            tabControl1.Add(new TabButton("Add"));
            tabControl1.Add(new TabButton("Remove"));
            tabControl1.Add(new TabButton("Twitter"));
            tabControl1.Add(new TabButton("FaceBook"));
            tabControl1.selectTab("Home"); // Selecting a tab will fire the event
        }

        private void TabControl1_TabControlClick(object source, string key) {
            txtLabel.Text = key;
            if (key == "Remove") tabControl1.Remove("Remove");
            if (key == "Add") tabControl1.Add(new TabButton("New"));
        }
    }
}
