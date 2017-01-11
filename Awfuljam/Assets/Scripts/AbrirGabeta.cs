using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirGabeta : MonoBehaviour {
    public float n = 3f;
    public float speed = 0f;
    private bool state = true;
    private float naux = 0;
    private bool move = false;
    private GameObject player;
    public float rango = 1f;
	// Use this for initialization
	void Start () {
        naux = n;
        player = GameObject.Find("mano");
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Mathf.Abs(transform.position.z - player.transform.position.z));
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < rango & Mathf.Abs(transform.position.z - player.transform.position.z) < rango)
        {
            //Debug.Log(Mathf.Abs(transform.position.z - player.transform.position.z));
            //Debug.Log(Mathf.Abs(transform.position.x - player.transform.position.x));
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                move = true;
            }
        }
        if (move)
        {
            if (naux > 0)
            {
                if (state)
                {
                    transform.Translate(-Vector3.right * speed);
                }
                else
                {
                    transform.Translate(Vector3.right * speed);
                }

                naux--;
            }
            else
            {
                state = !state;
                naux = n;
                move = false;
            }
        }
        
        
        
    }
 
}
