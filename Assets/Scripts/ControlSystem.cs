﻿using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 3.5f;
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

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(h, v) * speed;

        ani.SetBool(parWalk, h != 0 || v != 0);

        if (h > 0)
        {
            print("右邊");
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (h < 0)
        {
            print("左邊");
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
