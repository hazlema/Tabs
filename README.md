# Tabs
![alt text](https://raw.githubusercontent.com/hazlema/Tabs/master/Tabs/Tabs.png "TabControl")

Activate a tab<br>

                tabControl1.Select(Tab Name);

You can add tabs and such all in design time.  However, if you want to write code, below is how to create several tabs and select one as active.<br>

            // Selecting a tab will fire the event
            tabControl1.Add(new string[] {
                "Home",
                "Add",
                "Remove",
                "Twitter",
                "Facebook"
            }).Select("Home"); 
  
Event, Create during design time or be a pro :-)<br>

        private void TabControl1_TabControlClick(object source, string key) {
            txtLabel.Text = key;

            if (key == "Remove") tabControl1.Remove("Remove").Select("Home");
            if (key == "Add")    tabControl1.Add("New");
        }
 
