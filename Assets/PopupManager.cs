using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour {

    List<GameObject> openPopups;
    public GameObject windowPrefab;

    public Camera mainCamera;
    public Swapper swapper;

    private void Start() {
        openPopups = new List<GameObject>();
    }

    public void addPopups(List<GameObject> positionMarkers, DataFields dataFields){
        if((openPopups.Count > 0 && openPopups[0].GetComponent<PopupDisplay>().data.name != dataFields.name) //some popup is open, but it isn't the one we just clicked on
            || openPopups.Count == 0){ //or there is no popup open now

            if(openPopups.Count > 0){
                closePopups();
            }

            //add new ones

            foreach(GameObject marker in positionMarkers){
                GameObject popup = Instantiate(windowPrefab);

                //put in a good spot
                popup.transform.position = marker.transform.position;
                //turn toward player
                popup.transform.LookAt(transform.position);
                popup.transform.Rotate(0, 180, 0);

                //Fill with Data
                popup.GetComponent<PopupDisplay>().data = dataFields;

                openPopups.Add(popup);
            }

            //take us to the reconstruction (or keep us there)
            swapper.changeStates();
        }else{ //otherwise, it is the one which is already open, so we probably just want to close it
            closePopups();
        }
    }

    public void closePopups(){
        //delete currently open ones
        while(openPopups.Count > 0){
            GameObject popup = openPopups[openPopups.Count -1];
            openPopups.Remove(popup);

            Destroy(popup);
        }

        //bring us back to the modern rubble
        swapper.changeStates();
    }
}
