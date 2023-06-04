using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    // Form1��̳���Form�࣬��ʾ������
    public partial class Form1 : Form
    {
        // ˽���ֶΣ������û��������롢�����֤״̬�Լ�һ��StudentManagerʵ��
        private string username = "admin";
        private string password = "password";
        private bool isAuthenticated = false;
        private StudentManager manager;

        // Form1�Ĺ��캯������ʵ����Form1����ʱ������
        public Form1()
        {
            // ��ʼ��Form�����StudentManagerʵ��
            InitializeComponent();
            manager = new StudentManager();
        }

        // ��Form1����ʱ�������¼����������ʾ��¼����
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        // ��ʾ��¼���ڵķ���
        private void ShowLoginForm()
        {
            // ʹ��using����ȷ��LoginForm��ʹ�ú���ȷ�ͷ�
            using (LoginForm loginForm = new LoginForm())
            {
                // ��ʾLoginForm����ȡ�Ի�����
                DialogResult result = loginForm.ShowDialog();

                // �����¼�ɹ������������֤״̬����ʾ�����ڣ�����رմ˴���
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
            // ���û�гɹ���¼������ʾ������
            if (!isAuthenticated)
            {
                this.Show();
            }
        }

        private void ShowMainForm()
        {
            
        }

        // ���ѧ����ť���¼��������
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // ����Ѿ���¼
            {
                // ��ȡ������е�����
                string name = txtName.Text;
                string ageText = txtAge.Text;
                string gender = txtGender.Text;
                string scoreText = txtScore.Text;

                // �����һ�����Ϊ�գ�������ʾ������
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ageText) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(scoreText))
                {
                    MessageBox.Show("����������ѧ����Ϣ��");
                    return;
                }

                // ���Խ�����ͷ���ת��Ϊ������˫�������ͣ��������ת����������ʾ������
                if (!int.TryParse(ageText, out int age))
                {
                    MessageBox.Show("��������Ч�����䣡");
                    return;
                }

                if (!double.TryParse(scoreText, out double score))
                {
                    MessageBox.Show("��������Ч�ķ�����");
                    return;
                }

                // ����һ���µ�ѧ��������ӵ�������
                Student student = new Student(name, age, gender, score);
                manager.AddStudent(student);

                // ��������
                txtName.Clear();
                txtAge.Clear();
                txtGender.Clear();
                txtScore.Clear();

                // ��ʾ��ӳɹ�����ʾ
                MessageBox.Show("��ӳɹ���");
            }
            else // ���δ��¼��������ʾ
            {
                MessageBox.Show("���ȵ�¼��");
                
            }
        }



        // ɾ��ѧ����ť���¼��������
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                string name = txtName.Text;
                bool isDeleted = false;

                // ��������ı��������ı�����ô��������ɾ��ѧ��
                if (!string.IsNullOrEmpty(name))
                {
                    try
                    {
                        manager.DeleteStudent(name);
                        isDeleted = true;
                        MessageBox.Show("ɾ���ɹ���");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // ����б����ѡ����ѧ������ô����ѡ�е���Ŀɾ��ѧ��
                if (lstStudents.SelectedIndex != -1)
                {
                    // ����Ŀ�н���ѧ������
                    string studentItem = lstStudents.SelectedItem.ToString();
                    name = studentItem.Substring(studentItem.IndexOf('��') + 1, studentItem.IndexOf('��') - studentItem.IndexOf('��') - 1);

                    try
                    {
                        manager.DeleteStudent(name);
                        // ���б����ɾ��ѡ�е���Ŀ
                        lstStudents.Items.RemoveAt(lstStudents.SelectedIndex);
                        isDeleted = true;
                        MessageBox.Show("ɾ���ɹ���");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (!isDeleted)
                {
                    MessageBox.Show("������ѧ�����������б���ѡ��һ��ѧ����");
                }

                // �������򲢸����б��
                txtName.Clear();
                UpdateStudentListBox();
            }
            else
            {
                MessageBox.Show("���ȵ�¼��");
                
            }
        }


        // ����ѧ���б�ķ���
        private void UpdateStudentListBox()
        {
            lstStudents.Items.Clear();
            foreach (Student student in manager.Students)
            {
                lstStudents.Items.Add("������" + student.Name + "�����䣺" + student.Age + "���Ա�" + student.Gender + "���ɼ���" + student.Score);
            }
        }

        // ����ѧ����ť���¼��������

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // ����Ѿ���¼
            {
                // ��ȡ������е������ͷ���
                string name = txtName.Text; // ѧ������
                string scoreText = txtScore.Text; // ѧ���ɼ�

                // �������������������Ϊ�գ�������ʾ������
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(scoreText))
                {
                    MessageBox.Show("������ѧ�����ֺ��µķ�����");
                    return;
                }

                // ���Խ�����ת��Ϊ˫�������ͣ��������ת����������ʾ������
                if (!double.TryParse(scoreText, out double score))
                {
                    MessageBox.Show("��������Ч�ķ�����");
                    return;
                }

                // ����ָ��ѧ���ķ���
                manager.UpdateStudent(name, score);

                // ��������
                txtName.Clear();
                txtAge.Clear();
                txtGender.Clear();
                txtScore.Clear();

                // �����б��
                lstStudents.Items.Clear();
                foreach (Student student in manager.Students)
                {
                    lstStudents.Items.Add("������" + student.Name + "�����䣺" + student.Age + "���Ա�" + student.Gender + "���ɼ���" + student.Score);
                }

                // ��ʾ���³ɹ�����ʾ
                MessageBox.Show("�޸ĳɹ���");
            }
            else // ���δ��¼��������ʾ
            {
                MessageBox.Show("���ȵ�¼��");
                
            }
        }




        // ��ѯѧ����ť���¼��������
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // ����Ѿ���¼
            {
                // ��ȡ������е�����
                string name = txtName.Text;

                // ��������Ϊ�գ�������ʾ������
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("������ѧ�����֣�");
                    return;
                }

                // ��ѯѧ��
                Student student = manager.QueryStudent(name);

                // ����ҵ�ѧ������ʾѧ����Ϣ�������������򲢸�����ʾ
                if (student != null)
                {
                    txtAge.Text = student.Age.ToString();
                    txtGender.Text = student.Gender;
                    txtScore.Text = student.Score.ToString();

                    MessageBox.Show("��ѯ�ɹ���");
                }
                else
                {
                    txtName.Clear();
                    txtAge.Clear();
                    txtGender.Clear();
                    txtScore.Clear();

                    MessageBox.Show("û���ҵ���ѧ����");
                }
            }
            else // ���δ��¼��������ʾ
            {
                MessageBox.Show("���ȵ�¼��");
                
            }
        }



        // ��ʾ����ѧ����ť���¼��������
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (isAuthenticated) // ����Ѿ���¼
            {
                // ����б���ȡ����ѧ����Ϣ
                lstStudents.Items.Clear();
                manager.ShowStudents();

                // ������ѧ����Ϣ��ӵ��б�
                foreach (Student student in manager.Students)
                {
                    lstStudents.Items.Add("������" + student.Name + "�����䣺" + student.Age + "���Ա�" + student.Gender + "���ɼ���" + student.Score);
                }
            }
            else // ���δ��¼��������ʾ
            {
                MessageBox.Show("���ȵ�¼��");
                
            }
        }
        //�����б��ť���¼��������
        private void btnHideListbox_Click(object sender, EventArgs e)
        {
            lstStudents.Items.Clear(); // ����б���е���
        }
        // ����ѧ����Ϣ���ı��ļ�
        private void SaveStudentsToFile(string filePath)
        {
            if (isAuthenticated)
            {
                try
                {
                    // ʹ�� StreamWriter ���ļ���д��ѧ����Ϣ
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Student student in manager.Students)
                        {
                            string line = $"{student.Name},{student.Age},{student.Gender},{student.Score}";
                            writer.WriteLine(line);
                        }
                    }

                    MessageBox.Show("ѧ����Ϣ�ѳɹ����浽�ļ���");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"����ѧ����Ϣʱ����{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("���ȵ�¼��");
            }
        }

        // ���ı��ļ��м���ѧ����Ϣ
        private void LoadStudentsFromFile(string filePath)
        {
                try
                {
                    // ʹ�� StreamReader ���ļ������ж�ȡѧ����Ϣ
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
                                throw new FormatException("��Ч��ѧ����Ϣ��");
                            }
                        }
                    }

                    MessageBox.Show("ѧ����Ϣ�ѳɹ����أ�");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"����ѧ����Ϣʱ����{ex.Message}");
                }
               
           
            
        }

        // ���水ť�ĵ���¼��������
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                // ���������ļ��Ի���
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "�ı��ļ�|*.txt";
                saveFileDialog.Title = "����ѧ����Ϣ";

                // ����û�ѡ�����ļ��������ȷ����ť
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ��ȡѡ�����ļ�·��
                    string filePath = saveFileDialog.FileName;

                    // ���� SaveStudentsToFile ��������ѧ����Ϣ���ļ�
                    SaveStudentsToFile(filePath);
                }
            }
            else
            {
                MessageBox.Show("���ȵ�¼��");
            }
        }

        // ���ذ�ť�ĵ���¼��������
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (isAuthenticated)
            {
                // �������ļ��Ի���
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "�ı��ļ�|*.txt";
                openFileDialog.Title = "����ѧ����Ϣ";

                // ����û�ѡ�����ļ��������ȷ����ť
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // ��ȡѡ�����ļ�·��
                    string filePath = openFileDialog.FileName;

                    // ���� LoadStudentsFromFile �������ļ��м���ѧ����Ϣ
                    LoadStudentsFromFile(filePath);
                }
            }
            else
            {
                MessageBox.Show("���ȵ�¼��");
            }
        }
        // ע���˻���ť�ĵ���¼��������
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // ִ��ע���˻��߼��������˻���ص�״̬�ͱ���
            isAuthenticated = false;
            username = string.Empty;

            // ����ע���߼�
            txtName.Clear();
            txtAge.Clear();
            txtGender.Clear();
            txtScore.Clear();
            lstStudents.Items.Clear();
            // ��ʾע���ɹ�����ʾ��Ϣ��
            MessageBox.Show("�˻��ѳɹ�ע����");
        }


        // ��¼�˻���ť�ĵ���¼��������
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ��鵱ǰ�Ƿ��ѵ�¼�˻�
            if (isAuthenticated)
            {
                // ����ѵ�¼����ʾ�ѵ�¼����ʾ��Ϣ��
                MessageBox.Show("���ѵ�¼�˻���");
            }
            else
            {
                // ���δ��¼����������ʾ��¼����
                MessageBox.Show("��δ��¼�˻�����ȷ������ת��¼���棡");
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

                // �����¼���ڵĵ�¼�߼�
                // ��֤�û����������

                // �����¼�ɹ�
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    // ���µ�¼״̬�������Ϣ
                    isAuthenticated = true;
                    username = loginForm.username; // ��ȡ��¼�����е��û���

                    // �رյ�¼���ڲ���ʾ������
                    loginForm.Close();
                    this.Show();
                } 
            }
        }

    }

}

