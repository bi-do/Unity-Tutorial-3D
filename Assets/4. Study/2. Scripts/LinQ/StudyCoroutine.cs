using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    private IEnumerator enumerator1;

    void Start()
    {
       enumerator1 = Numbers();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumerator1.MoveNext();
            object ob = enumerator1.Current;

            Debug.Log(ob);
        }
        ;
    
    }

    IEnumerator Numbers()
    {

        yield return 3;

        yield return 5;

        yield return 7;


    }
}