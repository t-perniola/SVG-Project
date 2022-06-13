using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentoreScripted : MonoBehaviour{   
    
    private Vector3 movement;
    private bool isInFrontOf = false;  
    private bool isMpressed = false;
    private bool isCreated = false;
    private Vector3 direction;
    private float angle;
    public float checkAngle;
    public Transform target;       
    public GameObject UI;
    public  Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Test started...");
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.M)) {
            isMpressed = true;
            mAnimator.SetTrigger("PlayerCall");
            Debug.Log("M key pressed!"); //M if we want to invoke the Mentore            
        }        
        
    }

    void FixedUpdate() { //FixedUpdate is faster than Update while working with physics
       
        direction = target.position - transform.position; //distance between this object and his target (a connecting line)            
        angle = Vector3.Angle(transform.forward, direction);  //calculates the angle between the line that connect the two objects
                                                                // and the z-axis of this object         
        if(isMpressed) {            
                     
            if (angle < checkAngle ) {  //if the angle calc. is lower than a prefixed number...   
                isInFrontOf = true;
                //Debug.Log("Mentore is in front of the Player!");
            }                  

            if(!isCreated && isInFrontOf) { //instantiate only once at the right time
                Instantiate(UI);
                isCreated = true;
            }
        }
    }
}
