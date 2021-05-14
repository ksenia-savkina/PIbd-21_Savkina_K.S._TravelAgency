
namespace TravelAgencyView
{
    partial class FormMails
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonPage1 = new System.Windows.Forms.Button();
            this.buttonPage2 = new System.Windows.Forms.Button();
            this.buttonPage4 = new System.Windows.Forms.Button();
            this.buttonPage3 = new System.Windows.Forms.Button();
            this.buttonPage5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView.Location = new System.Drawing.Point(2, 1);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(629, 420);
            this.dataGridView.TabIndex = 6;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(481, 426);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(136, 31);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.Text = "Следующая";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(2, 426);
            this.buttonPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(131, 30);
            this.buttonPrev.TabIndex = 16;
            this.buttonPrev.Text = "Предыдущая";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonPage1
            // 
            this.buttonPage1.Location = new System.Drawing.Point(159, 430);
            this.buttonPage1.Name = "buttonPage1";
            this.buttonPage1.Size = new System.Drawing.Size(39, 23);
            this.buttonPage1.TabIndex = 17;
            this.buttonPage1.UseVisualStyleBackColor = true;
            this.buttonPage1.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage2
            // 
            this.buttonPage2.Location = new System.Drawing.Point(216, 430);
            this.buttonPage2.Name = "buttonPage2";
            this.buttonPage2.Size = new System.Drawing.Size(39, 23);
            this.buttonPage2.TabIndex = 18;
            this.buttonPage2.UseVisualStyleBackColor = true;
            this.buttonPage2.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage4
            // 
            this.buttonPage4.Location = new System.Drawing.Point(334, 430);
            this.buttonPage4.Name = "buttonPage4";
            this.buttonPage4.Size = new System.Drawing.Size(39, 23);
            this.buttonPage4.TabIndex = 20;
            this.buttonPage4.UseVisualStyleBackColor = true;
            this.buttonPage4.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage3
            // 
            this.buttonPage3.Location = new System.Drawing.Point(276, 430);
            this.buttonPage3.Name = "buttonPage3";
            this.buttonPage3.Size = new System.Drawing.Size(39, 23);
            this.buttonPage3.TabIndex = 19;
            this.buttonPage3.UseVisualStyleBackColor = true;
            this.buttonPage3.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // buttonPage5
            // 
            this.buttonPage5.Location = new System.Drawing.Point(396, 430);
            this.buttonPage5.Name = "buttonPage5";
            this.buttonPage5.Size = new System.Drawing.Size(39, 23);
            this.buttonPage5.TabIndex = 21;
            this.buttonPage5.UseVisualStyleBackColor = true;
            this.buttonPage5.Click += new System.EventHandler(this.buttonPage_Click);
            // 
            // FormMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 460);
            this.Controls.Add(this.buttonPage5);
            this.Controls.Add(this.buttonPage4);
            this.Controls.Add(this.buttonPage3);
            this.Controls.Add(this.buttonPage2);
            this.Controls.Add(this.buttonPage1);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMails";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonPage1;
        private System.Windows.Forms.Button buttonPage2;
        private System.Windows.Forms.Button buttonPage4;
        private System.Windows.Forms.Button buttonPage3;
        private System.Windows.Forms.Button buttonPage5;
    }
}