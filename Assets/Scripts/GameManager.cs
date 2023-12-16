using TMPro;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField, Header("結束畫面")]
    private CanvasGroup groupFinal;
    [SerializeField, Header("結束標題")]
    private TextMeshProUGUI textFinalTitle;

    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }

    /// <summary>
    /// 啟動遊戲結束協同程序
    /// </summary>
    public void StartGameOver(string finalTitle)
    {
        Time.timeScale = 0;
        textFinalTitle.text = finalTitle;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        for (int i = 0; i < 10; i++)
        {
            groupFinal.alpha += 0.1f;
            yield return new WaitForSecondsRealtime(0.03f);
        }

        groupFinal.interactable = true;
        groupFinal.blocksRaycasts = true;
    }
}
