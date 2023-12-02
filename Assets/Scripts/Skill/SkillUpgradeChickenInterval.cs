using UnityEngine;

public class SkillUpgradeChickenInterval : MonoBehaviour, ISkillUpgrade
{
    [SerializeField, Header("技能資料")]
    private DataSkill dataSkill;
    [SerializeField, Header("炸雞武器系統")]
    private WeaponSystem weaponSystem;

    private void Awake()
    {
        dataSkill.lv = 1;
    }

    public void SkillUpgrade()
    {
        int lv = dataSkill.lv - 1;
        weaponSystem.RestartSapwnWeapon();
    }
}
