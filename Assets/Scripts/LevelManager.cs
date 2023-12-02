using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("經驗值圖片")]
    public Image imgExp;
    [Header("等級文字")]
    public TextMeshProUGUI textLv;
    [SerializeField, Header("升級音效")]
    private AudioClip soundLevelUp;

    private int lv = 1;
    private float expCurrent;
    private float expNeed = 100;

    private SkillManager skillManager;

    public float[] expNeeds;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    /* 練習程式
    private void Awake()
    {
        // 取得陣列資料
        print($"第三等的經驗需求：{expNeeds[2]}");

        // 設定陣列資料
        expNeeds[0] = 110;

        // for 迴圈
        for (int i = 0; i < 10; i++)
        {
            print($"<color=#f69>迴圈的 i 值：{i}</color>");
        }

        for (int i = 0; i < 3; i++)
        {
            expNeeds[i] = (i + 1) * 1000;
        }
    }
    */

    [ContextMenu("建立經驗需求資料")]
    private void CreateExpNeedsData()
    {
        expNeeds = new float[100];

        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    /// <summary>
    /// 添加經驗值並且更新經驗值介面
    /// </summary>
    /// <param name="exp">要添加的經驗值</param>
    public void AddExp(float exp)
    {
        expCurrent += exp;
        imgExp.fillAmount = expCurrent / expNeed;

        if (expCurrent >= expNeed) LevelUp();
    }

    /// <summary>
    /// 升級
    /// </summary>
    private void LevelUp()
    {
        SoundManager.instance.PlaySound(soundLevelUp, 2.2f, 3);
        lv++;
        textLv.text = "Lv " + lv;
        expCurrent -= expNeed;
        expNeed = expNeeds[lv - 1];
        imgExp.fillAmount = expCurrent / expNeed;
        skillManager.LevelUpShowSkillUI();
    }
}
