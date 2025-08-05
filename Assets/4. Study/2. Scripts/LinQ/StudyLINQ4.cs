using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudyLINQ4 : MonoBehaviour
{
    [Serializable]
    public class Student
    {
        public int student_ID;
        public string student_name;

        public Student(int param_ID, string param_name)
        {
            this.student_ID = param_ID;
            this.student_name = param_name;
        }
    }

    [Serializable]
    public class Grade
    {
        public int student_ID;
        public int score;
        public string subject;

        public Grade(int param_ID, int param_score, string param_subject)
        {
            this.student_ID = param_ID;
            this.score = param_score;
            this.subject = param_subject;
        }
    }

    public List<Student> students = new List<Student>();
    public List<Grade> grades = new List<Grade>();

    void Start()
    {
        #region 데이터 추가

        students.Add(new Student(1, "Alice"));
        students.Add(new Student(2, "Bob"));
        students.Add(new Student(3, "Eve"));
        students.Add(new Student(4, "Cony"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        #endregion
        InnerJoin();
    }

    private void InnerJoin()
    {
        var inner_join = from student in students
                         join grade in grades
                         on student.student_ID equals grade.student_ID
                         select new
                         {
                             student_ID = student.student_ID,
                             student_name = student.student_name,
                             student_score = grade.score,
                             subject = grade.subject
                         };

        foreach (var element in inner_join)
        {
            Debug.Log($"ID : {element.student_ID} / name : {element.student_name} / Subject : {element.subject} / Score : {element.student_score}");
        }
    }
}