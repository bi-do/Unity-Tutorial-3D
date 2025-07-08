using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(){}

    public PersonData(int param_age, string param_name, float param_height, float param_weight)
    {
        this.age = param_age;
        this.name = param_name;
        this.height = param_height;
        this.weight = param_weight;
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    void Start()
    {
        this.persons.Add("철수", new PersonData(10, "철수", 150f, 35f));
        this.persons.Add("동수", new PersonData(10, "동수", 150f, 35f));
        this.persons.Add("영희", new PersonData(10, "영희", 150f, 35f));

        
        Debug.Log(persons["철수"].age);
        Debug.Log(persons["철수"].name);
        Debug.Log(persons["철수"].height);
        Debug.Log(persons["철수"].weight);
}
    
}
