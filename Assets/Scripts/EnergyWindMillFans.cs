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
        // ��ӡ��ײ����������
        //Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCollisionCount++;  // ������ײ����
            Debug.Log("Bullet hit! Total count: " + bulletCollisionCount);
        }
    }
}
