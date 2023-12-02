using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    private Transform pointPlayer;

    private void Awake()
    {
        pointPlayer = GameObject.Find("玩家_黑貓").transform;
    }

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        transform.position = pointPlayer.position;
    }
}
