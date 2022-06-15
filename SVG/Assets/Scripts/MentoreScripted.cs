using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentoreScripted : MonoBehaviour
{

    private Vector3 movement;
    private bool isInFrontOf = false;
    private bool isMpressed = false;
    private bool isCreated = false;
    private Vector3 direction;
    private int mKeyCounter = 0;
    private float angle;
    private GameObject windowUI;
    public float checkAngle;
    public Transform target;
    public GameObject UI;

    public Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Test started...");
    }
    
    void Update()
    { // Update is called once per frame
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMpressed = true;
            mKeyCounter++;
            mAnimator.SetTrigger("PlayerCall");
        }
    }

    void FixedUpdate()
    { //FixedUpdate is faster than Update while working with physics

        if (isMpressed)
        {
            if (mKeyCounter == 1) //if we have pressed M once, so we want to visualize UI
            { 
                if (CompareAngle())
                    InstantiateUI();
            }
            else if (mKeyCounter == 2) //if we have pressed M twice, so we want to close UI            
                DestroyUI();            
        }
    }

    void InstantiateUI()
    {
        Vector3 playerPos = target.position;
        Vector3 playerDirection = target.forward;
        float spawnDistance = 1;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        spawnPos.y += 1;

        if (!isCreated && isInFrontOf)
        { //instantiate only once at the right time
            windowUI = Instantiate(UI, spawnPos, target.rotation, target);
            isCreated = true;
        }
    }

    void DestroyUI()
    {
        mKeyCounter = 0;
        Destroy(windowUI);
        isCreated = false;
        isInFrontOf = false;
    }


    bool CompareAngle()
    {
        direction = transform.position - target.position; //distance between this object and his target (a connecting line)            
        angle = Vector3.Angle(transform.up, direction);  //calculates the angle between the line that connect the two objects
                                                         // and the z-axis of this object
        if (angle < checkAngle)
        {  //if the angle calc. is lower than a prefixed number...   
            isInFrontOf = true;
        }
        return isInFrontOf;
    }

}
