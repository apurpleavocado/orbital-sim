using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LatLongOP))]
public class LatLongOPEditor : Editor
{
    double i;
    double j;
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        LatLongOP latLongOP = (LatLongOP)target;
        i = latLongOP.latitude % 90;
        j = latLongOP.longitude % 180;

        latLongOP.latitude = EditorGUILayout.DoubleField("Latitude", i);
        latLongOP.longitude = EditorGUILayout.DoubleField("Longitude", j);

        latLongOP.transform.rotation = Quaternion.AngleAxis((float)-j, new Vector3(0, 0, 1)) * Quaternion.AngleAxis((float)i, new Vector3(1, 0, 0));
    }
}
