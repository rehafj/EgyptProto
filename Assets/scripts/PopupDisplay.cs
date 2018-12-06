using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDisplay : MonoBehaviour {

    public GameObject titleTextObject;
    public GameObject descriptionTextObject;
    public DataFields data;

	// Use this for initialization
	void Start () {
        Text titleText = titleTextObject.GetComponent<Text>();
        titleText.text = data.name;
        Text descText = descriptionTextObject.GetComponent<Text>();
        descText.text = data.description;
	}

    public void ClosePopup(){
        GameObject plr = GameObject.FindGameObjectWithTag("Player");
        plr.GetComponent<PopupManager>().closePopups();
    }
}
