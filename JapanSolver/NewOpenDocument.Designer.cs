
namespace JapanSolver
{
	partial class NewOpenDocument
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonCreateDoc = new System.Windows.Forms.Button();
			this.newDocRows = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.newDocColumns = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.newDocRows)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.newDocColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCreateDoc
			// 
			this.buttonCreateDoc.Location = new System.Drawing.Point(129, 123);
			this.buttonCreateDoc.Name = "buttonCreateDoc";
			this.buttonCreateDoc.Size = new System.Drawing.Size(112, 23);
			this.buttonCreateDoc.TabIndex = 0;
			this.buttonCreateDoc.Text = "Создать";
			this.buttonCreateDoc.UseVisualStyleBackColor = true;
			this.buttonCreateDoc.Click += new System.EventHandler(this.ButtonCreateDocClick);
			// 
			// newDocRows
			// 
			this.newDocRows.Location = new System.Drawing.Point(177, 19);
			this.newDocRows.Name = "newDocRows";
			this.newDocRows.Size = new System.Drawing.Size(64, 20);
			this.newDocRows.TabIndex = 1;
			this.newDocRows.Value = new decimal(new int[] {
									20,
									0,
									0,
									0});
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.buttonCreateDoc);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.newDocColumns);
			this.groupBox1.Controls.Add(this.newDocRows);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 156);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Новый кроссворд";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 99);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(145, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Столбцов для чисел слева";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Строк для чисел сверху";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Столбцов";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(177, 97);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(64, 20);
			this.numericUpDown2.TabIndex = 1;
			this.numericUpDown2.Value = new decimal(new int[] {
									5,
									0,
									0,
									0});
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(177, 71);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(64, 20);
			this.numericUpDown1.TabIndex = 1;
			this.numericUpDown1.Value = new decimal(new int[] {
									5,
									0,
									0,
									0});
			// 
			// newDocColumns
			// 
			this.newDocColumns.Location = new System.Drawing.Point(177, 45);
			this.newDocColumns.Name = "newDocColumns";
			this.newDocColumns.Size = new System.Drawing.Size(64, 20);
			this.newDocColumns.TabIndex = 1;
			this.newDocColumns.Value = new decimal(new int[] {
									17,
									0,
									0,
									0});
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Строк";
			// 
			// NewOpenDocument
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.groupBox1);
			this.Name = "NewOpenDocument";
			this.Text = "NewOpenDocument";
			((System.ComponentModel.ISupportInitialize)(this.newDocRows)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.newDocColumns)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonCreateDoc;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown newDocColumns;
		private System.Windows.Forms.NumericUpDown newDocRows;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
