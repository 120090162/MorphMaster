using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWindmill : MonoBehaviour
{
    public float rotationSpeed = 100f;  // 风车旋转速度
    public Transform centerPoint;  // 风车旋转中心
    //private int bulletCollisionCount = 0;  // 碰撞计数器

    void Update()
    {
        // 让风车物体绕中心点旋转
        if (centerPoint != null)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    // 处理碰撞
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // 打印碰撞的物体名称
    //    Debug.Log("Collided with: " + collision.gameObject.name);
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        bulletCollisionCount++;  // 增加碰撞计数
    //        Debug.Log("Bullet hit! Total count: " + bulletCollisionCount);
    //    }
    //}
}
