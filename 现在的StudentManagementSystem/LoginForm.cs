using System;
using System.Windows.Forms;

// 定义了一个名为StudentManagementSystem的命名空间
namespace StudentManagementSystem
{
    // LoginForm类是Form类的一个子类，LoginForm表示应用程序中的登录窗口
    public partial class LoginForm : Form
    {
        // 定义了两个私有字符串变量，username和password，是硬编码
        
        public string username = "admin";
        private string password = "password";

        // LoginForm的构造函数，在实例化LoginForm对象时被调用
        public LoginForm()
        {
            // 调用的是Form的初始化组件方法，此方法是由Windows Forms设计器生成的，用来初始化窗体
            InitializeComponent();
            btnTogglePassword.Click += btnTogglePassword_Click;
        }

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

        // 切换密码显示/隐藏按钮的点击事件处理程序
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // 切换密码显示状态的标志变量
            isPasswordVisible = !isPasswordVisible;

            // 根据密码显示状态设置密码输入框的属性
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;

            // 根据密码显示状态更新按钮的文本
            btnTogglePassword.Text = isPasswordVisible ? "显示" : "隐藏";
        }
    }
}


