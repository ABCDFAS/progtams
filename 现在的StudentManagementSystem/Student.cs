using System;
using System.Collections.Generic;

//定义一个学生类
class Student
{
    //定义学生的属性：姓名，年龄，性别，成绩
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public double Score { get; set; }

    //定义一个构造函数，用于初始化
    public Student(string name, int age, string gender, double score)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Score = score;
    }
}

