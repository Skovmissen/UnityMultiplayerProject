using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(PlayerMoter))]
[RequireComponent(typeof(ConfigurableJoint))]
public class MovementController : NetworkBehaviour
{

    public float moveSpeed;
    public float lookSensitivity;
    public float force = 3;

    private PlayerMoter moter;

    void Start()
    {
        moter = GetComponent<PlayerMoter>();


    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        // Udregn og send spillerens bevægelse
        float moveY = Input.GetAxisRaw("Horizontal");
        float moveX = Input.GetAxisRaw("Vertical");
        Vector3 MoveHorizon = -transform.right * moveX;
        Vector3 MoveVertical = transform.forward * moveY;
        Vector3 movement = (MoveHorizon + MoveVertical).normalized * moveSpeed;
        moter.Move(movement);

        // Udregn og send rotationen omkring spilleren y-akse
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * lookSensitivity;
        moter.Rotate(rotation);
    }

}
