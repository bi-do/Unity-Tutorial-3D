using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.Events;

public class StudyLINQ5 : MonoBehaviour
{
    public UnityAction act;


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
        students.Add(new Student(5, "Frank"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 85, "Science"));
        grades.Add(new Grade(3, 92, "English"));
        grades.Add(new Grade(4, 76, "Math"));
        grades.Add(new Grade(6, 90, "History"));
        #endregion
        OuterJoin();
    }

    private void OuterJoin()
    {
        var left_outer_join = from student in students
                              join grade in grades on student.student_ID equals grade.student_ID into student_grades
                              from grade in grades.DefaultIfEmpty()
                              select new
                              {
                                  student_ID = student.student_ID,
                                  student_name = student.student_name,
                                  subject = grade?.subject ?? "N/A",
                                  score = grade?.score ?? 0
                              };

        var right_outer_join = from grade in grades
                               join student in students on grade.student_ID equals student.student_ID into grade_students
                               from student in students.DefaultIfEmpty()
                               where student == null
                               select new
                               {
                                   student_ID = student.student_ID,
                                   student_name = "N/A",
                                   subject = grade?.subject ?? "N/A",
                                   score = grade.score 
                               };

        var outer_join = left_outer_join.Union(right_outer_join);

        foreach (var element in outer_join)
        {
            Debug.Log($"ID : {element.student_ID} / name : {element.student_name} / Subject : {element.subject} / Score : {element.score}");
        }



    }
}