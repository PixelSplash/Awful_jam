using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    private SimpleTimer timer;
    private float initialy;
    private float initialz;
    // Use this for initialization
    void Start () {
        timer = GetComponent<SimpleTimer>();
        initialy = transform.position.y;
        initialz = transform.position.z;
        timer.timerStart(0.01f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!timer.isCounting)
        {
            Shake();
        }
    }
    private void Shake()
    {
        transform.position = new Vector3(transform.position.x, initialy + Random.Range(-0.01f, 0.01f), initialz + Random.Range(-0.01f, 0.01f));
        timer.timerStart(0.01f);
    }
}
