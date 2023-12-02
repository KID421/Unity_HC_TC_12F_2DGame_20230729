using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[DefaultExecutionOrder(200)]
public class DamagePlayer : DamageBasic
{
    [Header("血量圖片")]
    public Image imgHp;
    [Header("血量文字")]
    public TextMeshProUGUI textHp;
    [SerializeField, Header("結束畫面")]
    private CanvasGroup groupFinal;
    [SerializeField, Header("武器系統")]
    private WeaponSystem wepaonSystem;
    [SerializeField, Header("吃到具碰撞")]
    private CircleCollider2D circleCollider2D;
    [SerializeField, Header("受傷音效")]
    private AudioClip soundDamage;
    [SerializeField, Header("死亡音效")]
    private AudioClip soundDead;

    private ControlSystem controlSystem;

    protected override void Awake()
    {
        base.Awake();
        textHp.text = $"{hp} / {hpMax}";
        controlSystem = GetComponent<ControlSystem>();
    }

    public override void Damage(float damage)
    {
        if (hp <= 0) return;

        base.Damage(damage);

        SoundManager.instance.PlaySound(soundDamage, 1.2f, 2.5f);

        imgHp.fillAmount = hp / hpMax;

        // 血量 = 數學函式.夾住(血量，0，血量最大值)
        // 將血量夾在 0 ~ hpMax 之間
        hp = Mathf.Clamp(hp, 0, hpMax);
        textHp.text = $"{hp} / {hpMax}";
    }

    public void LevelUp()
    {
        hp = data.hp;
        hpMax = data.hp;
        imgHp.fillAmount = hp / hpMax;
        textHp.text = $"{hp} / {hpMax}";
    }

    protected override void Dead()
    {
        base.Dead();

        SoundManager.instance.PlaySound(soundDead, 1.8f, 3f);

        textHp.text = $"0 / {hpMax}";
        controlSystem.enabled = false;
        wepaonSystem.enabled = false;
        circleCollider2D.enabled = false;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        for (int i = 0; i < 10; i++)
        {
            groupFinal.alpha += 0.1f;
            yield return new WaitForSeconds(0.03f);
        }

        groupFinal.interactable = true;
        groupFinal.blocksRaycasts = true;
    }
}
