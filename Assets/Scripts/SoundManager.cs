using UnityEngine;

// 要求元件(元件類型)
// 在第一次套用此腳本時添加 (元件)
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource aud;

    private void Awake()
    {
        instance = this;

        // 取得此物件身上的 音效來源 元件
        aud = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 播放音效並且指定音效與隨機音量
    /// </summary>
    /// <param name="sound">要播放的音效</param>
    /// <param name="minVolume">最小音量</param>
    /// <param name="maxVolume">最大音量</param>
    public void PlaySound(AudioClip sound, float minVolume, float maxVolume)
    {
        // 隨機音量 = 最小值、最大值隨機
        float randomVolume = Random.Range(minVolume, maxVolume);
        // 音效來源 . 播放一次音效(音效，隨機音量)
        aud.PlayOneShot(sound, randomVolume);
    }
}
