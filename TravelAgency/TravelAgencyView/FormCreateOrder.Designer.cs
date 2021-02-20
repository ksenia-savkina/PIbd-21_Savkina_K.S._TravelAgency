﻿namespace TravelAgencyView
{
	partial class FormCreateOrder
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxSum = new System.Windows.Forms.TextBox();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.comboBoxTravel = new System.Windows.Forms.ComboBox();
			this.labelSum = new System.Windows.Forms.Label();
			this.labelCount = new System.Windows.Forms.Label();
			this.labelTravel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(203, 114);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 19);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(128, 114);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(70, 19);
			this.buttonSave.TabIndex = 14;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxSum
			// 
			this.textBoxSum.Location = new System.Drawing.Point(85, 80);
			this.textBoxSum.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxSum.Name = "textBoxSum";
			this.textBoxSum.Size = new System.Drawing.Size(194, 20);
			this.textBoxSum.TabIndex = 13;
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(85, 45);
			this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(194, 20);
			this.textBoxCount.TabIndex = 12;
			this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
			// 
			// comboBoxTravel
			// 
			this.comboBoxTravel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTravel.FormattingEnabled = true;
			this.comboBoxTravel.Location = new System.Drawing.Point(85, 9);
			this.comboBoxTravel.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxTravel.Name = "comboBoxTravel";
			this.comboBoxTravel.Size = new System.Drawing.Size(194, 21);
			this.comboBoxTravel.TabIndex = 11;
			this.comboBoxTravel.SelectedIndexChanged += new System.EventHandler(this.comboBoxTravel_SelectedIndexChanged);
			// 
			// labelSum
			// 
			this.labelSum.AutoSize = true;
			this.labelSum.Location = new System.Drawing.Point(11, 80);
			this.labelSum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSum.Name = "labelSum";
			this.labelSum.Size = new System.Drawing.Size(44, 13);
			this.labelSum.TabIndex = 10;
			this.labelSum.Text = "Сумма:";
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(11, 45);
			this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(69, 13);
			this.labelCount.TabIndex = 9;
			this.labelCount.Text = "Количество:";
			// 
			// labelTravel
			// 
			this.labelTravel.AutoSize = true;
			this.labelTravel.Location = new System.Drawing.Point(11, 9);
			this.labelTravel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelTravel.Name = "labelTravel";
			this.labelTravel.Size = new System.Drawing.Size(52, 13);
			this.labelTravel.TabIndex = 8;
			this.labelTravel.Text = "Путёвка:";
			// 
			// FormCreateOrder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 155);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxSum);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.comboBoxTravel);
			this.Controls.Add(this.labelSum);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.labelTravel);
			this.Name = "FormCreateOrder";
			this.Text = "FormCreateOrder";
			this.Load += new System.EventHandler(this.FormCreateOrder_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxSum;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.ComboBox comboBoxTravel;
		private System.Windows.Forms.Label labelSum;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.Label labelTravel;
	}
}