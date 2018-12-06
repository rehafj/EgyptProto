using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour {

    public DataFields dataFields;
    public GameObject windowPrefab;
    public List<GameObject> positionMarkers;


    public void OpenPopup(){
        print("Click");
        GameObject plr = GameObject.FindGameObjectWithTag("Player");
        plr.GetComponent<PopupManager>().addPopups(positionMarkers, dataFields);
    }	

}

[System.Serializable]
public class DataFields{
    public string name = "AHHHHHHH";
    public string description = "OH NOES! MORE TEXT?";
    public int uncertaintyLevel = 0; //use 1 to 5, 1 being most certain, 5 being least (0 being unset)
    
}