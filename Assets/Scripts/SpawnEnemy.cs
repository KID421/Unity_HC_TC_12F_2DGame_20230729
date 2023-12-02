using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("生成敵人間隔"), Range(0, 10)]
    public float interval = 3;
    [Header("敵人預製物")]
    public GameObject prefabEnemy;

    private void Awake()
    {
        InvokeRepeating("SpawnEnemyMethod", 0, interval);
    }

    private void SpawnEnemyMethod()
    {
        Instantiate(prefabEnemy, transform.position, transform.rotation);
    }

    /// <summary>
    /// 重新啟動生成敵人，更新間隔與敵人預製物
    /// </summary>
    /// <param name="_interval">新的間隔</param>
    /// <param name="_prefabEnemy">新的敵人</param>
    public void RestartSpawn(float _interval, GameObject _prefabEnemy)
    {
        CancelInvoke("SpawnEnemyMethod");
        interval = _interval;
        prefabEnemy = _prefabEnemy;
        InvokeRepeating("SpawnEnemyMethod", 0, interval);
    }

    /// <summary>
    /// 停止生成
    /// </summary>
    public void StopSpwan()
    {
        CancelInvoke("SpawnEnemyMethod");
    }
}
