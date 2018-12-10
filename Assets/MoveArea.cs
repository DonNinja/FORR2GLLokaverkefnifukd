using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour {

    public GameObject movingArea;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MovePlat();
	}

    void MovePlat ()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }
}
