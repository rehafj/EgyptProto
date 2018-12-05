using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour {

    public DataFields dataFields;
    public GameObject windowPrefab;

    public void OpenPopup(){
        print("Click");
        GameObject popup = Instantiate(windowPrefab);
    }	

}

public class DataFields{
    public string name = "AHHHHHHH";
}