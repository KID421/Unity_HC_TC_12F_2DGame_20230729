using UnityEngine;

[DefaultExecutionOrder(100)]
public class SkillUpgradeHp : MonoBehaviour, ISkillUpgrade
{
    [SerializeField, Header("技能資料")]
    private DataSkill dataSkill;
    [SerializeField, Header("玩家資料")]
    private DataBasic dataPlayer;
    [SerializeField, Header("玩家受傷系統")]
    private DamagePlayer damagePlayer;

    private void Awake()
    {
        dataSkill.lv = 1;
        dataPlayer.hp = dataSkill.skillValues[0];
    }

    public void SkillUpgrade()
    {
        int lv = dataSkill.lv - 1;
        dataPlayer.hp = dataSkill.skillValues[lv];
        damagePlayer.LevelUp();
    }
}
