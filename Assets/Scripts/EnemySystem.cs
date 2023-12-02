using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour
{
    [Header("敵人資料")]
    public DataEnemy data;

    public Transform playerPoint;

    private DamagePlayer damagePlayer;
    private Animator ani;
    private bool canAttack = true;
    private string parAttack = "觸發攻擊";

    private void Awake()
    {
        playerPoint = GameObject.Find("玩家_黑貓").transform;
        damagePlayer = playerPoint.GetComponent<DamagePlayer>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        TrackPlayer();
        Flip();
    }

    private void TrackPlayer()
    {
        // 如果 敵人 與 玩家 距離 小於 3 就 跳出
        if (Vector2.Distance(transform.position, playerPoint.position) < data.attackDistance)
        {
            if (canAttack) Attack();
            return;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, playerPoint.position, data.speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > playerPoint.position.x) transform.eulerAngles = Vector2.zero;
        else if (transform.position.x < playerPoint.position.x) transform.eulerAngles = new Vector2(0, 180);
    }

    private void Attack()
    {
        canAttack = false;
        StartCoroutine(AttackEffect());
    }

    private IEnumerator AttackEffect()
    {
        ani.SetTrigger(parAttack);
        yield return new WaitForSeconds(data.attackSendTime);
        damagePlayer.Damage(data.attack);
        yield return new WaitForSeconds(data.attackInterval - data.attackSendTime);
        canAttack = true;
    }
}
