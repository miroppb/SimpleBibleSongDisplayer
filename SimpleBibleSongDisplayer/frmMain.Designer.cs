namespace SimpleBibleSongDisplayer
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.LstShow = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LblTotal = new System.Windows.Forms.Label();
            this.Nud = new System.Windows.Forms.NumericUpDown();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnGo = new System.Windows.Forms.Button();
            this.TxtFormat = new System.Windows.Forms.TextBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.DgvVerses = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSpeakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processxmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_CurrentSchedule = new System.Windows.Forms.ToolStripStatusLabel();
            this.LstSchedule = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVerses)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstShow
            // 
            this.LstShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstShow.FormattingEnabled = true;
            this.LstShow.Location = new System.Drawing.Point(0, 0);
            this.LstShow.Name = "LstShow";
            this.LstShow.Size = new System.Drawing.Size(238, 620);
            this.LstShow.TabIndex = 0;
            this.LstShow.SelectedIndexChanged += new System.EventHandler(this.LstShow_SelectedIndexChanged);
            this.LstShow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstShow_KeyPress);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LstShow);
            this.splitContainer1.Size = new System.Drawing.Size(1048, 620);
            this.splitContainer1.SplitterDistance = 806;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LblTotal);
            this.splitContainer2.Panel1.Controls.Add(this.Nud);
            this.splitContainer2.Panel1.Controls.Add(this.BtnDown);
            this.splitContainer2.Panel1.Controls.Add(this.BtnUp);
            this.splitContainer2.Panel1.Controls.Add(this.BtnGo);
            this.splitContainer2.Panel1.Controls.Add(this.TxtFormat);
            this.splitContainer2.Panel1.Controls.Add(this.TxtSearch);
            this.splitContainer2.Panel1.Controls.Add(this.DgvVerses);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer2.Panel2.Controls.Add(this.LstSchedule);
            this.splitContainer2.Size = new System.Drawing.Size(806, 620);
            this.splitContainer2.SplitterDistance = 495;
            this.splitContainer2.TabIndex = 0;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(608, 11);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(0, 13);
            this.LblTotal.TabIndex = 8;
            this.LblTotal.Click += new System.EventHandler(this.LblTotal_Click);
            // 
            // Nud
            // 
            this.Nud.Location = new System.Drawing.Point(611, 29);
            this.Nud.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Nud.Name = "Nud";
            this.Nud.Size = new System.Drawing.Size(41, 20);
            this.Nud.TabIndex = 7;
            this.Nud.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // BtnDown
            // 
            this.BtnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDown.Image = ((System.Drawing.Image)(resources.GetObject("BtnDown.Image")));
            this.BtnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDown.Location = new System.Drawing.Point(691, 27);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(33, 23);
            this.BtnDown.TabIndex = 6;
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUp.Image = ((System.Drawing.Image)(resources.GetObject("BtnUp.Image")));
            this.BtnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUp.Location = new System.Drawing.Point(657, 27);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(33, 23);
            this.BtnUp.TabIndex = 5;
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnGo
            // 
            this.BtnGo.Location = new System.Drawing.Point(728, 27);
            this.BtnGo.Name = "BtnGo";
            this.BtnGo.Size = new System.Drawing.Size(75, 23);
            this.BtnGo.TabIndex = 4;
            this.BtnGo.Text = "Show";
            this.BtnGo.UseVisualStyleBackColor = true;
            this.BtnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // TxtFormat
            // 
            this.TxtFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtFormat.Location = new System.Drawing.Point(371, 29);
            this.TxtFormat.Name = "TxtFormat";
            this.TxtFormat.Size = new System.Drawing.Size(234, 20);
            this.TxtFormat.TabIndex = 3;
            this.TxtFormat.Text = "book like \'%{0}%\'";
            // 
            // TxtSearch
            // 
            this.TxtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtSearch.Enabled = false;
            this.TxtSearch.Location = new System.Drawing.Point(12, 29);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(353, 20);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.TxtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // DgvVerses
            // 
            this.DgvVerses.AllowUserToAddRows = false;
            this.DgvVerses.AllowUserToDeleteRows = false;
            this.DgvVerses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvVerses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvVerses.Location = new System.Drawing.Point(3, 55);
            this.DgvVerses.MultiSelect = false;
            this.DgvVerses.Name = "DgvVerses";
            this.DgvVerses.ReadOnly = true;
            this.DgvVerses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvVerses.Size = new System.Drawing.Size(801, 438);
            this.DgvVerses.TabIndex = 1;
            this.DgvVerses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvVerses_CellContentDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newScheduleToolStripMenuItem,
            this.openScheduleToolStripMenuItem,
            this.saveScheduleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newScheduleToolStripMenuItem
            // 
            this.newScheduleToolStripMenuItem.Name = "newScheduleToolStripMenuItem";
            this.newScheduleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newScheduleToolStripMenuItem.Text = "New Schedule";
            this.newScheduleToolStripMenuItem.Click += new System.EventHandler(this.newScheduleToolStripMenuItem_Click);
            // 
            // openScheduleToolStripMenuItem
            // 
            this.openScheduleToolStripMenuItem.Name = "openScheduleToolStripMenuItem";
            this.openScheduleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openScheduleToolStripMenuItem.Text = "Open Schedule";
            this.openScheduleToolStripMenuItem.Click += new System.EventHandler(this.openScheduleToolStripMenuItem_Click);
            // 
            // saveScheduleToolStripMenuItem
            // 
            this.saveScheduleToolStripMenuItem.Name = "saveScheduleToolStripMenuItem";
            this.saveScheduleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveScheduleToolStripMenuItem.Text = "Save Schedule";
            this.saveScheduleToolStripMenuItem.Click += new System.EventHandler(this.saveScheduleToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSpeakerToolStripMenuItem,
            this.processtxtToolStripMenuItem,
            this.processxmlToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addSpeakerToolStripMenuItem
            // 
            this.addSpeakerToolStripMenuItem.Name = "addSpeakerToolStripMenuItem";
            this.addSpeakerToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addSpeakerToolStripMenuItem.Text = "&Add Speaker";
            this.addSpeakerToolStripMenuItem.Click += new System.EventHandler(this.addSpeakerToolStripMenuItem_Click);
            // 
            // processtxtToolStripMenuItem
            // 
            this.processtxtToolStripMenuItem.Name = "processtxtToolStripMenuItem";
            this.processtxtToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.processtxtToolStripMenuItem.Text = "Process .txt";
            this.processtxtToolStripMenuItem.Click += new System.EventHandler(this.processtxtToolStripMenuItem_Click);
            // 
            // processxmlToolStripMenuItem
            // 
            this.processxmlToolStripMenuItem.Name = "processxmlToolStripMenuItem";
            this.processxmlToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.processxmlToolStripMenuItem.Text = "Process .xml/db";
            this.processxmlToolStripMenuItem.Click += new System.EventHandler(this.processxmlToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_CurrentSchedule});
            this.statusStrip1.Location = new System.Drawing.Point(0, 99);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TS_CurrentSchedule
            // 
            this.TS_CurrentSchedule.Name = "TS_CurrentSchedule";
            this.TS_CurrentSchedule.Size = new System.Drawing.Size(101, 17);
            this.TS_CurrentSchedule.Text = "Current Schedule:";
            // 
            // LstSchedule
            // 
            this.LstSchedule.AllowDrop = true;
            this.LstSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstSchedule.FormattingEnabled = true;
            this.LstSchedule.Location = new System.Drawing.Point(0, 0);
            this.LstSchedule.Name = "LstSchedule";
            this.LstSchedule.Size = new System.Drawing.Size(806, 95);
            this.LstSchedule.TabIndex = 0;
            this.LstSchedule.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstSchedule_DragDrop);
            this.LstSchedule.DragOver += new System.Windows.Forms.DragEventHandler(this.LstSchedule_DragOver);
            this.LstSchedule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstSchedule_KeyDown);
            this.LstSchedule.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstSchedule_MouseDoubleClick);
            this.LstSchedule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LstSchedule_MouseDown);
            this.LstSchedule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstSchedule_MouseMove);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1048, 620);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Bible & Song Displayer";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvVerses)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TextBox TxtFormat;
        private System.Windows.Forms.Button BtnGo;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.NumericUpDown Nud;
        private System.Windows.Forms.ToolStripMenuItem openScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveScheduleToolStripMenuItem;
        private System.Windows.Forms.Label LblTotal;
        public System.Windows.Forms.ListBox LstShow;
        public System.Windows.Forms.ListBox LstSchedule;
        public System.Windows.Forms.DataGridView DgvVerses;
        public System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TS_CurrentSchedule;
        private System.Windows.Forms.ToolStripMenuItem newScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSpeakerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processxmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

