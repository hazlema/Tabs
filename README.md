# Tabs
![alt text](https://raw.githubusercontent.com/hazlema/Tabs/master/Tabs/Tabs.png "TabControl")

This control has full design time support!<br><br>
Properties:<br>
- public Color TabMouseDown = Color.FromArgb(255, 80, 80, 80); // Tab Color when Click
- public Color TabMouseOver = Color.FromArgb(255, 60, 60, 60); // Hover Color
- public Color TabForeground = Color.FromArgb(255, 255, 255, 255);  // Text Color
- public Padding TabPadding = new Padding(0);  // Change button looks
- public Color TabSeleced = Color.FromArgb(255, 60, 60, 60); // Background of selected tab (Sticky Backgrounds)
- public Font TabFont = new Font("Segoe UI", 10);  // Font
- public bool TabStickyBackgrounds = true; // Tab like -or- Menu like
- public string[] Tabs // Tab Names
- public string TabActive // Active Tab
- public Color TabLineColor // Line Color

Events:<br>
- public event TabControlSelectedHandler TabControlSelected;
<br><br><br>
Code Examples:<br>
- Activate a tab

                tabControl1.Select(Tab Name);
<br><br>
- Create tabs programmiticlly:

            // Selecting a tab will fire the event
            tabControl1.Add(new string[] {
                "Home",
                "Add",
                "Remove",
                "Twitter",
                "Facebook"
            }).Select("Home"); 

- Event, Create during design time or be a pro :-)

        private void TabControl1_TabControlSelected(object source, string key) {
            txtLabel.Text = key;

            if (key == "Remove") tabControl1.Remove("Remove").Select("Home");
            if (key == "Add")    tabControl1.Add("New");
        }
 
