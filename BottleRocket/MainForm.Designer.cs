namespace BottleRocket
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.btnApplyItemYML = new System.Windows.Forms.Button();
            this.btnCreateItemYML = new System.Windows.Forms.Button();
            this.tabTeleport = new System.Windows.Forms.TabPage();
            this.tabTrain = new System.Windows.Forms.TabPage();
            this.tabLevelUp = new System.Windows.Forms.TabPage();
            this.tabPSI = new System.Windows.Forms.TabPage();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabItems);
            this.tabControl1.Controls.Add(this.tabTeleport);
            this.tabControl1.Controls.Add(this.tabTrain);
            this.tabControl1.Controls.Add(this.tabLevelUp);
            this.tabControl1.Controls.Add(this.tabPSI);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 214);
            this.tabControl1.TabIndex = 0;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.btnApplyItemYML);
            this.tabItems.Controls.Add(this.btnCreateItemYML);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(498, 188);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // btnApplyItemYML
            // 
            this.btnApplyItemYML.Location = new System.Drawing.Point(7, 36);
            this.btnApplyItemYML.Name = "btnApplyItemYML";
            this.btnApplyItemYML.Size = new System.Drawing.Size(158, 23);
            this.btnApplyItemYML.TabIndex = 0;
            this.btnApplyItemYML.Text = "Import data to ROM";
            this.btnApplyItemYML.UseVisualStyleBackColor = true;
            // 
            // btnCreateItemYML
            // 
            this.btnCreateItemYML.Location = new System.Drawing.Point(7, 7);
            this.btnCreateItemYML.Name = "btnCreateItemYML";
            this.btnCreateItemYML.Size = new System.Drawing.Size(158, 23);
            this.btnCreateItemYML.TabIndex = 0;
            this.btnCreateItemYML.Text = "Export data from ROM";
            this.btnCreateItemYML.UseVisualStyleBackColor = true;
            // 
            // tabTeleport
            // 
            this.tabTeleport.Location = new System.Drawing.Point(4, 22);
            this.tabTeleport.Name = "tabTeleport";
            this.tabTeleport.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeleport.Size = new System.Drawing.Size(498, 188);
            this.tabTeleport.TabIndex = 1;
            this.tabTeleport.Text = "Teleport locations";
            this.tabTeleport.UseVisualStyleBackColor = true;
            // 
            // tabTrain
            // 
            this.tabTrain.Location = new System.Drawing.Point(4, 22);
            this.tabTrain.Name = "tabTrain";
            this.tabTrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrain.Size = new System.Drawing.Size(498, 188);
            this.tabTrain.TabIndex = 2;
            this.tabTrain.Text = "Train destinations";
            this.tabTrain.UseVisualStyleBackColor = true;
            // 
            // tabLevelUp
            // 
            this.tabLevelUp.Location = new System.Drawing.Point(4, 22);
            this.tabLevelUp.Name = "tabLevelUp";
            this.tabLevelUp.Size = new System.Drawing.Size(498, 188);
            this.tabLevelUp.TabIndex = 3;
            this.tabLevelUp.Text = "Character levelup table";
            this.tabLevelUp.UseVisualStyleBackColor = true;
            // 
            // tabPSI
            // 
            this.tabPSI.Location = new System.Drawing.Point(4, 22);
            this.tabPSI.Name = "tabPSI";
            this.tabPSI.Size = new System.Drawing.Size(498, 188);
            this.tabPSI.TabIndex = 4;
            this.tabPSI.Text = "PSI";
            this.tabPSI.UseVisualStyleBackColor = true;
            // 
            // tabScript
            // 
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(498, 188);
            this.tabScript.TabIndex = 5;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROM path:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "(Double-click to set)";
            this.label2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblFilepath_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 269);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "(No ROM loaded)";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabTeleport;
        private System.Windows.Forms.TabPage tabTrain;
        private System.Windows.Forms.TabPage tabLevelUp;
        private System.Windows.Forms.TabPage tabPSI;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.Button btnApplyItemYML;
        private System.Windows.Forms.Button btnCreateItemYML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

