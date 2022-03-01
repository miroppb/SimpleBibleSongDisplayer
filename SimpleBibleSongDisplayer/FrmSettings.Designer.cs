namespace SimpleBibleSongDisplayer
{
    partial class FrmSettings
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
            this.ChkXML = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtXML = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOverlay = new System.Windows.Forms.TextBox();
            this.ChkUseOverlay = new System.Windows.Forms.CheckBox();
            this.ChkAOT = new System.Windows.Forms.CheckBox();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkSecond = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkXML
            // 
            this.ChkXML.AutoSize = true;
            this.ChkXML.Checked = true;
            this.ChkXML.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkXML.Location = new System.Drawing.Point(12, 12);
            this.ChkXML.Name = "ChkXML";
            this.ChkXML.Size = new System.Drawing.Size(48, 17);
            this.ChkXML.TabIndex = 0;
            this.ChkXML.Text = "XML";
            this.ChkXML.UseVisualStyleBackColor = true;
            this.ChkXML.CheckedChanged += new System.EventHandler(this.ChkXML_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtXML);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML";
            // 
            // TxtXML
            // 
            this.TxtXML.Location = new System.Drawing.Point(6, 19);
            this.TxtXML.Name = "TxtXML";
            this.TxtXML.Size = new System.Drawing.Size(350, 20);
            this.TxtXML.TabIndex = 2;
            this.TxtXML.Click += new System.EventHandler(this.TxtXML_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(153, 277);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOverlay);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 54);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Overlay";
            // 
            // txtOverlay
            // 
            this.txtOverlay.Location = new System.Drawing.Point(6, 19);
            this.txtOverlay.Name = "txtOverlay";
            this.txtOverlay.Size = new System.Drawing.Size(350, 20);
            this.txtOverlay.TabIndex = 2;
            this.txtOverlay.Click += new System.EventHandler(this.txtImage_Click);
            // 
            // ChkUseOverlay
            // 
            this.ChkUseOverlay.AutoSize = true;
            this.ChkUseOverlay.Checked = true;
            this.ChkUseOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkUseOverlay.Location = new System.Drawing.Point(12, 91);
            this.ChkUseOverlay.Name = "ChkUseOverlay";
            this.ChkUseOverlay.Size = new System.Drawing.Size(62, 17);
            this.ChkUseOverlay.TabIndex = 3;
            this.ChkUseOverlay.Text = "Overlay";
            this.ChkUseOverlay.UseVisualStyleBackColor = true;
            this.ChkUseOverlay.CheckedChanged += new System.EventHandler(this.ChkUseImage_CheckedChanged);
            // 
            // ChkAOT
            // 
            this.ChkAOT.AutoSize = true;
            this.ChkAOT.Checked = true;
            this.ChkAOT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAOT.Location = new System.Drawing.Point(12, 174);
            this.ChkAOT.Name = "ChkAOT";
            this.ChkAOT.Size = new System.Drawing.Size(96, 17);
            this.ChkAOT.TabIndex = 5;
            this.ChkAOT.Text = "Always on Top";
            this.ChkAOT.UseVisualStyleBackColor = true;
            this.ChkAOT.CheckedChanged += new System.EventHandler(this.ChkAOT_CheckedChanged);
            // 
            // txtFont
            // 
            this.txtFont.Location = new System.Drawing.Point(52, 210);
            this.txtFont.Name = "txtFont";
            this.txtFont.Size = new System.Drawing.Size(322, 20);
            this.txtFont.TabIndex = 6;
            this.txtFont.Click += new System.EventHandler(this.txtFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Font:";
            // 
            // ChkSecond
            // 
            this.ChkSecond.AutoSize = true;
            this.ChkSecond.Location = new System.Drawing.Point(12, 248);
            this.ChkSecond.Name = "ChkSecond";
            this.ChkSecond.Size = new System.Drawing.Size(107, 17);
            this.ChkSecond.TabIndex = 8;
            this.ChkSecond.Text = "Second Monitor?";
            this.ChkSecond.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 312);
            this.ControlBox = false;
            this.Controls.Add(this.ChkSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFont);
            this.Controls.Add(this.ChkAOT);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ChkUseOverlay);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChkXML);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnClose;
        public System.Windows.Forms.CheckBox ChkXML;
        public System.Windows.Forms.TextBox TxtXML;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtOverlay;
        public System.Windows.Forms.CheckBox ChkUseOverlay;
        public System.Windows.Forms.CheckBox ChkAOT;
        public System.Windows.Forms.TextBox txtFont;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox ChkSecond;
    }
}