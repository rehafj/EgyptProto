using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDisplay : MonoBehaviour {

    public GameObject nameTextObject;

	// Use this for initialization
	void Start () {
        Text nameText = nameTextObject.GetComponent<Text>();
        nameText.text = "HEY SOME STUFF!";
	}
	
}
