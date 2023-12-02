using UnityEngine;

public class EatExpSystem : MonoBehaviour
{
    [SerializeField, Header("經驗音效")]
    private AudioClip soundExp;

    private string nameExp = "經驗值";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains(nameExp))
        {
            SoundManager.instance.PlaySound(soundExp, 2, 2.8f);
            collision.gameObject.GetComponent<ExpObject>().enabled = true;
        }
    }
}
