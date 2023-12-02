using UnityEngine;

public class SkillUpgradeChickenAttack : MonoBehaviour, ISkillUpgrade
{
    [SerializeField, Header("技能資料")]
    private DataSkill dataSkill;
    [SerializeField, Header("武器攻擊力")]
    private Weapon weapon;

    private void Awake()
    {
        dataSkill.lv = 1;
        weapon.attack = dataSkill.skillValues[0];
    }

    public void SkillUpgrade()
    {
        int lv = dataSkill.lv - 1;
        weapon.attack = dataSkill.skillValues[lv];
    }
}
