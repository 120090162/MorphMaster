using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.UnityRoboticsDemo;
using ROS2;

public class LidarPublisher : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "CameraMsg";
    // The game object
    public Camera cam;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.5f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<CameraMsg>(topicName);
        print("topic registered!");
        // find the camera in game
        cam = GameObject.Find(name + "/base_link/yaw_link/pitch_link/camera").GetComponent<Camera>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {
            //// Get timestamp
            //var timestamp = ros2Node.clock.Now().ToMsg();
            // Inverse Y axis
            var tmpRT = RenderTexture.GetTemporary(cam.targetTexture.descriptor);
            Graphics.Blit(cam.targetTexture, tmpRT, new Vector2(1, -1), new Vector2(0, 1));
            // Read the camera image from render texture
            var req = UnityEngine.Rendering.AsyncGPUReadback.Request(tmpRT);
            req.WaitForCompletion();
            // Convert to ROS2 message
            CameraMsg msg = new CameraMsg
            {
                frame_id = "camera_optical_frame",
                //stamp = timestamp;
                height = (uint)tmpRT.height,
                width = (uint)tmpRT.width,
                encoding = "rgb8",
                step = (uint)(tmpRT.width * 3),
            };
            ApplyData(ref msg, req.GetData<byte>().ToArray());
            Debug.Log("Preparing to publish message to topic: " + topicName);
            ros.Publish(topicName, msg);
            Debug.Log("Message published to topic: " + topicName);

            // Release the temporary render texture
            RenderTexture.ReleaseTemporary(tmpRT);

            timeElapsed = 0;
        }
    }
        private void ApplyData(ref CameraMsg msg, byte[] data)
    {
        // RGBA to RGB
        var rgbData = new byte[data.Length / 4 * 3];
        for (int i = 0; i < data.Length / 4; i++)
        {
            rgbData[i * 3] = data[i * 4];
            rgbData[i * 3 + 1] = data[i * 4 + 1];
            rgbData[i * 3 + 2] = data[i * 4 + 2];
        }
        msg.data = rgbData;
    }
}
