namespace Revision
{
    partial class payment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.Label();
            this.Pay = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pay);
            this.groupBox1.Controls.Add(this.Amount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Confirm);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(26, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment";
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.SpringGreen;
            this.Confirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Confirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Confirm.Location = new System.Drawing.Point(409, 138);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(133, 43);
            this.Confirm.TabIndex = 0;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount :";
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(192, 69);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(0, 35);
            this.Amount.TabIndex = 2;
            // 
            // Pay
            // 
            this.Pay.AutoSize = true;
            this.Pay.Location = new System.Drawing.Point(342, 69);
            this.Pay.Name = "Pay";
            this.Pay.Size = new System.Drawing.Size(76, 39);
            this.Pay.TabIndex = 3;
            this.Pay.TabStop = true;
            this.Pay.Text = "Pay";
            this.Pay.UseVisualStyleBackColor = true;
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 224);
            this.Controls.Add(this.groupBox1);
            this.Name = "payment";
            this.Text = "payment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton Pay;
        private Label Amount;
        private Label label1;
        private Button Confirm;
    }
}