using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class StudyLINQ2 : MonoBehaviour
{
    [Serializable]
    public class Person
    {
        public string name;
        public int score;

        public Person(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
    public List<Person> persons = new List<Person>();
    public int cutline = 70;

    void Start()
    {
        this.persons.Add(new Person("Dex", 65));
        this.persons.Add(new Person("Kim", 80));
        this.persons.Add(new Person("Park", 95));
        this.persons.Add(new Person("Lee", 70));
        this.persons.Add(new Person("Kang", 50));

        CheckScore();
    }

    private void CheckScore()
    {
        // LINQ 사용 X
        // foreach (Person element in this.persons)
        // {
        //     if (element.score > cutline)
        //     {
        //         Debug.Log(element.name);
        //     }
        //     else
        //     {
        //         Debug.Log(element.name);
        //     }
        // }


        // LINQ 사용
        var pass_persons = persons.Where(p => p.score > this.cutline).Select(p => p);
        var fail_persons = persons.Except(pass_persons);

        foreach (Person element in pass_persons)
        {
            Debug.Log($"합격 : {element.name}");
        }
        foreach (Person element in fail_persons)
        {
            Debug.Log($"과락 : {element.name}");
        }

    }
}
