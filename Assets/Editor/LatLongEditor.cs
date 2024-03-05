using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Latlong))]
public class LatLongEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        Latlong latlong = (Latlong)target;
        double i = Math.Abs(latlong.X) % 360;
        double j = Math.Abs(latlong.Z) % 360;
        double J = ((Math.Abs(latlong.Z) % 360) + 180 * (((Math.Floor(i / 180) % 2) + (Math.Floor(i / 90) % 2)) % 2)) % 360;

        // latitude
        double Lat = 180 * (((Math.Floor(i / 180) % 2) + (Math.Floor(i / 90) % 2)) % 2)
        + i - 2 * i * (((Math.Floor(i / 180) % 2) + (Math.Floor(i / 90) % 2)) % 2) - 360 *
        Math.Floor(i / 270);
        // longitude
        double Long = (360 * Math.Floor(J / 180)) - J;

        latlong.X = EditorGUILayout.DoubleField("X", i);
        // latlong.Y = EditorGUILayout.FloatField("Y", latlong.Y % 360);
        latlong.Z = EditorGUILayout.DoubleField("Z", j);

        EditorGUILayout.TextField("Latitude", Lat.ToString());
        EditorGUILayout.TextField("Longitude", Long.ToString());

        // Quaternion qy = Quaternion.AngleAxis(latlong.Y, new Vector3(0, 1, 0));
        Quaternion Qx = Quaternion.AngleAxis((float)i, new Vector3(1, 0, 0));
        Quaternion Qz = Quaternion.AngleAxis((float)j, new Vector3(0, 0, 1));

        // z, y -> x (x does not influence y and z)
        // z -> y (y does not influence z but influences x)
        // z influences both x and y
        latlong.transform.rotation = Qz * Qx;
        Debug.Log(latlong.transform.rotation);
    }
}
