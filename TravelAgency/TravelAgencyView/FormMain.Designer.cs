namespace TravelAgencyView
{
	partial class FormMain
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
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.туристическиеПутёвкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПутёвокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.путёвкиПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыПоКомпонентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовЗаВесьПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(909, 415);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(188, 30);
            this.buttonRef.TabIndex = 13;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(909, 338);
            this.buttonPayOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(188, 30);
            this.buttonPayOrder.TabIndex = 12;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(909, 257);
            this.buttonOrderReady.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(188, 30);
            this.buttonOrderReady.TabIndex = 11;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(909, 185);
            this.buttonTakeOrderInWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(188, 30);
            this.buttonTakeOrderInWork.TabIndex = 10;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(909, 114);
            this.buttonCreateOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(188, 30);
            this.buttonCreateOrder.TabIndex = 9;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 32);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(881, 508);
            this.dataGridView.TabIndex = 8;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.пополнениеСкладаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1112, 28);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.туристическиеПутёвкиToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // туристическиеПутёвкиToolStripMenuItem
            // 
            this.туристическиеПутёвкиToolStripMenuItem.Name = "туристическиеПутёвкиToolStripMenuItem";
            this.туристическиеПутёвкиToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.туристическиеПутёвкиToolStripMenuItem.Text = "Туристические путёвки";
            this.туристическиеПутёвкиToolStripMenuItem.Click += new System.EventHandler(this.туристическиеПутёвкиToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокПутёвокToolStripMenuItem,
            this.путёвкиПоКомпонентамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.складыПоКомпонентамToolStripMenuItem,
            this.списокЗаказовЗаВесьПериодToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокПутёвокToolStripMenuItem
            // 
            this.списокПутёвокToolStripMenuItem.Name = "списокПутёвокToolStripMenuItem";
            this.списокПутёвокToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.списокПутёвокToolStripMenuItem.Text = "Список путёвок";
            this.списокПутёвокToolStripMenuItem.Click += new System.EventHandler(this.списокПутёвокToolStripMenuItem_Click);
            // 
            // путёвкиПоКомпонентамToolStripMenuItem
            // 
            this.путёвкиПоКомпонентамToolStripMenuItem.Name = "путёвкиПоКомпонентамToolStripMenuItem";
            this.путёвкиПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.путёвкиПоКомпонентамToolStripMenuItem.Text = "Путёвки по компонентам";
            this.путёвкиПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.путёвкиПоКомпонентамToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // складыПоКомпонентамToolStripMenuItem
            // 
            this.складыПоКомпонентамToolStripMenuItem.Name = "складыПоКомпонентамToolStripMenuItem";
            this.складыПоКомпонентамToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.складыПоКомпонентамToolStripMenuItem.Text = "Склады по компонентам";
            this.складыПоКомпонентамToolStripMenuItem.Click += new System.EventHandler(this.складыПоКомпонентамToolStripMenuItem_Click);
            // 
            // списокЗаказовЗаВесьПериодToolStripMenuItem
            // 
            this.списокЗаказовЗаВесьПериодToolStripMenuItem.Name = "списокЗаказовЗаВесьПериодToolStripMenuItem";
            this.списокЗаказовЗаВесьПериодToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.списокЗаказовЗаВесьПериодToolStripMenuItem.Text = "Список заказов за весь период";
            this.списокЗаказовЗаВесьПериодToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовЗаВесьПериодToolStripMenuItem_Click);
            // 
            // пополнениеСкладаToolStripMenuItem
            // 
            this.пополнениеСкладаToolStripMenuItem.Name = "пополнениеСкладаToolStripMenuItem";
            this.пополнениеСкладаToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.пополнениеСкладаToolStripMenuItem.Text = "Пополнение склада";
            this.пополнениеСкладаToolStripMenuItem.Click += new System.EventHandler(this.пополнениеСкладаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 554);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Туристическая фирма";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonRef;
		private System.Windows.Forms.Button buttonPayOrder;
		private System.Windows.Forms.Button buttonOrderReady;
		private System.Windows.Forms.Button buttonTakeOrderInWork;
		private System.Windows.Forms.Button buttonCreateOrder;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem туристическиеПутёвкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокПутёвокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem путёвкиПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыПоКомпонентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовЗаВесьПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнениеСкладаToolStripMenuItem;
    }
}