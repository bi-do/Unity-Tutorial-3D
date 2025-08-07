using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
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

    void Start()
    {
        // TextAsset data_file = Resources.Load<TextAsset>("CSV_Data"); // CSV
        TextAsset data_file = Resources.Load<TextAsset>("TSV_Data");  // TSV

        this.ParsingCharacterData(data_file.text);
    }

    // 
    private void ParsingCharacterData(string param_data)
    {
        Debug.Log(param_data);

        string[] rows = param_data.Split('\n');


        for (int i = 1; i < rows.Length; i++)
        {
            // string[] cols = rows[i].Split(','); CSV
            string[] cols = rows[i].Split('\t'); // TSV

            Debug.Log(cols.Length); // 열 개수 확인 

            CharacterData temp_data = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));

            this.char_datas.Add(temp_data);
        }
    }
}
