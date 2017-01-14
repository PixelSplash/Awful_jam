using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCandle : MonoBehaviour {
    public float rango = 1f;
    private GameObject player;
    private LightIntensityRange lightController;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("mano");
        lightController = (LightIntensityRange)FindObjectOfType(typeof(LightIntensityRange));
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Sqrt((Mathf.Pow((transform.position.x - player.transform.position.x), 2f) + Mathf.Pow((transform.position.z - player.transform.position.z), 2f))) < rango)
        {
            //Debug.Log(Mathf.Abs(transform.position.z - player.transform.position.z));
            //Debug.Log(Mathf.Abs(transform.position.x - player.transform.position.x));
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                lightController.lightIntensity = LightIntensityRange.MAX_LIGHT_INTENSITY;
                lightController.lightRange = LightIntensityRange.MAX_LIGHT_RANGE;
                Destroy(gameObject);
            }
        }

    }
}
