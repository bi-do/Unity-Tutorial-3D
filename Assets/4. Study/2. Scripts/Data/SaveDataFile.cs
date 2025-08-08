using System;
using System.IO;
using UnityEngine;
[Serializable]
public class CharacterData
{
    public string CharID = "";
    public string Name = "";
    public int HP;
    public int Attack;
    public int score;
}


public class SaveDataFile : MonoBehaviour
{
    private int cur_score;

    private string save_path;

    void Start()
    {
        // Application.datapath : Asset 폴더
        // Application.persistentDataPath : 플랫폼이 추천하는 로컬 저장소 path
        this.save_path = Path.Combine(Application.persistentDataPath, "SaveDataFile.json");

        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.cur_score++;

            Debug.Log($"현재 점수 : {this.cur_score}");

            Save();
        }
    }

    private void Save()
    {
        CharacterData data = new CharacterData();
        data.score = this.cur_score;

        string json = JsonUtility.ToJson(data ,true);
        File.WriteAllText(this.save_path, json);

        Debug.Log($"Data save path : {this.save_path}");
    }

    private void Load()
    {
        if (File.Exists(this.save_path))
        {
            string json = File.ReadAllText(this.save_path);
            CharacterData data_temp = JsonUtility.FromJson<CharacterData>(json);
            this.cur_score = data_temp.score;
        }
        else
            this.cur_score = 0;

    }

    void OnApplicationQuit()
    {
        Save();
    }
}
