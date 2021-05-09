
namespace TravelAgencyView
{
    partial class FormRefillStoreHouse
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
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.comboBoxStoreHouse = new System.Windows.Forms.ComboBox();
			this.labelCount = new System.Windows.Forms.Label();
			this.labelStoreHouse = new System.Windows.Forms.Label();
			this.comboBoxComponent = new System.Windows.Forms.ComboBox();
			this.labelComponent = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(201, 119);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 19);
			this.buttonCancel.TabIndex = 23;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(126, 119);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(70, 19);
			this.buttonSave.TabIndex = 22;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(82, 88);
			this.textBoxCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.Size = new System.Drawing.Size(194, 20);
			this.textBoxCount.TabIndex = 20;
			// 
			// comboBoxStoreHouse
			// 
			this.comboBoxStoreHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStoreHouse.FormattingEnabled = true;
			this.comboBoxStoreHouse.Location = new System.Drawing.Point(82, 15);
			this.comboBoxStoreHouse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboBoxStoreHouse.Name = "comboBoxStoreHouse";
			this.comboBoxStoreHouse.Size = new System.Drawing.Size(194, 21);
			this.comboBoxStoreHouse.TabIndex = 19;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(9, 88);
			this.labelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(69, 13);
			this.labelCount.TabIndex = 17;
			this.labelCount.Text = "Количество:";
			// 
			// labelStoreHouse
			// 
			this.labelStoreHouse.AutoSize = true;
			this.labelStoreHouse.Location = new System.Drawing.Point(9, 15);
			this.labelStoreHouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStoreHouse.Name = "labelStoreHouse";
			this.labelStoreHouse.Size = new System.Drawing.Size(41, 13);
			this.labelStoreHouse.TabIndex = 16;
			this.labelStoreHouse.Text = "Склад:";
			// 
			// comboBoxComponent
			// 
			this.comboBoxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxComponent.FormattingEnabled = true;
			this.comboBoxComponent.Location = new System.Drawing.Point(82, 54);
			this.comboBoxComponent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboBoxComponent.Name = "comboBoxComponent";
			this.comboBoxComponent.Size = new System.Drawing.Size(194, 21);
			this.comboBoxComponent.TabIndex = 25;
			// 
			// labelComponent
			// 
			this.labelComponent.AutoSize = true;
			this.labelComponent.Location = new System.Drawing.Point(9, 54);
			this.labelComponent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelComponent.Name = "labelComponent";
			this.labelComponent.Size = new System.Drawing.Size(66, 13);
			this.labelComponent.TabIndex = 24;
			this.labelComponent.Text = "Компонент:";
			// 
			// FormRefillStoreHouse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 148);
			this.Controls.Add(this.comboBoxComponent);
			this.Controls.Add(this.labelComponent);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.comboBoxStoreHouse);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.labelStoreHouse);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormRefillStoreHouse";
			this.Text = "Пополнение склада";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxStoreHouse;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelStoreHouse;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.Label labelComponent;
    }
}