using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour {

    bool isRubblePeriod = true;

    public GameObject [] prefabs;
    public GameObject mainObjectTest; 
    //public Material[] objectsCurrent;
    public List<Material> objectsReconstructed;
    public List<Material> currentMaterials;


    // Use this for initialization
    void Start () {

        //add a thing that changes 

        prefabs = new GameObject[mainObjectTest.transform.childCount]; // get the size of transforms ( map o=pos )



        // 
        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i] = mainObjectTest.transform.GetChild(i).gameObject ;

            currentMaterials.Add(prefabs[i].GetComponent<MeshRenderer>().material); // added the material into llist 


            if (prefabs[i].GetComponent<Material>()!=null){
                // add that to the material list 
                currentMaterials.Add(prefabs[i].GetComponent<Material>()); // added the material into llist 
            }
            //add code to select material 
           
            

            //if (prefabs[i].transform.childCount > 0) ///if it has a child then loop through it 
            //{
            //    prefabs[i].gameObject.transform.GetChild[i].ge

            //} CAL THIS METHIF AGAIN 
   

        }




        //prefabs  = new Material[gameObject.transform.childCount]; // get the size of transforms ( map o=pos )

        //for (int i = 0; i < objectsCurrent.Length; i++)
        //{
        //    objectsCurrent[i] = gameObject.transform.GetChild(i).GetComponent<Material>();
        //    if(objectsCurrent)
        //    Debug.Log(objectsCurrent[i].name);

        //}
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.A)){
            foreach (Material m in currentMaterials){

                Color t = Color.white;
                //t = m.color;
                //t.a = 0f;
                m.color = t;
                Debug.Log("COLOR CHANGED");
            }


        }
	}


}
