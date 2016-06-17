namespace Tabs {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TabSelected = new System.Windows.Forms.Label();
            this.tabControl1 = new Tabs.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabSelected
            // 
            this.TabSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabSelected.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabSelected.ForeColor = System.Drawing.Color.White;
            this.TabSelected.Location = new System.Drawing.Point(0, 38);
            this.TabSelected.Name = "TabSelected";
            this.TabSelected.Size = new System.Drawing.Size(502, 103);
            this.TabSelected.TabIndex = 3;
            this.TabSelected.Text = "Empty";
            this.TabSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Windows.Forms.Padding(35);
            this.tabControl1.Size = new System.Drawing.Size(502, 38);
            this.tabControl1.TabActive = "1";
            this.tabControl1.TabFont = new System.Drawing.Font("Adobe Gothic Std B", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.TabForeground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(203)))), ((int)(((byte)(241)))));
            this.tabControl1.TabMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tabControl1.TabMouseOver = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tabControl1.TabPadding = new System.Windows.Forms.Padding(5);
            this.tabControl1.Tabs = new string[] {
        "Clock",
        "Alarms",
        "Timer",
        "Options",
        "Help"};
            this.tabControl1.TabSeleced = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tabControl1.TabStickyBackgrounds = true;
            this.tabControl1.TabStop = false;
            this.tabControl1.TabControlSelected += new Tabs.TabControl.TabControlSelectedHandler(this.isSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(502, 141);
            this.Controls.Add(this.TabSelected);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple Clock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private System.Windows.Forms.Label TabSelected;
    }
}

