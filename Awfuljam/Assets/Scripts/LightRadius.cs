using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRadius : MonoBehaviour {
    private Controller player;
    // Use this for initialization
    void Start () {
        // find the current instance of the player script:
        player = (Controller)FindObjectOfType(typeof(Controller));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            player.lights++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            player.lights--;
        }
    }
}
