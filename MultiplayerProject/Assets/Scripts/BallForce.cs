using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject whatToSpawn;
    public float power;
    void OnCollisionEnter(Collision c)
    {
        // force is how forcefully we will push the player away from the enemy.


        // If the object we hit is the enemy
        if (c.gameObject.tag == "Player")
        {
            
            // calculate force vector
            var force = transform.position - c.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * power);
        }
        if (c.gameObject.tag == "Goal")
        {
            Destroy(gameObject);
            whatToSpawn = Instantiate(whatToSpawn, spawnpoint.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
