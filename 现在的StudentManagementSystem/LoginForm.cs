using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// 定义了一个名为StudentManagementSystem的命名空间
namespace StudentManagementSystem
{
    // LoginForm类是Form类的一个子类，LoginForm表示应用程序中的登录窗口
    public partial class LoginForm : Form
    {
        // 定义了两个私有字符串变量，username和password，是硬编码
        private ToolStrip toolStrip;
        public string username = "admin";
        private string password = "password";
        private Panel titleBar;
        private Panel contentPanel;
        private Point mouseOffset;


        private Color titleColor = Color.FromArgb(213, 188, 217);
        private Font titleFont = new Font("Arial", 12, FontStyle.Bold);
        private StringFormat titleFormat = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

        public LoginForm()
        {

            InitializeComponent();
            // 实例化 clickablePictureBox1
            clickablePictureBox1 = new ClickablePictureBox();

            // 设置图片为带隐藏符号的小眼睛


            // 设置其他属性

            clickablePictureBox1.Name = "clickablePictureBox1";


            clickablePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            clickablePictureBox1.TabIndex = 0;
            clickablePictureBox1.TabStop = false;

            // 绑定点击事件处理程序
            clickablePictureBox1.Click += clickablePictureBox1_Click;

            // 将clickablePictureBox1添加到窗体的控件集合中
            panel1.Controls.Add(clickablePictureBox1);
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.None;
            titleBar = new Panel();
            titleBar.Dock = DockStyle.Top;
            titleBar.BackColor = Color.Transparent;
            this.Controls.Add(titleBar);

            toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;
            this.Controls.Add(toolStrip);

            // 创建最小化按钮
            ToolStripButton minimizeButton = new ToolStripButton();
            minimizeButton.Image = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
            minimizeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            minimizeButton.Click += minimizeButton_Click;
            toolStrip.Items.Add(minimizeButton);

            // 创建最大化/还原按钮
            ToolStripButton maximizeRestoreButton = new ToolStripButton();
            maximizeRestoreButton.Image = SystemIcons.Exclamation.ToBitmap();
            maximizeRestoreButton.DisplayStyle = ToolStripItemDisplayStyle.Image;

            toolStrip.Items.Add(maximizeRestoreButton);

            // 创建关闭按钮
            ToolStripButton closeButton = new ToolStripButton();
            closeButton.Image = SystemIcons.Error.ToBitmap();
            closeButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            closeButton.Click += closeButton_Click;
            toolStrip.Items.Add(closeButton);
            contentPanel = panel1; // 替换为你的工作内容控件

            // 添加鼠标事件
            contentPanel.MouseDown += ContentPanel_MouseDown;
            contentPanel.MouseMove += ContentPanel_MouseMove;
            contentPanel.MouseUp += ContentPanel_MouseUp;
        }
        private void ContentPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // 记录鼠标按下时的偏移量
            mouseOffset = new Point(-e.X, -e.Y);
        }

        private void ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // 检查鼠标左键是否按下
            if (e.Button == MouseButtons.Left)
            {
                // 计算窗口新的位置
                Point newLocation = MousePosition;
                newLocation.Offset(mouseOffset.X, mouseOffset.Y);

                // 更新窗口位置
                this.Location = newLocation;
            }
        }

        private void ContentPanel_MouseUp(object sender, MouseEventArgs e)
        {
            // 清除偏移量
            mouseOffset = Point.Empty;
        }
        private void titleBar_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 绘制标题栏的背景
            g.Clear(Color.Transparent);

            // 绘制其他标题栏元素，如标题文本、图标等
            // ...
        }
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 绘制标题栏背景
            using (SolidBrush brush = new SolidBrush(titleColor))
            {
                g.FillRectangle(brush, 0, 0, this.Width, 30);
            }
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            // 使窗口能够通过标题栏拖动
            if (e.Button == MouseButtons.Left && e.Y <= 30)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Windows API
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();


        // 设置窗口的背景色



        // btnLogin_Click是一个事件处理程序，当用户点击登录按钮时调用
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 从文本框中获取输入的用户名和密码
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            // 如果输入的用户名和密码与预定义的用户名和密码匹配，则登录成功
            if (inputUsername == username && inputPassword == password)
            {
                // DialogResult属性设置为OK，可以用于在登录成功后关闭此窗口，并向调用它的代码返回成功的结果
                DialogResult = DialogResult.OK;
            }
            else
            {
                // 如果用户名或密码错误，显示错误消息
                MessageBox.Show("用户名或密码错误！");
            }
        }


        private bool isPasswordVisible = false;
        private bool isImage1Displayed = true;

        // 切换密码显示/隐藏按钮的点击事件处理程序
        private void clickablePictureBox1_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isImage1Displayed)
            {
                clickablePictureBox1.Image = Properties.Resources.微信图片_20230605002216;
                txtPassword.UseSystemPasswordChar = false;
                isImage1Displayed = false;
            }
            else
            {
                clickablePictureBox1.Image = Properties.Resources.微信图片_20230605002210;
                txtPassword.UseSystemPasswordChar = true;
                isImage1Displayed = true;
            }
        }


    }
}







