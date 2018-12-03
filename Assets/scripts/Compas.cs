using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Orient an object to point to magnetic north

        //need to update the z axsis  only so it looks north 
        transform.rotation = Quaternion.Euler(0, -Input.compass.magneticHeading, 0);
    }

    }
