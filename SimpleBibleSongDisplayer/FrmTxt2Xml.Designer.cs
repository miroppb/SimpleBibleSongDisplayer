namespace SimpleBibleSongDisplayer
{
    partial class FrmTxt2Xml
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
            this.LstIn = new System.Windows.Forms.ListBox();
            this.LstOut = new System.Windows.Forms.ListBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstIn
            // 
            this.LstIn.FormattingEnabled = true;
            this.LstIn.Location = new System.Drawing.Point(12, 12);
            this.LstIn.Name = "LstIn";
            this.LstIn.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LstIn.Size = new System.Drawing.Size(259, 420);
            this.LstIn.TabIndex = 0;
            this.LstIn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstIn_KeyUp);
            // 
            // LstOut
            // 
            this.LstOut.FormattingEnabled = true;
            this.LstOut.Location = new System.Drawing.Point(326, 12);
            this.LstOut.Name = "LstOut";
            this.LstOut.Size = new System.Drawing.Size(259, 420);
            this.LstOut.TabIndex = 1;
            this.LstOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstOut_KeyUp);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(277, 140);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(43, 43);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = ">>";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(277, 189);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(43, 43);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "<<";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(277, 238);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(43, 43);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmTxt2Xml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 450);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LstOut);
            this.Controls.Add(this.LstIn);
            this.Name = "FrmTxt2Xml";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Txt2Xml";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox LstOut;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnSave;
        public System.Windows.Forms.ListBox LstIn;
    }
}