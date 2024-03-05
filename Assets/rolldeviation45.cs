using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class rolldeviation : MonoBehaviour
{
    public Transform target;
    RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // transform.rotation = Quaternion.Euler(0, 0, 180 * math.floor(target.rotation.eulerAngles.y / 180)
        //  - target.rotation.eulerAngles.y / 2 + target.rotation.eulerAngles.y * (math.ceil(target.rotation.eulerAngles.y / 180) % 2));
        float z_recalc45 = Mathf.Repeat((float)Math.Round(target.localRotation.eulerAngles.y, 2), 360) / 4 - 90 * math.floor(Mathf.Repeat((float)Math.Round(target.localRotation.eulerAngles.y, 2), 360) / 180);
        transform.rotation = Quaternion.Euler(0, 0, z_recalc45);
        rawImage.color = new Color(math.abs(z_recalc45 / 22.5f), 1 - (math.abs(z_recalc45) - 22.5f) / 22.5f * math.floor(math.abs(z_recalc45) / 22.5f), 0, 1);
        // Debug.Log(1 - math.abs(eulerRotation.y / 45));
    }
    
}
