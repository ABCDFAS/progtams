namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtAge = new TextBox();
            label3 = new Label();
            txtGender = new TextBox();
            label4 = new Label();
            txtScore = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnQuery = new Button();
            btnShow = new Button();
            lstStudents = new ListBox();
            btnHideListbox = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 68);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "姓名";
            // 
            // txtName
            // 
            txtName.Location = new Point(129, 62);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 105);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 2;
            label2.Text = "年龄";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(129, 105);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 148);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 4;
            label3.Text = "性别";
            // 
            // txtGender
            // 
            txtGender.Location = new Point(129, 145);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(100, 23);
            txtGender.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 191);
            label4.Name = "label4";
            label4.Size = new Size(32, 17);
            label4.TabIndex = 6;
            label4.Text = "成绩";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(129, 188);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(100, 23);
            txtScore.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(46, 306);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "添加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(154, 306);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(261, 306);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(364, 306);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(75, 23);
            btnQuery.TabIndex = 11;
            btnQuery.Text = "查询";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(465, 306);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 12;
            btnShow.Text = "显示";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // lstStudents
            // 
            lstStudents.FormattingEnabled = true;
            lstStudents.ItemHeight = 17;
            lstStudents.Location = new Point(251, 62);
            lstStudents.Name = "lstStudents";
            lstStudents.Size = new Size(437, 208);
            lstStudents.TabIndex = 13;
            // 
            // btnHideListbox
            // 
            btnHideListbox.Location = new Point(564, 306);
            btnHideListbox.Name = "btnHideListbox";
            btnHideListbox.Size = new Size(75, 23);
            btnHideListbox.TabIndex = 14;
            btnHideListbox.Text = "隐藏";
            btnHideListbox.UseVisualStyleBackColor = true;
            btnHideListbox.Click += btnHideListbox_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 15;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(115, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "加载";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // button1
            // 
            button1.Location = new Point(613, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 17;
            button1.Text = "注销账户";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLogout_Click;
            // 
            // button2
            // 
            button2.Location = new Point(713, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 18;
            button2.Text = "登录账户";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnLogin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnHideListbox);
            Controls.Add(lstStudents);
            Controls.Add(btnShow);
            Controls.Add(btnQuery);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtScore);
            Controls.Add(label4);
            Controls.Add(txtGender);
            Controls.Add(label3);
            Controls.Add(txtAge);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtAge;
        private Label label3;
        private TextBox txtGender;
        private Label label4;
        private TextBox txtScore;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnQuery;
        private Button btnShow;
        private ListBox lstStudents;
        private Button btnHideListbox;
        private Button btnSave;
        private Button btnLoad;
        private Button button1;
        private Button button2;
    }
}