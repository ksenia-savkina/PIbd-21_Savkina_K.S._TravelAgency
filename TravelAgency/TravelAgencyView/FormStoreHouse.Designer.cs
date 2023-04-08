
namespace TravelAgencyView
{
    partial class FormStoreHouse
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
			this.textBoxResponsiblePersonFullName = new System.Windows.Forms.TextBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelResponsiblePersonFullName = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBoxComponents = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.groupBoxComponents.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxResponsiblePersonFullName
			// 
			this.textBoxResponsiblePersonFullName.Location = new System.Drawing.Point(128, 50);
			this.textBoxResponsiblePersonFullName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBoxResponsiblePersonFullName.Name = "textBoxResponsiblePersonFullName";
			this.textBoxResponsiblePersonFullName.Size = new System.Drawing.Size(180, 20);
			this.textBoxResponsiblePersonFullName.TabIndex = 14;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(128, 16);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(180, 20);
			this.textBoxName.TabIndex = 13;
			// 
			// labelResponsiblePersonFullName
			// 
			this.labelResponsiblePersonFullName.AutoSize = true;
			this.labelResponsiblePersonFullName.Location = new System.Drawing.Point(9, 54);
			this.labelResponsiblePersonFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelResponsiblePersonFullName.Name = "labelResponsiblePersonFullName";
			this.labelResponsiblePersonFullName.Size = new System.Drawing.Size(120, 13);
			this.labelResponsiblePersonFullName.TabIndex = 12;
			this.labelResponsiblePersonFullName.Text = "ФИО ответственного:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(9, 19);
			this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(60, 13);
			this.labelName.TabIndex = 11;
			this.labelName.Text = "Название:";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnComponent,
            this.ColumnCount});
			this.dataGridView.Location = new System.Drawing.Point(4, 16);
			this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowHeadersWidth = 51;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(255, 205);
			this.dataGridView.TabIndex = 15;
			// 
			// ColumnId
			// 
			this.ColumnId.HeaderText = "ID";
			this.ColumnId.MinimumWidth = 6;
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.ReadOnly = true;
			this.ColumnId.Visible = false;
			this.ColumnId.Width = 125;
			// 
			// ColumnComponent
			// 
			this.ColumnComponent.HeaderText = "Компонент";
			this.ColumnComponent.MinimumWidth = 6;
			this.ColumnComponent.Name = "ColumnComponent";
			this.ColumnComponent.ReadOnly = true;
			this.ColumnComponent.Width = 125;
			// 
			// ColumnCount
			// 
			this.ColumnCount.HeaderText = "Количество";
			this.ColumnCount.MinimumWidth = 6;
			this.ColumnCount.Name = "ColumnCount";
			this.ColumnCount.ReadOnly = true;
			this.ColumnCount.Width = 125;
			// 
			// groupBoxComponents
			// 
			this.groupBoxComponents.Controls.Add(this.dataGridView);
			this.groupBoxComponents.Location = new System.Drawing.Point(11, 93);
			this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxComponents.Name = "groupBoxComponents";
			this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxComponents.Size = new System.Drawing.Size(323, 231);
			this.groupBoxComponents.TabIndex = 16;
			this.groupBoxComponents.TabStop = false;
			this.groupBoxComponents.Text = "Компоненты";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(254, 332);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 24);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(164, 332);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 24);
			this.buttonSave.TabIndex = 16;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// FormStoreHouse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(348, 366);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupBoxComponents);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxResponsiblePersonFullName);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelResponsiblePersonFullName);
			this.Controls.Add(this.labelName);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormStoreHouse";
			this.Text = "Склад";
			this.Load += new System.EventHandler(this.FormStoreHouse_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.groupBoxComponents.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResponsiblePersonFullName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelResponsiblePersonFullName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}