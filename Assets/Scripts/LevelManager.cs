using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("�g��ȹϤ�")]
    public Image imgExp;
    [Header("���Ť�r")]
    public TextMeshProUGUI textLv;

    private int lv = 1;
    private float expCurrent;
    private float expNeed = 100;

    public float[] expNeeds;

    /* �m�ߵ{��
    private void Awake()
    {
        // ���o�}�C���
        print($"�ĤT�����g��ݨD�G{expNeeds[2]}");

        // �]�w�}�C���
        expNeeds[0] = 110;

        // for �j��
        for (int i = 0; i < 10; i++)
        {
            print($"<color=#f69>�j�骺 i �ȡG{i}</color>");
        }

        for (int i = 0; i < 3; i++)
        {
            expNeeds[i] = (i + 1) * 1000;
        }
    }
    */

    [ContextMenu("�إ߸g��ݨD���")]
    private void CreateExpNeedsData()
    {
        expNeeds = new float[100];

        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    /// <summary>
    /// �K�[�g��ȨåB��s�g��Ȥ���
    /// </summary>
    /// <param name="exp">�n�K�[���g���</param>
    public void AddExp(float exp)
    {
        expCurrent += exp;
        imgExp.fillAmount = expCurrent / expNeed;

        if (expCurrent >= expNeed) LevelUp();
    }

    /// <summary>
    /// �ɯ�
    /// </summary>
    private void LevelUp()
    {
        lv++;
        textLv.text = "Lv " + lv;
        expCurrent -= expNeed;
        expNeed = expNeeds[lv - 1];
        imgExp.fillAmount = expCurrent / expNeed;
    }
}
