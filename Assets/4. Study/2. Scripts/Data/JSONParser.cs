using System;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser : MonoBehaviour
{
    [Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;
    }

    [Serializable]
    public class CharacterListWrapper
    {
        public List<CharacterData> characters;
    }

    public List<CharacterData> character_datas = new List<CharacterData>();

    void Start()
    {
        TextAsset data = Resources.Load<TextAsset>("JSON_Data");

        ParsingJSON(data);
    }

    void ParsingJSON(TextAsset param_json)
    {
        string data = param_json.text;

        CharacterListWrapper wrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach (CharacterData element in wrapper.characters)
        {
            Debug.Log($" {element.CharID} / {element.Name} /  {element.HP} / {element.Attack}");
            this.character_datas.Add(element);
        }
    }

}
