using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWindmill : MonoBehaviour
{
    public float rotationSpeed = 100f;  // �糵��ת�ٶ�
    public Transform centerPoint;  // �糵��ת����
    //private int bulletCollisionCount = 0;  // ��ײ������

    void Update()
    {
        // �÷糵���������ĵ���ת
        if (centerPoint != null)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    // ������ײ
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // ��ӡ��ײ����������
    //    Debug.Log("Collided with: " + collision.gameObject.name);
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        bulletCollisionCount++;  // ������ײ����
    //        Debug.Log("Bullet hit! Total count: " + bulletCollisionCount);
    //    }
    //}
}
