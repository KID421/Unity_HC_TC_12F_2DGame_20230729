using UnityEngine;

[CreateAssetMenu(menuName = "KID/Data Wave", fileName = "Data Wave")]
public class DataWave : ScriptableObject
{
    [Header("敵人預製物")]
    public GameObject prefabEnemy;
    [Header("這波持續時間"), Range(0, 100)]
    public float duration = 3;
    [Header("敵人生成間隔"), Range(0, 30)]
    public float interval = 3;
}
