using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayerColor : MonoBehaviour {

    public GameObject player;
    public Transform[] PlayerSpawn;

    // Use this for initialization
    void Start () {
        

        for (int i = 0; i < PlayerSpawn.Length; i++)
        {

            GameObject go = Instantiate(player, PlayerSpawn[i].position, Quaternion.identity) as GameObject;
            go.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
