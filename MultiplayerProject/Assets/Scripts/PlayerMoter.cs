using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMoter : NetworkBehaviour
{

    public Camera cam;


    private Vector3 movement = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (isLocalPlayer)
        {
            if (!cam.enabled)
                cam.enabled = true;
        }
        else
        {
            cam.enabled = false;
        }
    }
    public void Move(Vector3 _movement)
    {
        movement = _movement;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();

    }

    void PerformMovement()
    {
        if (movement != Vector3.zero)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }

    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
    }
}
