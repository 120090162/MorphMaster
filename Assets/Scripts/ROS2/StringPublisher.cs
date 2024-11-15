using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class StringPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "test_string";

    void Start()
    {
        // 初始化 ROS 连接
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<StringMsg>(topicName);

        // 设定定时发布消息
        InvokeRepeating("PublishStringMessage", 1.0f, 1.0f);
    }

    void PublishStringMessage()
    {
        // 创建一个简单的消息
        StringMsg msg = new StringMsg("Hello from Unity!");

        // 发布消息
        ros.Publish(topicName, msg);

        // 控制台输出调试信息
        Debug.Log("Published message to topic: " + topicName + " with data: " + msg.data);
    }
}
