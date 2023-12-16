using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;                      // 排序、條件設定
using System.Collections;
using System.Collections.Generic;       // 清單 List 資料結構 相對於陣列彈性

public class SkillManager : MonoBehaviour
{
    [SerializeField, Header("隨機技能面板")]
    private CanvasGroup groupSkill;
    [SerializeField, Header("按鈕技能物件 1 ~ 3")]
    private Transform[] objectSkill;
    [SerializeField, Header("全部的技能資料")]
    private DataSkill[] dataSkills;
    [SerializeField, Header("升級技能音效")]
    private AudioClip soundSkillLevelUp;

    [SerializeField]
    private List<DataSkill> randomSkills = new List<DataSkill>();

    [SerializeField, Header("按鈕技能 1 ~ 3")]
    private Button[] btnSkill;

    [SerializeField, Header("升級技能系統")]
    private GameObject[] skillUpgrades;
    [SerializeField, Header("按鈕全部升滿")]
    private Button btnAllSkillFull;

    private void Awake()
    {
        for (int i = 0; i < btnSkill.Length; i++)
        {
            int index = i;
            btnSkill[i].onClick.AddListener(() =>
            {
                for (int j = 0; j < dataSkills.Length; j++)
                {
                    // 如果按下的技能 等於 全部技能
                    // 處理該技能的升級功能
                    if (randomSkills[index] == dataSkills[j])
                    {
                        SoundManager.instance.PlaySound(soundSkillLevelUp, 1.3f, 2);
                        dataSkills[j].lv++;
                        skillUpgrades[j].GetComponent<ISkillUpgrade>().SkillUpgrade();
                        StartCoroutine(LevelUpHandle());
                    }
                }
            });
        }

        // 點擊所有技能全滿按鈕 淡出畫面 恢復原本時間
        btnAllSkillFull.onClick.AddListener(() =>
        {
            StartCoroutine(FadeInSkillUI(false));
            Time.timeScale = 1;
        });
    }

    private IEnumerator LevelUpHandle()
    {
        groupSkill.interactable = false;
        groupSkill.blocksRaycasts = false;
        yield return new WaitForSecondsRealtime(0.3f);
        UpdateSKillUI();
        yield return new WaitForSecondsRealtime(0.75f);
        Time.timeScale = 1;
        groupSkill.alpha = 0;
    }

    /// <summary>
    /// 升級後顯示技能介面
    /// </summary>
    public void LevelUpShowSkillUI()
    {
        Time.timeScale = 0;
        RandomSkill();
        StartCoroutine(FadeInSkillUI());
    }

    /// <summary>
    /// 淡入技能介面
    /// </summary>
    private IEnumerator FadeInSkillUI(bool fadeIn = true)
    {
        // 三元運算子
        // 布林值 ? 布林值等於 true : 布林值等於 false
        // true ? 1 : -1 結果：1
        // false ? 1 : -1 結果：-1

        float increase = fadeIn ? +0.1f : -0.1f;

        for (int i = 0; i < 10; i++)
        {
            groupSkill.alpha += increase;
            yield return new WaitForSecondsRealtime(0.035f);
        }

        groupSkill.interactable = fadeIn;
        groupSkill.blocksRaycasts = fadeIn;
    }

    private void RandomSkill()
    {
        randomSkills = dataSkills.Where(x => x.lv < 5).ToList();                        // 從 dataSkills 全部技能 拿出所有 等級 小於 5 的資料
        randomSkills = randomSkills.OrderBy(x => Random.Range(0, 999)).ToList();        // 將技能資料隨機排序

        UpdateSKillUI();
    }

    /// <summary>
    /// 更新技能介面
    /// </summary>
    private void UpdateSKillUI()
    {
        // 先隱藏全部的升級按鈕
        for (int i = 0; i < 3; i++)
        {
            objectSkill[i].gameObject.SetActive(false);
        }
        // 顯示隨機技能數量的按鈕
        for (int i = 0; i < randomSkills.Count && i < 3; i++)
        {
            objectSkill[i].gameObject.SetActive(true);
        }

        // 如果隨機技能數量 等於 0 (全部都升滿)
        if (randomSkills.Count == 0)
        {
            // 顯示全部升滿按鈕並且跳出
            btnAllSkillFull.gameObject.SetActive(true);
            return;
        }

        for (int i = 0; i < objectSkill.Length; i++)
        {
            // 如果 該技能按鈕是隱藏狀態 就跳出
            if (!objectSkill[i].gameObject.activeSelf) return;

            DataSkill dataSkill = randomSkills[i];
            objectSkill[i].Find("技能名稱").GetComponent<TextMeshProUGUI>().text = dataSkill.skillName;
            objectSkill[i].Find("技能描述").GetComponent<TextMeshProUGUI>().text = dataSkill.skillDescription;
            objectSkill[i].Find("技能圖片").GetComponent<Image>().sprite = dataSkill.skillPicture;

            for (int j = 0; j < 5; j++)
            {
                Color colorStar = objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color;
                colorStar.a = 0;
                objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color = colorStar;
            }

            for (int j = 0; j < dataSkill.lv; j++)
            {
                Color colorStar = objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color;
                colorStar.a = 1;
                objectSkill[i].Find("星星群組/星星 " + (j + 1)).GetComponent<Image>().color = colorStar;
            }
        }
    }
}
