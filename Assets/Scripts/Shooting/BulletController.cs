using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // 子弹的预制体
    public Transform firePoint; // 子弹的发射点
    public float bulletSpeed = 20f; // 子弹速度
    public float bulletLifetime = 10f; // 子弹存在的时间

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键发射子弹
        {
            Fire();
        }
    }

    void Fire()
    {

        //Debug.Log("bulletPrefab, firePoint");
        //if (bulletPrefab != null)
        //{
        //    Debug.Log("bulletPrefab missing");
        //}
        //if (firePoint != null)
        //{
        //    Debug.Log("firePoint missing");
        //}
        if (bulletPrefab != null && firePoint != null)
        {
            // 创建子弹实例
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // 获取子弹的刚体组件
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 给子弹施加向前的力
                rb.velocity = bullet.transform.forward * bulletSpeed;
            }

            // 设置子弹在10秒后销毁
            Destroy(bullet, bulletLifetime);
        }
        //else
        //{
        //    Debug.LogWarning("Bullet Prefab or Fire Point is not assigned!");
        //}
    }
}