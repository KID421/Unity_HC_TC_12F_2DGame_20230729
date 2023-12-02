using UnityEngine;

public class DamageEnemy : DamageBasic
{
    #region 碰撞事件
    // 碰撞開始執行一次
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // print($"<color=#69f>碰到的物件：{collision.gameObject.name}</color>");

        if (collision.gameObject.name.Contains("武器")) 
            Damage(collision.gameObject.GetComponent<Weapon>().attack);
    }

    // 碰撞結束執行一次
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    // 碰撞持續時直行約 60 FPS
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    #endregion

    private DataEnemy dataEnemy;

    [SerializeField, Header("受傷音效")]
    private AudioClip soundDamage;
    [SerializeField, Header("死亡音效")]
    private AudioClip soundDead;

    private void Start()
    {
        dataEnemy = (DataEnemy)data;
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        SoundManager.instance.PlaySound(soundDamage, 1.5f, 2.2f);
    }

    protected override void Dead()
    {
        base.Dead();
        SoundManager.instance.PlaySound(soundDead, 1.5f, 2.2f);
        float random = Random.value;
        // print($"<color=#66f>隨機值：{random}</color>");

        if (random <= dataEnemy.expProbability)
        {
            Instantiate(dataEnemy.expPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
