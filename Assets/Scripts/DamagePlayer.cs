using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(200)]
public class DamagePlayer : DamageBasic
{
    [Header("血量圖片")]
    public Image imgHp;
    [Header("血量文字")]
    public TextMeshProUGUI textHp;

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

        imgHp.fillAmount = hp / hpMax;
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
        textHp.text = $"0 / {hpMax}";
        controlSystem.enabled = false;
    }
}
