
namespace SimpleBibleSongDisplayer
{
    partial class FrmProcessXml
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
            this.BtnNext = new System.Windows.Forms.Button();
            this.TxtSong = new System.Windows.Forms.TextBox();
            this.BtnAddDb = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnRemSpac = new System.Windows.Forms.Button();
            this.CmbSongs = new System.Windows.Forms.ComboBox();
            this.TxtXML = new System.Windows.Forms.TextBox();
            this.BtnAddXML = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(251, 12);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 0;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // TxtSong
            // 
            this.TxtSong.Location = new System.Drawing.Point(12, 68);
            this.TxtSong.Multiline = true;
            this.TxtSong.Name = "TxtSong";
            this.TxtSong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtSong.Size = new System.Drawing.Size(314, 287);
            this.TxtSong.TabIndex = 1;
            // 
            // BtnAddDb
            // 
            this.BtnAddDb.Location = new System.Drawing.Point(332, 12);
            this.BtnAddDb.Name = "BtnAddDb";
            this.BtnAddDb.Size = new System.Drawing.Size(75, 23);
            this.BtnAddDb.TabIndex = 2;
            this.BtnAddDb.Text = "Add to db";
            this.BtnAddDb.UseVisualStyleBackColor = true;
            this.BtnAddDb.Click += new System.EventHandler(this.BtnAddDB_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.Location = new System.Drawing.Point(170, 12);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(75, 23);
            this.BtnPrev.TabIndex = 3;
            this.BtnPrev.Text = "Previous";
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnRemSpac
            // 
            this.BtnRemSpac.Location = new System.Drawing.Point(12, 12);
            this.BtnRemSpac.Name = "BtnRemSpac";
            this.BtnRemSpac.Size = new System.Drawing.Size(82, 23);
            this.BtnRemSpac.TabIndex = 4;
            this.BtnRemSpac.Text = "Rem Spaces";
            this.BtnRemSpac.UseVisualStyleBackColor = true;
            this.BtnRemSpac.Click += new System.EventHandler(this.BtnRemSpac_Click);
            // 
            // CmbSongs
            // 
            this.CmbSongs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbSongs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CmbSongs.FormattingEnabled = true;
            this.CmbSongs.Location = new System.Drawing.Point(12, 41);
            this.CmbSongs.Name = "CmbSongs";
            this.CmbSongs.Size = new System.Drawing.Size(557, 21);
            this.CmbSongs.TabIndex = 5;
            this.CmbSongs.SelectedIndexChanged += new System.EventHandler(this.CmbSongs_SelectedIndexChanged);
            // 
            // TxtXML
            // 
            this.TxtXML.Location = new System.Drawing.Point(332, 68);
            this.TxtXML.Multiline = true;
            this.TxtXML.Name = "TxtXML";
            this.TxtXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtXML.Size = new System.Drawing.Size(237, 287);
            this.TxtXML.TabIndex = 6;
            // 
            // BtnAddXML
            // 
            this.BtnAddXML.Location = new System.Drawing.Point(413, 12);
            this.BtnAddXML.Name = "BtnAddXML";
            this.BtnAddXML.Size = new System.Drawing.Size(75, 23);
            this.BtnAddXML.TabIndex = 7;
            this.BtnAddXML.Text = "Add to XML";
            this.BtnAddXML.UseVisualStyleBackColor = true;
            this.BtnAddXML.Click += new System.EventHandler(this.BtnAddXML_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(494, 12);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Save XML";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmProcessXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 369);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnAddXML);
            this.Controls.Add(this.TxtXML);
            this.Controls.Add(this.CmbSongs);
            this.Controls.Add(this.BtnRemSpac);
            this.Controls.Add(this.BtnPrev);
            this.Controls.Add(this.BtnAddDb);
            this.Controls.Add(this.TxtSong);
            this.Controls.Add(this.BtnNext);
            this.Name = "FrmProcessXml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtSong;
        private System.Windows.Forms.Button BtnRemSpac;
        private System.Windows.Forms.ComboBox CmbSongs;
        private System.Windows.Forms.TextBox TxtXML;
        public System.Windows.Forms.Button BtnNext;
        public System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnAddXML;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnAddDb;
    }
}