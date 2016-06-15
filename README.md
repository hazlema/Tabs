# Tabs
![alt text](https://raw.githubusercontent.com/hazlema/Tabs/master/Tabs/Tabs.png "TabControl")

            // Selecting a tab will fire the event
            tabControl1.Add(new string[] {
                "Home",
                "Add",
                "Remove",
                "Twitter",
                "Facebook"
            }).Select("Home"); 
  
        private void TabControl1_TabControlClick(object source, string key) {
            txtLabel.Text = key;

            if (key == "Remove") tabControl1.Remove("Remove");
            if (key == "Add")    tabControl1.Add("New");
        }
  
  
