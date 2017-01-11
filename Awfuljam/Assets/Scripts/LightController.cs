using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    private GameObject player;
    private Light lightVar;
    public float range = 5;
	// Use this for initialization
	void Start () {
        lightVar = GetComponent<Light>();
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Sqrt((Mathf.Pow((player.transform.position.x - transform.position.x), 2f) + Mathf.Pow((player.transform.position.z - transform.position.z),2f))) < range)
        {
            if (!lightVar.enabled)
            {
                lightVar.enabled = true;
            }
            
        }
        else
        {
            lightVar.enabled = false;
        }
	}
}
