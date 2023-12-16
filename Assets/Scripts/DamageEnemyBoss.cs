using UnityEngine;

public class DamageEnemyBoss : DamageEnemy
{
    protected override void Dead()
    {
        base.Dead();
        GameManager.instance.StartGameOver("挑戰成功");
    }
}
