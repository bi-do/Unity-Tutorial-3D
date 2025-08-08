using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public string URL;

    void Start()
    {
        StartCoroutine(GetRoutine());   
    }

    IEnumerator GetRoutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(this.URL);

        yield return www.SendWebRequest();

        WWWForm form = new WWWForm();
        form.AddField("value", "123");

        UnityWebRequest www2 = UnityWebRequest.Post(this.URL,form);
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text;
        // string data2 = www2.downloadHandler.text;

        Debug.Log(data);
        // Debug.Log(data2);

    }
}