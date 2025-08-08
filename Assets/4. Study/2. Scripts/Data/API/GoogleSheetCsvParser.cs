using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCsvParser : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string char_id;
        public string char_name;
        public int hp;
        public int atk_dmg;

        public CharacterData(string char_id, string char_name, int hp, int atk_dmg)
        {
            this.char_id = char_id;
            this.char_name = char_name;
            this.hp = hp;
            this.atk_dmg = atk_dmg;
        }
    }

    public List<CharacterData> char_datas = new List<CharacterData>();
    private string URL = "https://docs.google.com/spreadsheets/d/1MF0Ur9GjlZK6oe8nNbqrsk8BZQ3NeRJ8plYMGSn-6Cg/export?format=csv&range=A2:D5";

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TransperRoutine());
        }
    }

    IEnumerator TransperRoutine()
    {
        UnityWebRequest www = UnityWebRequest.Get(this.URL);

        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        Debug.Log(data);

        ParsingCharacterData(data);
    }

    private void ParsingCharacterData(string param_data)
    {
        Debug.Log(param_data);

        string[] rows = param_data.Split('\n');


        for (int i = 0; i < rows.Length; i++)
        {
            string[] cols = rows[i].Split(','); // CSV
            // string[] cols = rows[i].Split('\t'); // TSV

            CharacterData temp_data = new CharacterData(cols[0], cols[1],
                    int.Parse(cols[2] == string.Empty ? "0" : cols[2]), int.Parse(cols[3] == string.Empty ? "0" : cols[3]));

            this.char_datas.Add(temp_data);
        }
    }
}
