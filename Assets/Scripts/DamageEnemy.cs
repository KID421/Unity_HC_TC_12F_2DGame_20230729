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

    private void Start()
    {
        dataEnemy = (DataEnemy)data;
    }

    protected override void Dead()
    {
        base.Dead();

        float random = Random.value;
        print($"<color=#66f>隨機值：{random}</color>");

        if (random <= dataEnemy.expProbability)
        {
            Instantiate(dataEnemy.expPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
