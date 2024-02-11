using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class rolldeviation90 : MonoBehaviour
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
        float z_recalc90 = Mathf.Repeat(target.rotation.eulerAngles.y, 360) / 2 - 180 * math.floor(Mathf.Repeat(target.rotation.eulerAngles.y, 360) / 180);
        transform.rotation = Quaternion.Euler(0, 0, z_recalc90);
        rawImage.color = new Color(math.abs(z_recalc90 / 45f), 1 - (math.abs(z_recalc90) - 45f) / 45f * math.floor(math.abs(z_recalc90) / 45), 0, 1);
        
    }
}
