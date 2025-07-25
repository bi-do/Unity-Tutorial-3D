using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode { NORMAL, Sniper }
    private WeaponMode w_mode;

    public GameObject firePosition;
    public GameObject bombFactory;
    public GameObject bulletEffect;
    private ParticleSystem ps;
    private Animator anim;

    public GameObject weapon01_UI;
    public GameObject weapon02_UI;

    public GameObject crosshair01_UI;
    public GameObject crosshair02_UI;

    public GameObject weapon01_R_UI;
    public GameObject weapon02_R_UI;

    public TextMeshProUGUI w_mode_text_UI;
    public GameObject[] flash_effects;

    public float throwPower = 10f;
    public int weaponPower = 5;

    private bool zoom_mode;


    void Start()
    {
        anim = this.GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();

        this.w_mode = WeaponMode.NORMAL;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        LeftClick();
        RightClick();
        WeaponSwap();
    }

    private void RightClick()
    {
        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            switch (this.w_mode)
            {
                case WeaponMode.NORMAL: // Normal 모드일 시 폭탄 투척
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f)
                                * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper: // Sniper 모드일 시 마우스 우클릭 -> 확대/축소 조준경
                    Camera.main.fieldOfView = this.zoom_mode == true ? 60f : 15f;
                    this.zoom_mode = !this.zoom_mode;
                    break;
            }
        }
    }

    private void LeftClick()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            StartCoroutine(ShootEffectOn(0.05f));

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy")) // Raycast를 Enemy가 맞은 경우
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // Raycast를 맞은 대상이 Enemy가 아닌 경우
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }
            }
        }
    }

    private void WeaponSwap()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.w_mode = WeaponMode.NORMAL;
            Camera.main.fieldOfView = 60f;
            this.w_mode_text_UI.text = "Normal Mode";
            WeaponUIUpdate(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.w_mode = WeaponMode.Sniper;
            this.w_mode_text_UI.text = "Sniper Mode";
            WeaponUIUpdate(false);
        }

    }

    private void WeaponUIUpdate(bool isNormal)
    {
        this.weapon01_UI.SetActive(isNormal);
        this.weapon02_UI.SetActive(!isNormal);

        this.crosshair01_UI.SetActive(isNormal);
        this.crosshair02_UI.SetActive(!isNormal);

        this.weapon01_R_UI.SetActive(isNormal);
        this.weapon02_R_UI.SetActive(!isNormal);
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, flash_effects.Length);

        this.flash_effects[num].SetActive(true);

        yield return new WaitForSeconds(duration);

        this.flash_effects[num].SetActive(false);
    }
}