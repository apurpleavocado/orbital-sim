using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Mathematics;
using UnityEngine;
using System.Threading;
using System;
using System.Text;
public class PosDecoder : MonoBehaviour
{
    private static readonly object _lock = new object();
    Thread receiveThread;

    // UDP Port
    int port = 8080;
    //float[] raw = new float[120];
    float[] decodedarray;
    byte[] rawencoded;
    // Start is called before the first frame update
    UdpClient client;
    IPEndPoint anyIP;
    int count = 0;

    void Start()
    {
        Application.targetFrameRate = 50;

        // UDP Code
        receiveThread = new Thread(new ThreadStart(UDPClient));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    public void UDPClient()
    {
        this.client = new(port);
        this.anyIP = new(IPAddress.Any, 0);
        while (true)
        {
            if (decodedarray == null)
            {

                rawencoded = client.Receive(ref anyIP);
                lock (_lock)
                {
                    toFloatarray(rawencoded);
                }
            }
            //Debug.Log(rawencoded);

            // Debug.Log("New Message received");
        }
    }

    void toFloatarray(byte[] encoded)
    {
        decodedarray = new float[rawencoded.Length / sizeof(float)];
        Buffer.BlockCopy(rawencoded, 0, decodedarray, 0, rawencoded.Length);
    }
    void FixedUpdate()
    {


        // Debug.Log("frame: " + Time.frameCount);
        if (decodedarray != null)
        {
            lock (_lock)
            {
                Debug.Log("x: [" + decodedarray[1] + "], y: [" + decodedarray[2] + "], z: [" + decodedarray[3] + "], P: [" + decodedarray[4] + "], Y: [" + decodedarray[5] + "], R: [" + decodedarray[6] + "], W: [" + decodedarray[7] + "] count: " + (++count));
                // Quaternion rotUpdater = Quaternion.Euler(decodedarray[4], decodedarray[5], decodedarray[6]);
                Quaternion rotUpdater;
                rotUpdater.x = decodedarray[4];
                rotUpdater.y = decodedarray[5];
                rotUpdater.z = decodedarray[6];
                rotUpdater.w = decodedarray[7];
                transform.SetLocalPositionAndRotation(new Vector3(decodedarray[1], decodedarray[2], decodedarray[3]), rotUpdater);
                decodedarray = null;
            }

            // quaternion rotUpdater = Quaternion.Euler(decodedarray[0], decodedarray[1], decodedarray[2]);

            // Debug.Log(" x: [" + decodedarray[3 * (Time.frameCount - 1) % 3] + "], y: [" + decodedarray[(3 * (Time.frameCount - 1) + 1) % 3] + "], z: [" + decodedarray[(3 * (Time.frameCount - 1) + 2) % 3] + "]");

        }
    }
    void OnDisable()
    {
        if (client != null)
            client.Close();
        if (receiveThread != null && receiveThread.IsAlive)
            receiveThread.Abort();
    }
}
