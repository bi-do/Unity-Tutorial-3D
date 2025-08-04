using System;
using Unity.Android.Gradle.Manifest;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class StudyEventHandle : MonoBehaviour
{
    public class DataClass : EventArgs
    {
        public string name;
        public int level;
        public float hp;
        public float mp;
        public float dmg;

        public DataClass(string name, int level, float hp, float mp, float dmg)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.mp = mp;
            this.dmg = dmg;
        }
    }

    private event EventHandler handler;

    void Start()
    {
        handler += CreateCharacter;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DataClass data = new DataClass("A", 1, 2, 3, 4);
            this.handler?.Invoke(this, data);
        }
    }

    private void CreateCharacter(object o, EventArgs e)
    {
        DataClass data = (DataClass)e;

        Debug.Log($"{data.name} / {data.level}");
    }
}