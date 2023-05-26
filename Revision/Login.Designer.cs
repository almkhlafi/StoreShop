namespace Revision
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Pwd = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.TextBox();
            this.register = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.register);
            this.groupBox1.Controls.Add(this.Confirm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Pwd);
            this.groupBox1.Controls.Add(this.Username);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(71, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // Confirm
            // 
            this.Confirm.BackColor = System.Drawing.Color.DodgerBlue;
            this.Confirm.ForeColor = System.Drawing.Color.Black;
            this.Confirm.Location = new System.Drawing.Point(370, 208);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(171, 45);
            this.Confirm.TabIndex = 4;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(43, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(35, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username :";
            // 
            // Pwd
            // 
            this.Pwd.Location = new System.Drawing.Point(188, 147);
            this.Pwd.Name = "Pwd";
            this.Pwd.Size = new System.Drawing.Size(353, 41);
            this.Pwd.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(188, 90);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(353, 41);
            this.Username.TabIndex = 0;
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(200, 209);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(152, 42);
            this.register.TabIndex = 5;
            this.register.Text = "register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 378);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox Pwd;
        private TextBox Username;
        private Button Confirm;
        private Button register;
    }
}