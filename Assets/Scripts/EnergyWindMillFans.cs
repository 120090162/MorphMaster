using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWindMillFans : MonoBehaviour
{
    public static int bulletCollisionCount = 0;
    //private string gameObject
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        // 打印碰撞的物体名称
        //Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCollisionCount++;  // 增加碰撞计数
            Debug.Log("Bullet hit! Total count: " + bulletCollisionCount);
        }
    }
}
