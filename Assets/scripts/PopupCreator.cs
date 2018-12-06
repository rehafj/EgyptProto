using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour {

    public DataFields dataFields;
    public GameObject windowPrefab;
    GameObject popup = null;

    public void OpenPopup(){
        print("Click");
        if(popup == null){
            popup = Instantiate(windowPrefab);
            GameObject plr = GameObject.FindGameObjectWithTag("Player");
            print(plr.transform.position);
            print(transform.position);
            popup.transform.position = (transform.position + plr.transform.position)/2;
        }
    }	

}

public class DataFields{
    public string name = "AHHHHHHH";
}