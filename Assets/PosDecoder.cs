using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Mathematics;
using UnityEngine;

public class PosDecoder : MonoBehaviour
{
    float[] raw = new float[120];
    float[] decodedarray = new float[120];
    // Start is called before the first frame update
    void Start()
    {
        Transform position = GetComponent<Transform>();

        float randy = math.abs(UnityEngine.Random.value);
        raw[0] = 0.00f;
        for (int i = 1; i < 120; i++)
        {
            raw[i] = raw[i - 1] + randy;
        }
        // for(int i = 0; i < raw.Length; i++){Debug.Log(raw[i]);}
        byte[] rawencoded = toBinaryarray(raw);

        /*string stringencoded = "";
        for (int i = 0; i < rawencoded.Length; i++)
        {
            stringencoded += rawencoded[i].ToString();
        }
        Debug.Log(stringencoded);*/

        decodedarray = toFloatarray(rawencoded);
        //  for(int i = 0; i < decodedarray.Length; i++){Debug.Log(raw[i] == decodedarray[i]);}
    }
    float[] toFloatarray(byte[] encoded)
    {
        BinaryFormatter binaryFormatter = new();
        MemoryStream memoryStream = new(encoded);
        float[] decodedarray = (float[])binaryFormatter.Deserialize(memoryStream);
        return decodedarray;
    }

    byte[] toBinaryarray(float[] raw)
    {
        BinaryFormatter binaryFormatter = new();
        MemoryStream memoryStream = new();
        binaryFormatter.Serialize(memoryStream, raw);
        return memoryStream.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        // int fps = Mathf.RoundToInt(1f / Time.deltaTime);
        // Debug.Log(Time.frameCount);
        quaternion rotUpdater = Quaternion.Euler(decodedarray[3 * (Time.frameCount - 1) % 120], decodedarray[(3 * (Time.frameCount - 1) + 1) % 120], decodedarray[(3 * (Time.frameCount - 1) + 2) % 120]);
        transform.rotation = rotUpdater;
        // Debug.Log("x: [" + decodedarray[3 * (Time.frameCount - 1) % 120] + "], y: [" + decodedarray[(3 * (Time.frameCount - 1) + 1) % 120] + "], z: [" + decodedarray[(3 * (Time.frameCount - 1) + 2) % 120] + "]");
    }
}
