using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField id_UI;
    public TMP_InputField password_UI;

    public TextMeshProUGUI notify;

    void Start()
    {
        this.notify.text = string.Empty;
    }

    public void SaveUserData()
    {
        if (!CheckInput(this.id_UI.text, this.password_UI.text))
        {
            return;
        }


        if (!PlayerPrefs.HasKey(this.id_UI.text)) // 현재 로컬 저장된 키 중에 동일한 id가 없다면
        {
            PlayerPrefs.SetString(id_UI.text, password_UI.text);
            this.notify.text = "아이디 생성이 완료되었습니다.";
        }
        else
        {
            this.notify.text = "동일한 ID가 존재합니다.";
        }
    }

    public void CheckUserData()
    {
        if (!CheckInput(this.id_UI.text, this.password_UI.text))
        {
            return;
        }

        string pass = PlayerPrefs.GetString(id_UI.text);

        if (pass == password_UI.text)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            this.notify.text = "입력하신 아이디와 패스워드가 일치하지 않습니다.";
        }
    }

    private bool CheckInput(string param_id, string param_pw)
    {
        if (param_id == "" || param_pw == "")
        {
            return false;
        }
        else
            return true;
    }
}
