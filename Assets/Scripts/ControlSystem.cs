using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [SerializeField, Header("玩家資料")]
    private DataBasic dataPlayer;
    
    [Header("剛體")]
    public Rigidbody2D rig;
    [Header("動畫控制器")]
    public Animator ani;

    private string parWalk = "開關走路";

    private void Awake()
    {
        // print("<color=#f96>喚醒事件</color>");
    }

    private void Start()
    {
        // print("<color=#9f6>開始事件</color>");
    }

    private void Update()
    {
        // print("<color=#96f>更新事件</color>");

        Move();
    }

    private void OnDisable()
    {
        rig.velocity = Vector3.zero;
        ani.SetBool(parWalk, false);
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(h, v) * dataPlayer.speed;

        ani.SetBool(parWalk, h != 0 || v != 0);

        if (h > 0)
        {
            // print("右邊");
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (h < 0)
        {
            // print("左邊");
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
