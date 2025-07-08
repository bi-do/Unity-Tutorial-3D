using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World ";

    public string[] strings = new string[3] { "Hello", "Unity", "World" };

    void Start()
    {

        // Debug.Log(this.str1[0]); // H
        // Debug.Log(this.str1[2]); // l
        // Debug.Log(strings[0]); // Hello
        // Debug.Log(strings[2]); // World

        // Debug.Log(str1.Length); // 문자열의 길이 = 5
        // Debug.Log(str1.Trim()); // 앞뒤 공백 제거 
        // Debug.Log(str1.Trim('l')); // 앞뒤 문자 'l' 존재 시 제거

        // Debug.Log(str1.Contains('H')); // 문자 존재 확인
        // Debug.Log(str1.Contains("h"));
        // Debug.Log(str1.Contains("Hello"));

        // Debug.Log(str1.ToLower()); // 모든 문자열 소문자 전환
        // Debug.Log(str1.ToUpper()); // 모든 문자열 대문자 전환

        Debug.Log(str1.Replace("World", "Unity")); // 문자열 치환 ( 문자열 내 바꿀 단어 , 바꿀 단어를 대신 할 단어)
    }
}
