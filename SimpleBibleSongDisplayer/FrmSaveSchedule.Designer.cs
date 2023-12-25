namespace SimpleBibleSongDisplayer
{
	partial class FrmSaveSchedule
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
			this.BtnSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.CmbSchedules = new System.Windows.Forms.ComboBox();
			this.TxtName = new System.Windows.Forms.TextBox();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BtnSave
			// 
			this.BtnSave.Location = new System.Drawing.Point(136, 61);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 0;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name";
			// 
			// CmbSchedules
			// 
			this.CmbSchedules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbSchedules.FormattingEnabled = true;
			this.CmbSchedules.Location = new System.Drawing.Point(164, 15);
			this.CmbSchedules.Name = "CmbSchedules";
			this.CmbSchedules.Size = new System.Drawing.Size(168, 21);
			this.CmbSchedules.TabIndex = 3;
			// 
			// TxtName
			// 
			this.TxtName.Location = new System.Drawing.Point(53, 15);
			this.TxtName.Name = "TxtName";
			this.TxtName.Size = new System.Drawing.Size(100, 20);
			this.TxtName.TabIndex = 1;
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(217, 61);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 4;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// FrmSaveSchedule
			// 
			this.AcceptButton = this.BtnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(353, 97);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.CmbSchedules);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TxtName);
			this.Controls.Add(this.BtnSave);
			this.Name = "FrmSaveSchedule";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmSaveSchedule";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnCancel;
		public System.Windows.Forms.ComboBox CmbSchedules;
		public System.Windows.Forms.TextBox TxtName;
		public System.Windows.Forms.Button BtnSave;
	}
}