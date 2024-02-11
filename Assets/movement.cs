using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    public float thrust = 1000f; 
    float angthrust = 0.1f;
    // for unstable_SIM use 0.1f for both thrust and angthrust
    // for SIM use 0.01f for both thrust and angthrust
    // bool flag = true;
    // bool flag1 = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.1f;
        rb.angularDrag = 0.1f;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*if (Input.GetKey(KeyCode.Keypad0))
        {
            if (flag == true)
            {
                thrust *= 0.5f;
                flag = false;
            }
            else
            {
                thrust *= 2f;
                flag = true;
            }
        }*/
        if (Input.GetKey(KeyCode.Keypad8))
        {
            rb.AddForce(0, thrust, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            rb.AddForce(0, -thrust, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            rb.AddForce(thrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            rb.AddForce(-thrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Keypad9))
        {
            rb.AddForce(0, 0, thrust, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Keypad7))
        {
            rb.AddForce(0, 0, -thrust, ForceMode.Impulse);
        }

        /*if (Input.GetKey(KeyCode.Z))
        {
            if (flag1 == true)
            {
                angthrust *= 0.5f;
                flag1 = false;
            }
            else
            {
                angthrust *= 2f;
                flag1 = true;
            }
        }*/
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(0, angthrust, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(0, -angthrust, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(angthrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddTorque(-angthrust, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(0, 0, angthrust, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(0, 0, -angthrust, ForceMode.Impulse);
        }
    }
}