using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class StudyEventHandler2 : MonoBehaviour
{
    public class DataClass : EventArgs
    {
        public string data_name;

        public DataClass(string param_name)
        {
            this.data_name = param_name;
        }
    }

    private EventHandler<DataClass> handler;


    void Start()
    {
        this.handler += MethodB;

        DataClass dataClass = new DataClass("Unity");
        handler?.Invoke(this, dataClass);

    }

    private void MethodB(object o, DataClass e)
    {
        Debug.Log(e.data_name);
    }


}