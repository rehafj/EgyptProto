using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocationTracking : MonoBehaviour {

    //done poorly but for now... > move player actions and UI events  into  own script later 
    public int currentLocation = 0;
    Transform[] transforms;
    GameObject plr, image;
    Image mapImage;
    public float speed = 2;
    public Sprite[] sprites = new Sprite[5];

    bool CanMove = false;
	// Use this for initialization
	void Start () {
        plr = GameObject.FindGameObjectWithTag("Player");//get the player object 
        image = GameObject.FindGameObjectWithTag("Map");
        mapImage = image.GetComponent<Image>();
        transforms = new Transform[gameObject.transform.childCount]; // get the size of transforms ( map o=pos )
     


        // set up transfroms 
        for (int i = 0; i < transforms.Length; i++ ){
            transforms[i] = gameObject.transform.GetChild(i);
            Debug.Log(transforms[i].position);

        }



    }

    public void  MoveToNext(){ // sets cond to move to next location ( player and cavas ) 
        currentLocation++;
        if(currentLocation >= transforms.Length ){ //reached the last postion 
            currentLocation = 0;
        }
        CanMove = true; // to move player to next postion 
                        //to change canvas image to next one 
        changeImage();

    }

    private void changeImage()
    {
        if(sprites[currentLocation]!= null)
        mapImage.sprite = sprites[currentLocation];
    }


    // Update is called once per frame - moves the player 
    void FixedUpdate () {
      
        if(CanMove){ // if I can move, move me to the next postion 
            plr.transform.position = Vector3.MoveTowards(plr.transform.position, transforms[currentLocation].position, speed * Time.deltaTime);
            float dist = Vector3.Distance(plr.transform.position, transforms[currentLocation].position);
            print("Distance tonext object  " + dist);
            if (dist >= 0 &&  dist <3){
                //stop the player 
                CanMove = false;
            }
        }

    }

    Transform returnNextLoc(){ // for refactoring purp
        return transforms[currentLocation];
    }


}
