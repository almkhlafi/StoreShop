namespace Revision
{
    partial class Product_control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productImage = new System.Windows.Forms.PictureBox();
            this.Amountt = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Product_Id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amountt)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.Location = new System.Drawing.Point(3, 3);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(197, 222);
            this.productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // Amountt
            // 
            this.Amountt.Location = new System.Drawing.Point(135, 188);
            this.Amountt.Name = "Amountt";
            this.Amountt.Size = new System.Drawing.Size(50, 27);
            this.Amountt.TabIndex = 1;
            this.Amountt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price :";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Price.Location = new System.Drawing.Point(105, 236);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(17, 19);
            this.Price.TabIndex = 3;
            this.Price.Text = "$";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Description.Location = new System.Drawing.Point(12, 251);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(0, 15);
            this.Description.TabIndex = 4;
            // 
            // Product_Id
            // 
            this.Product_Id.AutoSize = true;
            this.Product_Id.Location = new System.Drawing.Point(185, 274);
            this.Product_Id.Name = "Product_Id";
            this.Product_Id.Size = new System.Drawing.Size(0, 20);
            this.Product_Id.TabIndex = 5;
            // 
            // Product_control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.Product_Id);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Amountt);
            this.Controls.Add(this.productImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Product_control";
            this.Size = new System.Drawing.Size(203, 294);
            this.Load += new System.EventHandler(this.Product_control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Amountt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox productImage;
        private NumericUpDown Amountt;
        private Label label1;
        private Label Price;
        private TextBox ProductDes;
        private Label label2;
        private Label Description;
        private Label Product_Id;
    }
}
