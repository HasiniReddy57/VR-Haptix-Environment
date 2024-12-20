// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Hands;
// using UnityEngine.XR;

// public class PokingManager : MonoBehaviour
// {
//     private XRHandSubsystem handSubsystem;
//     private HashSet<GameObject> pokedCubes = new HashSet<GameObject>();

//     void Start()
//     {
//         // Get the XR Hand Subsystem
//         var subsystems = new List<XRHandSubsystem>();
//         SubsystemManager.GetSubsystems(subsystems);

//         if (subsystems.Count > 0)
//         {
//             handSubsystem = subsystems[0];
//         }
//         else
//         {
//             Debug.LogError("XR Hand Subsystem not found. Ensure XR Hands is set up correctly.");
//         }
//     }

//     void Update()
//     {
//         if (handSubsystem == null) return;

//         GameObject[] cubes = GameObject.FindGameObjectsWithTag("PokeableCube");

//         foreach (var cube in cubes)
//         {
//             if (!pokedCubes.Contains(cube))
//             {
//                 CheckAndHandlePoking(cube, handSubsystem.leftHand);
//                 CheckAndHandlePoking(cube, handSubsystem.rightHand);
//             }
//         }
//     }

//     void CheckAndHandlePoking(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     HandlePoking(cube);
//                     CalculateAndSendJointProximities(cube, hand);
//                     break;
//                 }
//             }
//         }
//     }

//     bool IsJointNearCube(Vector3 jointPosition, GameObject cube, float threshold)
//     {
//         return Vector3.Distance(jointPosition, cube.transform.position) <= threshold;
//     }

//     void HandlePoking(GameObject cube)
//     {
//         pokedCubes.Add(cube);
//         cube.GetComponent<CubeScript>().SetColor(Color.red); // Update cube color when poked
//     }

//     void CalculateAndSendJointProximities(GameObject cube, XRHand hand)
//     {
//         List<string> jointIds = new List<string>();

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     jointIds.Add($"{(hand.handedness == Handedness.Left ? "L" : "R")}_{jointID}");
//                 }
//             }
//         }

//         if (jointIds.Count > 0)
//         {
//             string data = string.Join(",", jointIds);
//             SendDataToESP32(data);
//         }
//     }

//     void SendDataToESP32(string data)
//     {
//         // Replace with your implementation for ESP32 communication.
//         Debug.Log($"Sending data to ESP32: {data}");
//     }
// }

// using UnityEngine;
// using UnityEngine.XR.Hands;
// using UnityEngine.XR;
// using TMPro;  // Only need TextMeshPro for UI
// using System.Collections.Generic;


// public class PokingManager : MonoBehaviour
// {
//     private XRHandSubsystem handSubsystem;
//     private HashSet<GameObject> pokedCubes = new HashSet<GameObject>();

//     // Reference to UI TextMeshPro to display joint information
//     public TMP_Text textComponent;  // Only use this for TextMeshPro

//     void Start()
//     {
//         // Get the XR Hand Subsystem
//         var subsystems = new List<XRHandSubsystem>();
//         SubsystemManager.GetSubsystems(subsystems);

//         if (subsystems.Count > 0)
//         {
//             handSubsystem = subsystems[0];
//         }
//         else
//         {
//             Debug.LogError("XR Hand Subsystem not found. Ensure XR Hands is set up correctly.");
//         }
//     }

//     void Update()
//     {
//         if (handSubsystem == null) return;

//         GameObject[] cubes = GameObject.FindGameObjectsWithTag("PokeableCube");

//         foreach (var cube in cubes)
//         {
//             if (!pokedCubes.Contains(cube))
//             {
//                 CheckAndHandlePoking(cube, handSubsystem.leftHand);
//                 CheckAndHandlePoking(cube, handSubsystem.rightHand);
//             }
//         }
//     }

//     void CheckAndHandlePoking(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     HandlePoking(cube);
//                     CalculateAndSendJointProximities(cube, hand);

//                     // Display joint information on the UI canvas
//                     DisplayJointInfo(jointID, pose.position, hand.handedness);
//                     break;
//                 }
//             }
//         }
//     }

//     bool IsJointNearCube(Vector3 jointPosition, GameObject cube, float threshold)
//     {
//         return Vector3.Distance(jointPosition, cube.transform.position) <= threshold;
//     }

//     void HandlePoking(GameObject cube)
//     {
//         pokedCubes.Add(cube);
//         cube.GetComponent<CubeScript>().SetColor(Color.red); // Update cube color when poked
//     }

//     void CalculateAndSendJointProximities(GameObject cube, XRHand hand)
//     {
//         List<string> jointIds = new List<string>();

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     jointIds.Add($"{(hand.handedness == Handedness.Left ? "L" : "R")}_{jointID}");
//                 }
//             }
//         }

//         if (jointIds.Count > 0)
//         {
//             string data = string.Join(",", jointIds);
//             SendDataToESP32(data);
//         }
//     }

//     void SendDataToESP32(string data)
//     {
//         // Replace with your implementation for ESP32 communication.
//         Debug.Log($"Sending data to ESP32: {data}");
//     }

//     // Display joint info on the UI canvas
//     void DisplayJointInfo(XRHandJointID jointID, Vector3 jointPosition, Handedness handedness)
//     {
//         string jointSide = handedness == Handedness.Left ? "Left" : "Right";
//         string jointInfo = $"Joint: {jointSide} {jointID}\nPosition: {jointPosition}";
        
//         // Update the UI text
//         if (textComponent != null)
//         {
//             textComponent.text = jointInfo;
//         }
//     }
// }

// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Hands;
// using UnityEngine.XR;
// using TMPro;

// public class PokingManager : MonoBehaviour
// {
//     private XRHandSubsystem handSubsystem;
//     private HashSet<GameObject> pokedCubes = new HashSet<GameObject>();
//     private HashSet<GameObject> grabbedCubes = new HashSet<GameObject>(); // Track grabbed cubes

//     // Reference to TMP_Text to display joint information
//     public TMP_Text textComponent; // Assign this in the Inspector

//     void Start()
//     {
//         // Get the XR Hand Subsystem
//         var subsystems = new List<XRHandSubsystem>();
//         SubsystemManager.GetSubsystems(subsystems);

//         if (subsystems.Count > 0)
//         {
//             handSubsystem = subsystems[0];
//         }
//         else
//         {
//             Debug.LogError("XR Hand Subsystem not found. Ensure XR Hands is set up correctly.");
//         }
//     }

//     void Update()
//     {
//         if (handSubsystem == null) return;

//         GameObject[] cubes = GameObject.FindGameObjectsWithTag("PokeableCube");

//         foreach (var cube in cubes)
//         {
//             if (!pokedCubes.Contains(cube))
//             {
//                 CheckAndHandlePoking(cube, handSubsystem.leftHand);
//                 CheckAndHandlePoking(cube, handSubsystem.rightHand);
//             }
//         }

//         // For grabbable cubes, check continuously for hand contact
//         GameObject[] grabbableCubes = GameObject.FindGameObjectsWithTag("GrabbableCube");

//         foreach (var cube in grabbableCubes)
//         {
//             // Check if the cube is currently grabbed and if so, continue tracking joints
//             if (grabbedCubes.Contains(cube))
//             {
//                 TrackAndDisplayGrabbedCubeJoints(cube, handSubsystem.leftHand);
//                 TrackAndDisplayGrabbedCubeJoints(cube, handSubsystem.rightHand);
//             }
//             else
//             {
//                 // Check if the hand is in contact with the cube and "grab" it
//                 CheckAndHandleGrab(cube, handSubsystem.leftHand);
//                 CheckAndHandleGrab(cube, handSubsystem.rightHand);
//             }
//         }
//     }

//     void CheckAndHandlePoking(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         List<string> jointInfoList = new List<string>(); // List to store joint info strings

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     // Add joint info to the list
//                     string jointSide = hand.handedness == Handedness.Left ? "Left" : "Right";
//                     string jointInfo = $"{jointSide} {jointID}: {pose.position}";
//                     jointInfoList.Add(jointInfo);

//                     HandlePoking(cube);
//                     CalculateAndSendJointProximities(cube, hand);
//                 }
//             }
//         }

//         // Display all joint info on the TMP_Text
//         DisplayJointInfo(jointInfoList);
//     }

//     void CheckAndHandleGrab(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     // Add cube to grabbed cubes set
//                     if (!grabbedCubes.Contains(cube))
//                     {
//                         grabbedCubes.Add(cube);
//                     }
//                     break;
//                 }
//             }
//         }
//     }

//     void TrackAndDisplayGrabbedCubeJoints(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         List<string> jointInfoList = new List<string>(); // List to store joint info strings

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     // Add joint info to the list
//                     string jointSide = hand.handedness == Handedness.Left ? "Left" : "Right";
//                     string jointInfo = $"{jointSide} {jointID}: {pose.position}";
//                     jointInfoList.Add(jointInfo);
//                 }
//             }
//         }

//         // Display all joint info on the TMP_Text
//         DisplayJointInfo(jointInfoList);
//     }

//     bool IsJointNearCube(Vector3 jointPosition, GameObject cube, float threshold)
//     {
//         return Vector3.Distance(jointPosition, cube.transform.position) <= threshold;
//     }

//     void HandlePoking(GameObject cube)
//     {
//         pokedCubes.Add(cube);
//         cube.GetComponent<CubeScript>().SetColor(Color.red); // Update cube color when poked
//     }

//     void CalculateAndSendJointProximities(GameObject cube, XRHand hand)
//     {
//         List<string> jointIds = new List<string>();

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     jointIds.Add($"{(hand.handedness == Handedness.Left ? "L" : "R")}_{jointID}");
//                 }
//             }
//         }

//         if (jointIds.Count > 0)
//         {
//             string data = string.Join(",", jointIds);
//             SendDataToESP32(data);
//         }
//     }

//     void SendDataToESP32(string data)
//     {
//         // Replace with your implementation for ESP32 communication.
//         Debug.Log($"Sending data to ESP32: {data}");
//     }

//     // Display joint info on the TMP_Text component
//     void DisplayJointInfo(List<string> jointInfoList)
//     {
//         if (jointInfoList.Count > 0)
//         {
//             string jointInfoText = string.Join(", ", jointInfoList); // Join all joint info with commas
//             // Update the TMP_Text component with the joint info
//             if (textComponent != null)
//             {
//                 textComponent.text = jointInfoText;
//             }
//         }
//     }
// }


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR;
using TMPro;
using System.Net.Sockets;
using System.Text;

public class PokingManager : MonoBehaviour
{
    private XRHandSubsystem handSubsystem;
    private HashSet<GameObject> pokedCubes = new HashSet<GameObject>();

    // TCP connection variables
    private TcpClient client;
    private NetworkStream stream;

    // TCP server IP and port
    public string serverIP = "192.168.120.143"; // Replace with your ESP32's IP
    public int serverPort = 8080; // Replace with your ESP32's port

    // Define a dictionary for the right-hand joint mapping
    private static readonly Dictionary<XRHandJointID, int> rightHandJointMapping = new Dictionary<XRHandJointID, int>
    {
        { XRHandJointID.Wrist, 1 },
        { XRHandJointID.Palm, 2 },
        { XRHandJointID.ThumbMetacarpal, 4 },
        { XRHandJointID.ThumbProximal, 5 },
        { XRHandJointID.ThumbDistal, 6 },
        { XRHandJointID.ThumbTip, 7 },
        { XRHandJointID.IndexMetacarpal, 9 },
        { XRHandJointID.IndexProximal, 10 },
        { XRHandJointID.IndexIntermediate, 11 },
        { XRHandJointID.IndexDistal, 12 },
        { XRHandJointID.IndexTip, 13 },
        { XRHandJointID.MiddleMetacarpal, 15 },
        { XRHandJointID.MiddleProximal, 16 },
        { XRHandJointID.MiddleIntermediate, 17 },
        { XRHandJointID.MiddleDistal, 18 },
        { XRHandJointID.MiddleTip, 19 },
        { XRHandJointID.RingMetacarpal, 21 },
        { XRHandJointID.RingProximal, 22 },
        { XRHandJointID.RingIntermediate, 23 },
        { XRHandJointID.RingDistal, 24 },
        { XRHandJointID.RingTip, 25 },
        { XRHandJointID.LittleMetacarpal, 27 },
        { XRHandJointID.LittleProximal, 28 },
        { XRHandJointID.LittleIntermediate, 29 },
        { XRHandJointID.LittleDistal, 30 },
        { XRHandJointID.LittleTip, 31 }
    };

    void Start()
    {
        // Get the XR Hand Subsystem
        var subsystems = new List<XRHandSubsystem>();
        SubsystemManager.GetSubsystems(subsystems);

        if (subsystems.Count > 0)
        {
            handSubsystem = subsystems[0];
        }
        else
        {
            Debug.LogError("XR Hand Subsystem not found. Ensure XR Hands is set up correctly.");
        }

        // Establish a TCP connection to the ESP32
        ConnectToESP32();
    }

    void Update()
    {
        if (handSubsystem == null) return;

        GameObject[] cubes = GameObject.FindGameObjectsWithTag("PokeableCube");

        foreach (var cube in cubes)
        {
            if (!pokedCubes.Contains(cube))
            {
                CheckAndHandlePoking(cube, handSubsystem.rightHand); // Only track the right hand
            }
        }
    }

    void OnDestroy()
    {
        // Close the TCP connection when the application stops
        CloseConnection();
    }

    void ConnectToESP32()
    {
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            Debug.Log("Connected to ESP32.");
        }
        catch (SocketException ex)
        {
            Debug.LogError($"Failed to connect to ESP32: {ex.Message}");
        }
    }

    void CloseConnection()
    {
        if (stream != null)
        {
            stream.Close();
            stream = null;
        }
        if (client != null)
        {
            client.Close();
            client = null;
        }
        Debug.Log("Disconnected from ESP32.");
    }

    void CheckAndHandlePoking(GameObject cube, XRHand hand)
    {
        if (hand == null || !hand.isTracked) return;

        foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
        {
            XRHandJoint joint = hand.GetJoint(jointID);

            if (joint.TryGetPose(out Pose pose))
            {
                if (IsJointNearCube(pose.position, cube, 0.05f))
                {
                    HandlePoking(cube);
                    CalculateAndSendJointProximities(cube, hand);
                }
            }
        }
    }

    bool IsJointNearCube(Vector3 jointPosition, GameObject cube, float threshold)
    {
        return Vector3.Distance(jointPosition, cube.transform.position) <= threshold;
    }

    void HandlePoking(GameObject cube)
    {
        pokedCubes.Add(cube);
        cube.GetComponent<CubeScript>().SetColor(Color.red); // Update cube color when poked
    }

    void CalculateAndSendJointProximities(GameObject cube, XRHand hand)
    {
        if (hand == null || hand.handedness != Handedness.Right) return; // Only process right-hand joints

        List<string> jointIds = new List<string>();

        foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
        {
            XRHandJoint joint = hand.GetJoint(jointID);

            if (joint.TryGetPose(out Pose pose))
            {
                if (IsJointNearCube(pose.position, cube, 0.05f))
                {
                    if (rightHandJointMapping.TryGetValue(jointID, out int jointNumber))
                    {
                        jointIds.Add($"R_{jointNumber}");
                    }
                }
            }
        }

        if (jointIds.Count > 0)
        {
            string data = string.Join(";", jointIds); // Format the data as "R_1;R_2;..."
            SendDataToESP32(data);
        }
    }

    void SendDataToESP32(string data)
    {
        if (stream == null || !stream.CanWrite) return;

        try
        {
            byte[] message = Encoding.ASCII.GetBytes(data);
            stream.Write(message, 0, message.Length);
            Debug.Log($"Sent data to ESP32: {data}");
        }
        catch (SocketException ex)
        {
            Debug.LogError($"Error sending data to ESP32: {ex.Message}");
        }
    }
}

// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Hands;
// using UnityEngine.XR;
// using System.Net.Sockets;
// using System.Text;

// public class PokingManager : MonoBehaviour
// {
//     private XRHandSubsystem handSubsystem;
//     private HashSet<GameObject> pokedCubes = new HashSet<GameObject>();
//     private HashSet<GameObject> grabbableCubes = new HashSet<GameObject>();

//     // TCP connection variables
//     private TcpClient client;
//     private NetworkStream stream;

//     // TCP server IP and port
//     public string serverIP = "192.168.0.101"; // Replace with your ESP32's IP
//     public int serverPort = 8080; // Replace with your ESP32's port

//     // Define a dictionary for the right-hand joint mapping
//     private static readonly Dictionary<XRHandJointID, int> rightHandJointMapping = new Dictionary<XRHandJointID, int>
//     {
//         { XRHandJointID.Wrist, 1 },
//         { XRHandJointID.Palm, 2 },
//         { XRHandJointID.ThumbMetacarpal, 4 },
//         { XRHandJointID.ThumbProximal, 5 },
//         { XRHandJointID.ThumbDistal, 6 },
//         { XRHandJointID.ThumbTip, 7 },
//         { XRHandJointID.IndexMetacarpal, 9 },
//         { XRHandJointID.IndexProximal, 10 },
//         { XRHandJointID.IndexIntermediate, 11 },
//         { XRHandJointID.IndexDistal, 12 },
//         { XRHandJointID.IndexTip, 13 },
//         { XRHandJointID.MiddleMetacarpal, 15 },
//         { XRHandJointID.MiddleProximal, 16 },
//         { XRHandJointID.MiddleIntermediate, 17 },
//         { XRHandJointID.MiddleDistal, 18 },
//         { XRHandJointID.MiddleTip, 19 },
//         { XRHandJointID.RingMetacarpal, 21 },
//         { XRHandJointID.RingProximal, 22 },
//         { XRHandJointID.RingIntermediate, 23 },
//         { XRHandJointID.RingDistal, 24 },
//         { XRHandJointID.RingTip, 25 },
//         { XRHandJointID.LittleMetacarpal, 27 },
//         { XRHandJointID.LittleProximal, 28 },
//         { XRHandJointID.LittleIntermediate, 29 },
//         { XRHandJointID.LittleDistal, 30 },
//         { XRHandJointID.LittleTip, 31 }
//     };

//     void Start()
//     {
//         // Get the XR Hand Subsystem
//         var subsystems = new List<XRHandSubsystem>();
//         SubsystemManager.GetSubsystems(subsystems);

//         if (subsystems.Count > 0)
//         {
//             handSubsystem = subsystems[0];
//         }
//         else
//         {
//             Debug.LogError("XR Hand Subsystem not found. Ensure XR Hands is set up correctly.");
//         }

//         // Establish a TCP connection to the ESP32
//         ConnectToESP32();
//     }

//     void Update()
//     {
//         if (handSubsystem == null) return;

//         GameObject[] pokeableCubes = GameObject.FindGameObjectsWithTag("PokeableCube");
//         GameObject[] grabbableCubes1 = GameObject.FindGameObjectsWithTag("GrabbableCube1");

//         foreach (var cube in pokeableCubes)
//         {
//             if (!pokedCubes.Contains(cube))
//             {
//                 CheckAndHandlePoking(cube, handSubsystem.rightHand); // Only track the right hand
//             }
//         }

//         foreach (var cube in grabbableCubes1)
//         {
//             if (!grabbableCubes.Contains(cube))
//             {
//                 CheckAndHandleGrabbing(cube, handSubsystem.rightHand); // Handle GrabbableCube1
//             }
//         }
//     }

//     void OnDestroy()
//     {
//         // Close the TCP connection when the application stops
//         CloseConnection();
//     }

//     void ConnectToESP32()
//     {
//         try
//         {
//             client = new TcpClient(serverIP, serverPort);
//             stream = client.GetStream();
//             Debug.Log("Connected to ESP32.");
//         }
//         catch (SocketException ex)
//         {
//             Debug.LogError($"Failed to connect to ESP32: {ex.Message}");
//         }
//     }

//     void CloseConnection()
//     {
//         if (stream != null)
//         {
//             stream.Close();
//             stream = null;
//         }
//         if (client != null)
//         {
//             client.Close();
//             client = null;
//         }
//         Debug.Log("Disconnected from ESP32.");
//     }

//     void CheckAndHandlePoking(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     HandlePoking(cube);
//                     CalculateAndSendJointProximities(cube, hand, "low");
//                 }
//             }
//         }
//     }

//     void CheckAndHandleGrabbing(GameObject cube, XRHand hand)
//     {
//         if (hand == null || !hand.isTracked) return;

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     HandleGrabbing(cube);
//                     CalculateAndSendJointProximities(cube, hand, "high");
//                 }
//             }
//         }
//     }

//     bool IsJointNearCube(Vector3 jointPosition, GameObject cube, float threshold)
//     {
//         return Vector3.Distance(jointPosition, cube.transform.position) <= threshold;
//     }

//     void HandlePoking(GameObject cube)
//     {
//         pokedCubes.Add(cube);
//     }

//     void HandleGrabbing(GameObject cube)
//     {
//         grabbableCubes.Add(cube);
//     }

//     void CalculateAndSendJointProximities(GameObject cube, XRHand hand, string tag)
//     {
//         if (hand == null || hand.handedness != Handedness.Right) return; // Only process right-hand joints

//         List<string> jointIds = new List<string>();

//         foreach (XRHandJointID jointID in System.Enum.GetValues(typeof(XRHandJointID)))
//         {
//             XRHandJoint joint = hand.GetJoint(jointID);

//             if (joint.TryGetPose(out Pose pose))
//             {
//                 if (IsJointNearCube(pose.position, cube, 0.05f))
//                 {
//                     if (rightHandJointMapping.TryGetValue(jointID, out int jointNumber))
//                     {
//                         jointIds.Add($"R_{jointNumber},{tag}");
//                     }
//                 }
//             }
//         }

//         if (jointIds.Count > 0)
//         {
//             string data = string.Join(";", jointIds); // Format the data as "R_1,tag;R_2,tag;..."
//             SendDataToESP32(data);
//         }
//     }

//     void SendDataToESP32(string data)
//     {
//         if (stream == null || !stream.CanWrite) return;

//         try
//         {
//             byte[] message = Encoding.ASCII.GetBytes(data);
//             stream.Write(message, 0, message.Length);
//             Debug.Log($"Sent data to ESP32: {data}");
//         }
//         catch (SocketException ex)
//         {
//             Debug.LogError($"Error sending data to ESP32: {ex.Message}");
//         }
//     }
// }
