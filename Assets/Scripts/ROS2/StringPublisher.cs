using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class StringPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "test_string";

    void Start()
    {
        // ��ʼ�� ROS ����
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<StringMsg>(topicName);

        // �趨��ʱ������Ϣ
        InvokeRepeating("PublishStringMessage", 1.0f, 1.0f);
    }

    void PublishStringMessage()
    {
        // ����һ���򵥵���Ϣ
        StringMsg msg = new StringMsg("Hello from Unity!");

        // ������Ϣ
        ros.Publish(topicName, msg);

        // ����̨���������Ϣ
        Debug.Log("Published message to topic: " + topicName + " with data: " + msg.data);
    }
}
