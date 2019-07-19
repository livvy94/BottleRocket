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
            this.btnImportItemTOML = new System.Windows.Forms.Button();
            this.btnExportItemTOML = new System.Windows.Forms.Button();
            this.tabTeleport = new System.Windows.Forms.TabPage();
            this.btnImportTeleport = new System.Windows.Forms.Button();
            this.btnExportTeleport = new System.Windows.Forms.Button();
            this.tabTrain = new System.Windows.Forms.TabPage();
            this.tabLevelUp = new System.Windows.Forms.TabPage();
            this.tabPSI = new System.Windows.Forms.TabPage();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tabTileArrangements = new System.Windows.Forms.TabPage();
            this.btnImportEnding = new System.Windows.Forms.Button();
            this.btnImportTitleScreen = new System.Windows.Forms.Button();
            this.btnImportPresentedBy = new System.Windows.Forms.Button();
            this.btnImportProducedBy = new System.Windows.Forms.Button();
            this.btnExportEnding = new System.Windows.Forms.Button();
            this.btnExportTitleScreen = new System.Windows.Forms.Button();
            this.btnExportPresentedBy = new System.Windows.Forms.Button();
            this.btnExportProducedBy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabTeleport.SuspendLayout();
            this.tabTileArrangements.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabTileArrangements);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(506, 214);
            this.tabControl1.TabIndex = 0;
            //
            // tabItems
            //
            this.tabItems.Controls.Add(this.btnImportItemTOML);
            this.tabItems.Controls.Add(this.btnExportItemTOML);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(498, 188);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            //
            // btnImportItemTOML
            //
            this.btnImportItemTOML.Location = new System.Drawing.Point(7, 36);
            this.btnImportItemTOML.Name = "btnImportItemTOML";
            this.btnImportItemTOML.Size = new System.Drawing.Size(158, 23);
            this.btnImportItemTOML.TabIndex = 0;
            this.btnImportItemTOML.Text = "Import data to ROM";
            this.btnImportItemTOML.UseVisualStyleBackColor = true;
            this.btnImportItemTOML.Click += new System.EventHandler(this.btnImportItemTOML_Click);
            //
            // btnExportItemTOML
            //
            this.btnExportItemTOML.Location = new System.Drawing.Point(7, 7);
            this.btnExportItemTOML.Name = "btnExportItemTOML";
            this.btnExportItemTOML.Size = new System.Drawing.Size(158, 23);
            this.btnExportItemTOML.TabIndex = 0;
            this.btnExportItemTOML.Text = "Export data from ROM";
            this.btnExportItemTOML.UseVisualStyleBackColor = true;
            this.btnExportItemTOML.Click += new System.EventHandler(this.btnExportItemTOML_Click);
            //
            // tabTeleport
            //
            this.tabTeleport.Controls.Add(this.btnImportTeleport);
            this.tabTeleport.Controls.Add(this.btnExportTeleport);
            this.tabTeleport.Location = new System.Drawing.Point(4, 22);
            this.tabTeleport.Name = "tabTeleport";
            this.tabTeleport.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeleport.Size = new System.Drawing.Size(498, 188);
            this.tabTeleport.TabIndex = 1;
            this.tabTeleport.Text = "Teleport locations";
            this.tabTeleport.UseVisualStyleBackColor = true;
            //
            // btnImportTeleport
            //
            this.btnImportTeleport.Location = new System.Drawing.Point(6, 35);
            this.btnImportTeleport.Name = "btnImportTeleport";
            this.btnImportTeleport.Size = new System.Drawing.Size(158, 23);
            this.btnImportTeleport.TabIndex = 1;
            this.btnImportTeleport.Text = "Import data to ROM";
            this.btnImportTeleport.UseVisualStyleBackColor = true;
            this.btnImportTeleport.Click += new System.EventHandler(this.btnImportTeleport_Click);
            //
            // btnExportTeleport
            //
            this.btnExportTeleport.Location = new System.Drawing.Point(6, 6);
            this.btnExportTeleport.Name = "btnExportTeleport";
            this.btnExportTeleport.Size = new System.Drawing.Size(158, 23);
            this.btnExportTeleport.TabIndex = 2;
            this.btnExportTeleport.Text = "Export data from ROM";
            this.btnExportTeleport.UseVisualStyleBackColor = true;
            this.btnExportTeleport.Click += new System.EventHandler(this.btnExportTeleport_Click);
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
            this.tabLevelUp.Text = "Levelup table";
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
            // tabTileArrangements
            //
            this.tabTileArrangements.Controls.Add(this.btnImportEnding);
            this.tabTileArrangements.Controls.Add(this.btnImportTitleScreen);
            this.tabTileArrangements.Controls.Add(this.btnImportPresentedBy);
            this.tabTileArrangements.Controls.Add(this.btnImportProducedBy);
            this.tabTileArrangements.Controls.Add(this.btnExportEnding);
            this.tabTileArrangements.Controls.Add(this.btnExportTitleScreen);
            this.tabTileArrangements.Controls.Add(this.btnExportPresentedBy);
            this.tabTileArrangements.Controls.Add(this.btnExportProducedBy);
            this.tabTileArrangements.Controls.Add(this.label7);
            this.tabTileArrangements.Controls.Add(this.label5);
            this.tabTileArrangements.Controls.Add(this.label4);
            this.tabTileArrangements.Controls.Add(this.label6);
            this.tabTileArrangements.Controls.Add(this.label3);
            this.tabTileArrangements.Location = new System.Drawing.Point(4, 22);
            this.tabTileArrangements.Name = "tabTileArrangements";
            this.tabTileArrangements.Size = new System.Drawing.Size(498, 188);
            this.tabTileArrangements.TabIndex = 6;
            this.tabTileArrangements.Text = "Screens";
            this.tabTileArrangements.UseVisualStyleBackColor = true;
            //
            // btnImportEnding
            //
            this.btnImportEnding.Location = new System.Drawing.Point(249, 72);
            this.btnImportEnding.Name = "btnImportEnding";
            this.btnImportEnding.Size = new System.Drawing.Size(75, 23);
            this.btnImportEnding.TabIndex = 1;
            this.btnImportEnding.Text = "Import";
            this.btnImportEnding.UseVisualStyleBackColor = true;
            //
            // btnImportTitleScreen
            //
            this.btnImportTitleScreen.Location = new System.Drawing.Point(168, 72);
            this.btnImportTitleScreen.Name = "btnImportTitleScreen";
            this.btnImportTitleScreen.Size = new System.Drawing.Size(75, 23);
            this.btnImportTitleScreen.TabIndex = 1;
            this.btnImportTitleScreen.Text = "Import";
            this.btnImportTitleScreen.UseVisualStyleBackColor = true;
            //
            // btnImportPresentedBy
            //
            this.btnImportPresentedBy.Location = new System.Drawing.Point(87, 72);
            this.btnImportPresentedBy.Name = "btnImportPresentedBy";
            this.btnImportPresentedBy.Size = new System.Drawing.Size(75, 23);
            this.btnImportPresentedBy.TabIndex = 1;
            this.btnImportPresentedBy.Text = "Import";
            this.btnImportPresentedBy.UseVisualStyleBackColor = true;
            //
            // btnImportProducedBy
            //
            this.btnImportProducedBy.Location = new System.Drawing.Point(6, 72);
            this.btnImportProducedBy.Name = "btnImportProducedBy";
            this.btnImportProducedBy.Size = new System.Drawing.Size(75, 23);
            this.btnImportProducedBy.TabIndex = 1;
            this.btnImportProducedBy.Text = "Import";
            this.btnImportProducedBy.UseVisualStyleBackColor = true;
            //
            // btnExportEnding
            //
            this.btnExportEnding.Location = new System.Drawing.Point(249, 43);
            this.btnExportEnding.Name = "btnExportEnding";
            this.btnExportEnding.Size = new System.Drawing.Size(75, 23);
            this.btnExportEnding.TabIndex = 1;
            this.btnExportEnding.Text = "Export";
            this.btnExportEnding.UseVisualStyleBackColor = true;
            //
            // btnExportTitleScreen
            //
            this.btnExportTitleScreen.Location = new System.Drawing.Point(168, 43);
            this.btnExportTitleScreen.Name = "btnExportTitleScreen";
            this.btnExportTitleScreen.Size = new System.Drawing.Size(75, 23);
            this.btnExportTitleScreen.TabIndex = 1;
            this.btnExportTitleScreen.Text = "Export";
            this.btnExportTitleScreen.UseVisualStyleBackColor = true;
            //
            // btnExportPresentedBy
            //
            this.btnExportPresentedBy.Location = new System.Drawing.Point(87, 43);
            this.btnExportPresentedBy.Name = "btnExportPresentedBy";
            this.btnExportPresentedBy.Size = new System.Drawing.Size(75, 23);
            this.btnExportPresentedBy.TabIndex = 1;
            this.btnExportPresentedBy.Text = "Export";
            this.btnExportPresentedBy.UseVisualStyleBackColor = true;
            //
            // btnExportProducedBy
            //
            this.btnExportProducedBy.Location = new System.Drawing.Point(6, 43);
            this.btnExportProducedBy.Name = "btnExportProducedBy";
            this.btnExportProducedBy.Size = new System.Drawing.Size(75, 23);
            this.btnExportProducedBy.TabIndex = 1;
            this.btnExportProducedBy.Text = "Export";
            this.btnExportProducedBy.UseVisualStyleBackColor = true;
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ending";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Title Screen";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "presented by";
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(414, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "(Use your emulator\'s PPU viewer to see which hex values correspond with which til" +
    "es.)";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "produced by";
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl1.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabTeleport.ResumeLayout(false);
            this.tabTileArrangements.ResumeLayout(false);
            this.tabTileArrangements.PerformLayout();
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
        private System.Windows.Forms.Button btnImportItemTOML;
        private System.Windows.Forms.Button btnExportItemTOML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportTeleport;
        private System.Windows.Forms.Button btnExportTeleport;
        private System.Windows.Forms.TabPage tabTileArrangements;
        private System.Windows.Forms.Button btnImportEnding;
        private System.Windows.Forms.Button btnImportTitleScreen;
        private System.Windows.Forms.Button btnImportPresentedBy;
        private System.Windows.Forms.Button btnImportProducedBy;
        private System.Windows.Forms.Button btnExportEnding;
        private System.Windows.Forms.Button btnExportTitleScreen;
        private System.Windows.Forms.Button btnExportPresentedBy;
        private System.Windows.Forms.Button btnExportProducedBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}

