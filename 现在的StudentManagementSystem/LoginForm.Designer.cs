using System.Windows.Forms;

namespace StudentManagementSystem
{
    partial class LoginForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            clickablePictureBox1 = new ClickablePictureBox();
            imageList1 = new ImageList(components);
            pictureButton3 = new PictureButton();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            pictureButton2 = new PictureButton();
            pictureButton1 = new PictureButton();
            pictureBox = new ClickablePictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clickablePictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources._22222画板_1;
            panel1.Controls.Add(clickablePictureBox1);
            panel1.Controls.Add(pictureButton3);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(pictureButton2);
            panel1.Controls.Add(pictureButton1);
            panel1.Location = new Point(0, -36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1213, 880);
            panel1.TabIndex = 9;
            // 
            // clickablePictureBox1
            // 
            clickablePictureBox1.BackColor = Color.FromArgb(209, 185, 213);
            clickablePictureBox1.CurrentImageIndex = 0;
            clickablePictureBox1.Image = (Image)resources.GetObject("clickablePictureBox1.Image");
            clickablePictureBox1.ImageList = imageList1;
            clickablePictureBox1.Location = new Point(569, 490);
            clickablePictureBox1.Name = "clickablePictureBox1";
            clickablePictureBox1.Size = new Size(50, 50);
            clickablePictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            clickablePictureBox1.TabIndex = 9;
            clickablePictureBox1.TabStop = false;
            clickablePictureBox1.Click += clickablePictureBox1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "微信图片_20230605002216.png");
            imageList1.Images.SetKeyName(1, "微信图片_20230605002210.png");
            // 
            // pictureButton3
            // 
            pictureButton3.BackColor = Color.Transparent;
            pictureButton3.BackgroundImage = Properties.Resources.微信图片_20230605001202;
            pictureButton3.Location = new Point(309, 639);
            pictureButton3.Name = "pictureButton3";
            pictureButton3.Size = new Size(122, 62);
            pictureButton3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureButton3.TabIndex = 8;
            pictureButton3.TabStop = false;
            pictureButton3.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(209, 185, 213);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(249, 503);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 37);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(209, 185, 213);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(249, 397);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(370, 37);
            txtUsername.TabIndex = 6;
            // 
            // pictureButton2
            // 
            pictureButton2.BackColor = Color.Transparent;
            pictureButton2.Image = Properties.Resources.CloseIcon;
            pictureButton2.Location = new Point(1105, 53);
            pictureButton2.Name = "pictureButton2";
            pictureButton2.Size = new Size(48, 40);
            pictureButton2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureButton2.TabIndex = 4;
            pictureButton2.TabStop = false;
            pictureButton2.Click += closeButton_Click;
            // 
            // pictureButton1
            // 
            pictureButton1.BackColor = Color.Transparent;
            pictureButton1.Image = Properties.Resources.MinimizeIcon;
            pictureButton1.Location = new Point(1012, 53);
            pictureButton1.Name = "pictureButton1";
            pictureButton1.Size = new Size(56, 40);
            pictureButton1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureButton1.TabIndex = 3;
            pictureButton1.TabStop = false;
            pictureButton1.Click += minimizeButton_Click;
            // 
            // pictureBox
            // 
            pictureBox.CurrentImageIndex = 0;
            pictureBox.ImageList = null;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(100, 50);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(213, 188, 217);
            ClientSize = new Size(1206, 839);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clickablePictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureButton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private PictureButton pictureButton2;
        private PictureButton pictureButton1;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private PictureButton pictureButton3;
        private ClickablePictureBox pictureBox;
        private ImageList imageList1;
        private ClickablePictureBox clickablePictureBox1;
    }
}