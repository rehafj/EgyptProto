using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupCreator : MonoBehaviour {

    public DataFields dataFields;
    public List<GameObject> positionMarkers;

    public void Start() {
        Material m = gameObject.GetComponent<Renderer>().materials[0];
        Color newColor = Color.white;
        float alpha  = m.color.a;

        switch(dataFields.uncertaintyLevel){
            case (1):
                newColor = Color.magenta;
                break;
            case (2):
                newColor = Color.blue;
                break;
            case (3):
                newColor = Color.green;
                break;
            case (4):
                newColor = Color.yellow;
                break;
            case (5):
                newColor = Color.red;
                break;
        }

        newColor.a = alpha;
        m.color = newColor;
    }


    public void OpenPopup(){
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