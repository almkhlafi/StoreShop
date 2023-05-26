namespace Revision
{
    partial class ListProducts
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
            this.Amount = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.Product_Id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).BeginInit();
            this.SuspendLayout();
            // 
            // productImage
            // 
            this.productImage.Location = new System.Drawing.Point(7, 6);
            this.productImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productImage.Name = "productImage";
            this.productImage.Size = new System.Drawing.Size(96, 90);
            this.productImage.TabIndex = 0;
            this.productImage.TabStop = false;
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Amount.Location = new System.Drawing.Point(177, 58);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(75, 20);
            this.Amount.TabIndex = 2;
            this.Amount.Text = "Amount :";
            this.Amount.MouseEnter += new System.EventHandler(this.ListProducts_MouseEnter);
            this.Amount.MouseHover += new System.EventHandler(this.ListProducts_MouseHover);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Price.Location = new System.Drawing.Point(299, 58);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(51, 20);
            this.Price.TabIndex = 3;
            this.Price.Text = "Price :";
            this.Price.MouseEnter += new System.EventHandler(this.ListProducts_MouseEnter);
            this.Price.MouseHover += new System.EventHandler(this.ListProducts_MouseHover);
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Description.Location = new System.Drawing.Point(122, 13);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(0, 20);
            this.Description.TabIndex = 4;
            // 
            // Product_Id
            // 
            this.Product_Id.AutoSize = true;
            this.Product_Id.Location = new System.Drawing.Point(390, 81);
            this.Product_Id.Name = "Product_Id";
            this.Product_Id.Size = new System.Drawing.Size(0, 15);
            this.Product_Id.TabIndex = 5;
            // 
            // ListProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.Product_Id);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.productImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ListProducts";
            this.Size = new System.Drawing.Size(428, 101);
            this.MouseEnter += new System.EventHandler(this.ListProducts_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListProducts_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ListProducts_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.productImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox productImage;
        private Label Amount;
        private Label Price;
        private Label Description;
        private Label Product_Id;
    }
}
