namespace Team_Frosty_Bites
{
    partial class Login_Page
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
            this.lb_welcome_loginpage = new System.Windows.Forms.Label();
            this.lb_pass_loginpage = new System.Windows.Forms.Label();
            this.lb_user_loginpage = new System.Windows.Forms.Label();
            this.tb_pass_loginpage = new System.Windows.Forms.TextBox();
            this.tb_userid_loginpage = new System.Windows.Forms.TextBox();
            this.pb_login = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_welcome_loginpage
            // 
            this.lb_welcome_loginpage.AutoSize = true;
            this.lb_welcome_loginpage.Font = new System.Drawing.Font("Calisto MT", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_welcome_loginpage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(41)))), ((int)(((byte)(89)))));
            this.lb_welcome_loginpage.Location = new System.Drawing.Point(693, 118);
            this.lb_welcome_loginpage.Name = "lb_welcome_loginpage";
            this.lb_welcome_loginpage.Size = new System.Drawing.Size(952, 144);
            this.lb_welcome_loginpage.TabIndex = 7;
            this.lb_welcome_loginpage.Text = "Welcome Back!";
            // 
            // lb_pass_loginpage
            // 
            this.lb_pass_loginpage.AutoSize = true;
            this.lb_pass_loginpage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pass_loginpage.Location = new System.Drawing.Point(709, 388);
            this.lb_pass_loginpage.Name = "lb_pass_loginpage";
            this.lb_pass_loginpage.Size = new System.Drawing.Size(197, 43);
            this.lb_pass_loginpage.TabIndex = 12;
            this.lb_pass_loginpage.Text = "Password";
            // 
            // lb_user_loginpage
            // 
            this.lb_user_loginpage.AutoSize = true;
            this.lb_user_loginpage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user_loginpage.Location = new System.Drawing.Point(710, 262);
            this.lb_user_loginpage.Name = "lb_user_loginpage";
            this.lb_user_loginpage.Size = new System.Drawing.Size(153, 43);
            this.lb_user_loginpage.TabIndex = 11;
            this.lb_user_loginpage.Text = "User ID";
            // 
            // tb_pass_loginpage
            // 
            this.tb_pass_loginpage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pass_loginpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pass_loginpage.Location = new System.Drawing.Point(714, 422);
            this.tb_pass_loginpage.MaxLength = 100;
            this.tb_pass_loginpage.Name = "tb_pass_loginpage";
            this.tb_pass_loginpage.Size = new System.Drawing.Size(426, 49);
            this.tb_pass_loginpage.TabIndex = 10;
            this.tb_pass_loginpage.UseSystemPasswordChar = true;
            // 
            // tb_userid_loginpage
            // 
            this.tb_userid_loginpage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_userid_loginpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_userid_loginpage.Location = new System.Drawing.Point(713, 293);
            this.tb_userid_loginpage.Name = "tb_userid_loginpage";
            this.tb_userid_loginpage.Size = new System.Drawing.Size(426, 49);
            this.tb_userid_loginpage.TabIndex = 100;
            // 
            // pb_login
            // 
            this.pb_login.Image = global::Team_Frosty_Bites.Properties.Resources.Log_in_Button;
            this.pb_login.Location = new System.Drawing.Point(743, 526);
            this.pb_login.Name = "pb_login";
            this.pb_login.Size = new System.Drawing.Size(362, 68);
            this.pb_login.TabIndex = 14;
            this.pb_login.TabStop = false;
            this.pb_login.Click += new System.EventHandler(this.pb_login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Team_Frosty_Bites.Properties.Resources.Logo_Frosty_Bites;
            this.pictureBox1.Location = new System.Drawing.Point(37, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 451);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(236)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(1274, 679);
            this.Controls.Add(this.pb_login);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_pass_loginpage);
            this.Controls.Add(this.lb_user_loginpage);
            this.Controls.Add(this.tb_pass_loginpage);
            this.Controls.Add(this.tb_userid_loginpage);
            this.Controls.Add(this.lb_welcome_loginpage);
            this.Name = "Login_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LOGIN PAGE";
            ((System.ComponentModel.ISupportInitialize)(this.pb_login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_welcome_loginpage;
        private System.Windows.Forms.Label lb_pass_loginpage;
        private System.Windows.Forms.Label lb_user_loginpage;
        private System.Windows.Forms.TextBox tb_pass_loginpage;
        private System.Windows.Forms.TextBox tb_userid_loginpage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pb_login;
    }
}

