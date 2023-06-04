using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    // Form1类继承于Form类，表示主窗体
    public partial class Form1 : Form
    {
        // 私有字段，包括用户名、密码、身份验证状态以及一个StudentManager实例
        private string username = "admin";
        private string password = "password";
        private bool isAuthenticated = false;
        private StudentManager manager;

        // Form1的构造函数，在实例化Form1对象时被调用
        public Form1()
        {
            // 初始化Form组件和StudentManager实例
            InitializeComponent();
            manager = new StudentManager();
        }

        // 当Form1载入时触发此事件处理程序，显示登录窗口
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        // 显示登录窗口的方法
        private void ShowLoginForm()
        {
            // 使用using声明确保LoginForm在使用后被正确释放
            using (LoginForm loginForm = new LoginForm())
            {
                // 显示LoginForm并获取对话框结果
                DialogResult result = loginForm.ShowDialog();

                // 如果登录成功，更新身份验证状态并显示主窗口；否则关闭此窗口
                if (result == DialogResult.OK)
                {
                    isAuthenticated = true;
                    ShowMainForm();
                }
                else
                {
                    Close();
                }
            }
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 如果没有成功登录，则显示主窗口
            if (!isAuthenticated)
            {
                this.Show();
            }
        }

        private void ShowMainForm()
        {
            
        }

        // 添加学生按钮的事件处理程序
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // 如果已经登录
            {
                // 读取输入框中的内容
                string name = txtName.Text;
                string ageText = txtAge.Text;
                string gender = txtGender.Text;
                string scoreText = txtScore.Text;

                // 如果任一输入框为空，给出提示并返回
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ageText) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(scoreText))
                {
                    MessageBox.Show("请完整输入学生信息！");
                    return;
                }

                // 尝试将年龄和分数转换为整数和双精度类型，如果不能转换，给出提示并返回
                if (!int.TryParse(ageText, out int age))
                {
                    MessageBox.Show("请输入有效的年龄！");
                    return;
                }

                if (!double.TryParse(scoreText, out double score))
                {
                    MessageBox.Show("请输入有效的分数！");
                    return;
                }

                // 创建一个新的学生对象并添加到管理器
                Student student = new Student(name, age, gender, score);
                manager.AddStudent(student);

                // 清空输入框
                txtName.Clear();
                txtAge.Clear();
                txtGender.Clear();
                txtScore.Clear();

                // 显示添加成功的提示
                MessageBox.Show("添加成功！");
            }
            else // 如果未登录，给出提示
            {
                MessageBox.Show("请先登录！");
                
            }
        }



        // 删除学生按钮的事件处理程序
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                string name = txtName.Text;
                bool isDeleted = false;

                // 如果姓名文本框中有文本，那么根据姓名删除学生
                if (!string.IsNullOrEmpty(name))
                {
                    try
                    {
                        manager.DeleteStudent(name);
                        isDeleted = true;
                        MessageBox.Show("删除成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // 如果列表框中选中了学生，那么根据选中的项目删除学生
                if (lstStudents.SelectedIndex != -1)
                {
                    // 从项目中解析学生姓名
                    string studentItem = lstStudents.SelectedItem.ToString();
                    name = studentItem.Substring(studentItem.IndexOf('：') + 1, studentItem.IndexOf('，') - studentItem.IndexOf('：') - 1);

                    try
                    {
                        manager.DeleteStudent(name);
                        // 从列表框中删除选中的项目
                        lstStudents.Items.RemoveAt(lstStudents.SelectedIndex);
                        isDeleted = true;
                        MessageBox.Show("删除成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (!isDeleted)
                {
                    MessageBox.Show("请输入学生姓名或在列表中选择一个学生！");
                }

                // 清除输入框并更新列表框
                txtName.Clear();
                UpdateStudentListBox();
            }
            else
            {
                MessageBox.Show("请先登录！");
                
            }
        }


        // 更新学生列表的方法
        private void UpdateStudentListBox()
        {
            lstStudents.Items.Clear();
            foreach (Student student in manager.Students)
            {
                lstStudents.Items.Add("姓名：" + student.Name + "，年龄：" + student.Age + "，性别：" + student.Gender + "，成绩：" + student.Score);
            }
        }

        // 更新学生按钮的事件处理程序

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // 如果已经登录
            {
                // 读取输入框中的姓名和分数
                string name = txtName.Text; // 学生姓名
                string scoreText = txtScore.Text; // 学生成绩

                // 如果姓名或分数的输入框为空，给出提示并返回
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(scoreText))
                {
                    MessageBox.Show("请输入学生名字和新的分数！");
                    return;
                }

                // 尝试将分数转换为双精度类型，如果不能转换，给出提示并返回
                if (!double.TryParse(scoreText, out double score))
                {
                    MessageBox.Show("请输入有效的分数！");
                    return;
                }

                // 更新指定学生的分数
                manager.UpdateStudent(name, score);

                // 清空输入框
                txtName.Clear();
                txtAge.Clear();
                txtGender.Clear();
                txtScore.Clear();

                // 更新列表框
                lstStudents.Items.Clear();
                foreach (Student student in manager.Students)
                {
                    lstStudents.Items.Add("姓名：" + student.Name + "，年龄：" + student.Age + "，性别：" + student.Gender + "，成绩：" + student.Score);
                }

                // 显示更新成功的提示
                MessageBox.Show("修改成功！");
            }
            else // 如果未登录，给出提示
            {
                MessageBox.Show("请先登录！");
                
            }
        }




        // 查询学生按钮的事件处理程序
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // 如果已经登录
            {
                // 读取输入框中的内容
                string name = txtName.Text;

                // 如果输入框为空，给出提示并返回
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入学生名字！");
                    return;
                }

                // 查询学生
                Student student = manager.QueryStudent(name);

                // 如果找到学生，显示学生信息，否则清空输入框并给出提示
                if (student != null)
                {
                    txtAge.Text = student.Age.ToString();
                    txtGender.Text = student.Gender;
                    txtScore.Text = student.Score.ToString();

                    MessageBox.Show("查询成功！");
                }
                else
                {
                    txtName.Clear();
                    txtAge.Clear();
                    txtGender.Clear();
                    txtScore.Clear();

                    MessageBox.Show("没有找到该学生！");
                }
            }
            else // 如果未登录，给出提示
            {
                MessageBox.Show("请先登录！");
                
            }
        }



        // 显示所有学生按钮的事件处理程序
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // 如果已经登录
            {
                // 清空列表并获取所有学生信息
                lstStudents.Items.Clear();
                manager.ShowStudents();

                // 将所有学生信息添加到列表
                foreach (Student student in manager.Students)
                {
                    lstStudents.Items.Add("姓名：" + student.Name + "，年龄：" + student.Age + "，性别：" + student.Gender + "，成绩：" + student.Score);
                }
            }
            else // 如果未登录，给出提示
            {
                MessageBox.Show("请先登录！");
                
            }
        }
        //隐藏列表框按钮的事件处理程序
        private void btnHideListbox_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear(); // 清空列表框中的项
        }
        // 保存学生信息到文本文件
        private void SaveStudentsToFile(string filePath)
        {
            if (isAuthenticated)
            {
                try
                {
                    // 使用 StreamWriter 打开文件并写入学生信息
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Student student in manager.Students)
                        {
                            string line = $"{student.Name},{student.Age},{student.Gender},{student.Score}";
                            writer.WriteLine(line);
                        }
                    }

                    MessageBox.Show("学生信息已成功保存到文件！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存学生信息时出错：{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("请先登录！");
            }
        }

        // 从文本文件中加载学生信息
        private void LoadStudentsFromFile(string filePath)
        {
                try
                {
                    // 使用 StreamReader 打开文件并逐行读取学生信息
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] parts = line.Split(',');

                            if (parts.Length == 4)
                            {
                                string name = parts[0];
                                int age = int.Parse(parts[1]);
                                string gender = parts[2];
                                double score = double.Parse(parts[3]);

                                Student student = new Student(name, age, gender, score);
                                manager.AddStudent(student);
                            }
                            else
                            {
                                throw new FormatException("无效的学生信息！");
                            }
                        }
                    }

                    MessageBox.Show("学生信息已成功加载！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"加载学生信息时出错：{ex.Message}");
                }
               
           
            
        }

        // 保存按钮的点击事件处理程序
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                // 创建保存文件对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "文本文件|*.txt";
                saveFileDialog.Title = "保存学生信息";

                // 如果用户选择了文件并点击了确定按钮
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选定的文件路径
                    string filePath = saveFileDialog.FileName;

                    // 调用 SaveStudentsToFile 方法保存学生信息到文件
                    SaveStudentsToFile(filePath);
                }
            }
            else
            {
                MessageBox.Show("请先登录！");
            }
        }

        // 加载按钮的点击事件处理程序
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                // 创建打开文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "文本文件|*.txt";
                openFileDialog.Title = "加载学生信息";

                // 如果用户选择了文件并点击了确定按钮
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取选定的文件路径
                    string filePath = openFileDialog.FileName;

                    // 调用 LoadStudentsFromFile 方法从文件中加载学生信息
                    LoadStudentsFromFile(filePath);
                }
            }
            else
            {
                MessageBox.Show("请先登录！");
            }
        }
        // 注销账户按钮的点击事件处理程序
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 执行注销账户逻辑，重置账户相关的状态和变量
            isAuthenticated = false;
            username = string.Empty;

            // 其他注销逻辑
            txtName.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtScore.Clear();
            lstStudents.Items.Clear();
            // 显示注销成功的提示消息框
            MessageBox.Show("账户已成功注销！");
        }


        // 登录账户按钮的点击事件处理程序
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 检查当前是否已登录账户
            if (isAuthenticated)
            {
                // 如果已登录，显示已登录的提示消息框
                MessageBox.Show("您已登录账户！");
            }
            else
            {
                // 如果未登录，创建并显示登录窗口
                MessageBox.Show("您未登录账户，按确定后跳转登录界面！");
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

                // 处理登录窗口的登录逻辑
                // 验证用户名和密码等

                // 如果登录成功
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    // 更新登录状态和相关信息
                    isAuthenticated = true;
                    username = loginForm.username; // 获取登录窗口中的用户名

                    // 关闭登录窗口并显示主窗口
                    loginForm.Close();
                    this.Show();
                } 
            }
        }

    }

}

