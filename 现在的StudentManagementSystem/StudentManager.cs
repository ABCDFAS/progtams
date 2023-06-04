using System;
using System.Collections.Generic;

//定义一个学生管理类
class StudentManager
{
    //定义一个私有的列表，用于存储学生对象
    private List<Student> students;

    //定义一个公有的属性，用于获取或设置列表
    public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

    //定义一个构造函数，用于初始化列表
    public StudentManager()
    {
        students = new List<Student>();
    }

    //定义一个方法，用于添加学生对象到列表中
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    //定义一个方法，用于删除列表中指定姓名的学生对象
    public void DeleteStudent(string name)
    {
        //遍历列表，找到匹配的学生对象
        foreach (Student student in students)
        {
            //如果姓名相同，删除该对象，并退出循环
            if (student.Name == name)
            {
                students.Remove(student);
                break;
            }
        }
    }

    //定义一个方法，用于修改列表中指定姓名的学生对象的成绩
    public void UpdateStudent(string name, double score)
    {
        //遍历列表，找到匹配的学生对象
        foreach (Student student in students)
        {
            //如果姓名相同，修改该对象的成绩，并退出循环
            if (student.Name == name)
            {
                student.Score = score;
                break;
            }
        }
    }

    //定义一个方法，用于查询列表中指定姓名的学生对象
    public Student QueryStudent(string name)
    {
        //遍历列表，找到匹配的学生对象
        foreach (Student student in students)
        {
            //如果姓名相同，返回该对象，并退出循环
            if (student.Name == name)
            {
                return student;
            }
        }
        //如果没有找到匹配的学生对象，返回null
        return null;
    }

    //定义一个方法，用于显示列表中所有学生对象的信息
    public void ShowStudents()
    {
        //遍历列表，打印每个学生对象的信息
        foreach (Student student in students)
        {
            Console.WriteLine("姓名：{0}，年龄：{1}，性别：{2}，成绩：{3}", student.Name, student.Age, student.Gender, student.Score);
        }
    }
}
