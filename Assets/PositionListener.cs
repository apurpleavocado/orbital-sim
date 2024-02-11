using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PositionListener : MonoBehaviour
{
    public Transform anglecatch;
    public TextMeshProUGUI angleUI_X;
    public TextMeshProUGUI angleUI_Y;
    public TextMeshProUGUI angleUI_Z;
    Vector3 recalc_anglecatch;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // for floatpoint precision error
        recalc_anglecatch = new Vector3(Mathf.Repeat(anglecatch.rotation.eulerAngles.x, 360f), 
        Mathf.Repeat(anglecatch.rotation.eulerAngles.y, 360f), 
        Mathf.Repeat(anglecatch.rotation.eulerAngles.z, 360f));

        Vector3 recalc_rot = recalc_anglecatch - new Vector3(
        360 * math.floor(recalc_anglecatch.x / 180),
        360 * math.floor(recalc_anglecatch.y / 180),
        360 * math.floor(recalc_anglecatch.z / 180));
        angleUI_X.text = "P " + recalc_rot.x.ToString("F2");
        angleUI_Y.text = "Y " + recalc_rot.y.ToString("F2");
        angleUI_Z.text = "R " + recalc_rot.z.ToString("F2");

        angleUI_X.color = new Color(math.abs(recalc_rot.x / 90), 1 - (math.abs(recalc_rot.x) - 90) / 90 * math.floor(math.abs(recalc_rot.x) / 90), 0, 1);
        angleUI_Y.color = new Color(math.abs(recalc_rot.y / 90), 1 - (math.abs(recalc_rot.y) - 90) / 90 * math.floor(math.abs(recalc_rot.y) / 90), 0, 1);
        angleUI_Z.color = new Color(math.abs(recalc_rot.z / 90), 1 - (math.abs(recalc_rot.z) - 90) / 90 * math.floor(math.abs(recalc_rot.z) / 90), 0, 1);

        // Debug.Log(recalc_anglecatch.y);
        //  angleUI_X.text = "Pitch: " + math.min(anglecatch.rotation.eulerAngles.x, 360-anglecatch.rotation.eulerAngles.x).ToString("F2");
        //  angleUI_Y.text = "Yaw: " + math.min(anglecatch.rotation.eulerAngles.y, 360-anglecatch.rotation.eulerAngles.y).ToString("F2");
        //  angleUI_Z.text = "Roll: " + math.min(anglecatch.rotation.eulerAngles.z, 360-anglecatch.rotation.eulerAngles.z).ToString("F2");

    }
}
