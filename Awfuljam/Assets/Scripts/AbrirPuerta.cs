using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    public float n = 3f;
    public float speed = 0f;
    private bool state = true;
    private float naux = 0;
    private bool move = false;
    private GameObject player;
    private GameObject agarradera;
    public float rango = 1f;
    // Use this for initialization
    void Start()
    {
        agarradera = transform.Find("agarradera1").gameObject;//GameObject.Find("agarradera1");
        naux = n;
        player = GameObject.Find("mano");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(transform.position.z - player.transform.position.z));
        if (Mathf.Sqrt((Mathf.Pow((agarradera.transform.position.x - player.transform.position.x),2f) + Mathf.Pow((agarradera.transform.position.z - player.transform.position.z),2f))) < rango)
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
                    transform.Rotate(0, speed, 0);
                }
                else
                {
                    transform.Rotate(0, -speed, 0);
                }

                naux--;
            }
            else
            {
                if (state)
                {
                    state = !state;
                    naux = n;
                    //move = ;
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

}
