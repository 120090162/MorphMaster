using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // �ӵ���Ԥ����
    public Transform firePoint; // �ӵ��ķ����
    public float bulletSpeed = 20f; // �ӵ��ٶ�
    public float bulletLifetime = 10f; // �ӵ����ڵ�ʱ��

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �����������ӵ�
        {
            Debug.Log("000");
            Fire();
            
        }
    }

    void Fire()
    {

        Debug.Log("bulletPrefab, firePoint");

        if (bulletPrefab != null && firePoint != null)
        {
            // �����ӵ�ʵ��
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // ��ȡ�ӵ��ĸ������
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Debug.Log("111");
            if (rb != null)
            {
                // ���ӵ�ʩ����ǰ����
                rb.velocity = bullet.transform.forward * bulletSpeed;
                Debug.Log("222");
            }

            // �����ӵ���10�������
            Destroy(bullet, bulletLifetime);
        }
        else
        {
            Debug.LogWarning("Bullet Prefab or Fire Point is not assigned!");
        }
    }
}