using UnityEngine;

public class SkillUpgradeChickenEatPropRange : MonoBehaviour, ISkillUpgrade
{
    [SerializeField, Header("技能資料")]
    private DataSkill dataSkill;
    [SerializeField, Header("玩家的吃到具圓形碰撞")]
    private CircleCollider2D circleCollider2D;

    private void Awake()
    {
        dataSkill.lv = 1;
    }

    public void SkillUpgrade()
    {
        int lv = dataSkill.lv - 1;
        circleCollider2D.radius = dataSkill.skillValues[lv];
    }
}
