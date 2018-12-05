using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapper : MonoBehaviour {

    public  static bool isRubblePeriod = true;

    public GameObject [] prefabs;
    public GameObject [] mainObjectTest = new GameObject[2]; 
    //public Material[] objectsCurrent;
    public List<Material> objectsReconstructed;
    public List<Material> currentMaterials;

    public Material white; 

    // Use this for initialization
    void Start () {

        ///setup - need refactoring but for now...

        GameObject [] temp1  = new GameObject[mainObjectTest[0].transform.childCount]; // get the size of transforms ( map o=pos )
        GameObject[] temp2 = new GameObject[mainObjectTest[1].transform.childCount]; // get the size of transforms ( map o=pos )
        Debug.Log(temp1.Length);

        initMaterials(temp1, mainObjectTest[0], currentMaterials);
        initMaterials(temp2, mainObjectTest[1], objectsReconstructed);

       fadeIn(objectsReconstructed); //fade to 0 alpha 

    }

    private void initMaterials(GameObject [] g, GameObject nested, List<Material> materials)
    {

        for (int i = 0; i < g.Length; i++)
        {
            g[i] = nested.transform.GetChild(i).gameObject;
            Debug.Log(g[i].name); //works 
            materials.Add(g[i].GetComponent<Renderer>().materials[0]); // added the material into llist 

            if (g[i].GetComponent<Material>() != null)
            {
                materials.Add(g[i].GetComponent<Renderer>().materials[0]); // added the material into llist 
            }

        }
    }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.A)){
                if (isRubblePeriod == true) //curreny in a rubble period 
                {
                    isRubblePeriod = false;
                }
                else{ //was false set it to true
                    isRubblePeriod = true;
                }
                changeStates();

                if (isRubblePeriod == true) //curreny in a rubble period 
                {
                    Debug.Log(" I AM IN A RUBLE PERIOD");
                }
                else
                {
                    Debug.Log("not in rubble");

                }

        }










    }
	

   public void  changeStates(){ //TODO call this from player sctip
        if(isRubblePeriod == true ){ //change to not rubble state 

            //prob can be one method thaat checks how much trans has been done -- change it 
            //StartCoroutine(fadeOut(objectsReconstructed)); // fade materials inot full alpha 1

            //too much of a performance hurdle on my machine for somereason - removing cool effects :( 
            fadeOut(objectsReconstructed); // fade materials inot full alpha 
            fadeIn(currentMaterials); //fade to 0 alpha 

        }
        else {// if(isRubblePeriod == false){
           
           fadeOut(currentMaterials); // start fading on materials in the constructed state 
           fadeIn(objectsReconstructed); // start fading on materials in the constructed state 
           
        }
        //set up - logic error from inside - quick fix 
        //isRubblePeriod = !isRubblePeriod; //whatever it is it is the oppista now
   

        /// for methods quicl 
    }

    // also I know having two methods does not make sense - can refactor to one and checks the alpha or 
    // or method to interlope between two values ( and we supply 0, and 1 values for fading... 
    private void fadeIn(List<Material> materials)
    {
        foreach (Material m in materials)
        {
            Color t = new Color();
            t = m.color;
            t.a = 0f;
            m.color = t;

        }
    }
    private void fadeOut(List<Material> materials)
    {
        foreach (Material m in materials)
        {
            Color t = new Color();
            t = m.color;
            t.a = 1f;
            m.color = t;

        }
    }

    IEnumerator fade1(Color t, Material m){
        t.a += 0.1f;
        m.color = t;
        yield return new WaitForSeconds(0.1f);
    }
    //as a courutine 
    //private IEnumerator fadeIn(List<Material> materials)
    //{
    //    foreach( Material m in materials){
    //        Color t = new Color();
    //        t = m.color;
    //        t.a = 0f;
    //        m.color = t;
    //        Debug.Log("COLOR CHANGED");

    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}
    //private IEnumerator fadeOut(List<Material> materials)
    //{
    //    foreach (Material m in materials)
    //    {
    //        Color t = new Color();
    //        t = m.color;
    //        t.a = 1f;
    //        m.color = t;
    //        Debug.Log("COLOR CHANGED");

    //        yield return new WaitForSeconds(0.3f);
    //    }
    //}
}
