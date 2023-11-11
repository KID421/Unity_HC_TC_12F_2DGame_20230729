using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour
{
    [SerializeField, Header("隨機技能面板")]
    private CanvasGroup groupSkill;
    [SerializeField, Header("按鈕技能物件 1 ~ 3")]
    private Transform[] objectSkill;
    [SerializeField, Header("全部的技能資料")]
    private DataSkill[] dataSkills;

    /// <summary>
    /// 升級後顯示技能介面
    /// </summary>
    public void LevelUpShowSkillUI()
    {
        Time.timeScale = 0;
        print("<color=#f69>升級並開啟技能介面</color>");
        StartCoroutine(FadeInSkillUI());
    }

    /// <summary>
    /// 淡入技能介面
    /// </summary>
    private IEnumerator FadeInSkillUI()
    {
        for (int i = 0; i < 10; i++)
        {
            groupSkill.alpha += 0.1f;
            yield return new WaitForSecondsRealtime(0.035f);
        }

        groupSkill.interactable = true;
        groupSkill.blocksRaycasts = true;
    }
}
