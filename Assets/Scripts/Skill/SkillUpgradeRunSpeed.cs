using UnityEngine;

public class SkillUpgradeRunSpeed : MonoBehaviour, ISkillUpgrade
{
    [SerializeField, Header("技能資料")]
    private DataSkill dataSkill;
    [SerializeField, Header("玩家資料")]
    private DataBasic dataPlayer;

    private void Awake()
    {
        dataSkill.lv = 1;
        dataPlayer.speed = dataSkill.skillValues[0];
    }

    public void SkillUpgrade()
    {
        int lv = dataSkill.lv - 1;
        dataPlayer.speed = dataSkill.skillValues[lv];
        // print($"<color=#f69>升級跑速，目前的跑速是：{dataPlayer.speed}</color>");
    }
}
