﻿using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField, Header("炸雞武器技能資料")]
    private DataSkill dataSkill;
    [Header("武器預製物")]
    public GameObject prefabWeapon;
    [Header("武器發射力道")]
    public Vector2 v2Power = new Vector2(0, 100);
    [SerializeField, Header("丟武器音效")]
    private AudioClip soundThrow;

    private void Awake()
    {
        // SpawnWeapon();

        // 重複呼叫 SpawnWeapon 間隔為 interval
        int lv = dataSkill.lv - 1;
        InvokeRepeating("SpawnWeapon", 0, dataSkill.skillValues[lv]);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnWeapon");
    }

    private void SpawnWeapon()
    {
        SoundManager.instance.PlaySound(soundThrow, 1.5f, 2.3f);
        GameObject temp = Instantiate(prefabWeapon, transform.position, transform.rotation);
        temp.GetComponent<Rigidbody2D>().AddForce(v2Power * transform.right + new Vector2(0, v2Power.y));
    }

    public void RestartSapwnWeapon()
    {
        CancelInvoke("SpawnWeapon");
        int lv = dataSkill.lv - 1;
        InvokeRepeating("SpawnWeapon", 0, dataSkill.skillValues[lv]);
    }
}
