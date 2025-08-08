using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLParser : MonoBehaviour
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
    [XmlRoot("Characters")]
    public class CharacterList
    {
        [XmlElement("Character")]
        public List<CharacterData> characters;
    }

    public List<CharacterData> character_datas = new List<CharacterData>();


    void Start()
    {
        TextAsset data = Resources.Load<TextAsset>("XML_Data");

        ParsingXML(data);
    }

    private void ParsingXML(TextAsset param_xml)
    {
        string data = param_xml.text;

        Debug.Log(data);

        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList load_data = (CharacterList)serializer.Deserialize(reader);
            this.character_datas = load_data.characters;
        }

        foreach (CharacterData element in this.character_datas)
        {
            Debug.Log($"{element.CharID} / {element.Name} / {element.HP} / {element.Attack}");
        }

    }
}