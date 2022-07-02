using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class MentoreScripted : MonoBehaviour
{    
    [SerializeField] private GameObject Apache;
     [SerializeField] private GameObject playerArmature;
    [SerializeField] private CinemachineVirtualCamera uiCamera;
    private Animator mAnimator;
    private Vector3 movement;
    private StarterAssetsInputs startAssInput;
    private Vector3 direction;
    private GameObject windowUI;
    private Transform playerTransform;
    private Animator playerAnim;
    private bool isInFrontOf = false;
    private bool isMpressed = false;
    private bool isCreated = false;    
    private int mKeyCounter = 0;
    private float angle;        
    public float checkAngle;   
    public GameObject UI;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
        playerAnim = playerArmature.GetComponent<Animator>();
        playerTransform = playerArmature.GetComponent<Transform>();        
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
            if (mKeyCounter == 1) //if we have pressed M once, we want to visualize UI
            { 
                if (CompareAngle())
                    InstantiateUI();                                   
                    
            }
            else if (mKeyCounter == 2) //if we have pressed M twice, we want to close UI            
                DestroyUI();                          
        }
    }

    void InstantiateUI()
    {
        Vector3 playerPos = playerTransform.position;
        Vector3 playerDirection = playerTransform.forward;
        float spawnDistance = 1;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;  
        
        spawnPos.y += 1.4f; 

        if(playerTransform.forward.x <= 0) {
            spawnPos.z += 0.5f;  
        } else {
            spawnPos.z -= 0.5f;  
        }                           

        if (!isCreated && isInFrontOf)
        { //instantiate only once at the right time
            windowUI = Instantiate(UI, spawnPos, playerTransform.rotation, playerTransform);
            Debug.Log("spawnPos: " + spawnPos + ", playerDirection: " + playerDirection + ", playerRotation: " + playerTransform.rotation);
            isCreated = true;            

            //camera switch
            uiCamera.gameObject.SetActive(true); 
            uiCamera.m_Follow = windowUI.transform;             
        }      

        if(Input.GetKeyDown(KeyCode.I)) {
            playerAnim.SetTrigger("UInteraction");
        }          

    }

    void DestroyUI()
    {
        mKeyCounter = 0;
        Destroy(windowUI);
        isCreated = false;
        isInFrontOf = false;
        uiCamera.gameObject.SetActive(false); 
    }


    bool CompareAngle()
    {
        direction = transform.position - playerTransform.position; //distance between this object and his target (a connecting line)            
        angle = Vector3.Angle(transform.up, direction);  //calculates the angle between the line that connect the two objects
                                                         // and the z-axis of this object        
        if (angle < checkAngle)
        {  //if the angle calc. is lower than a prefixed number...   
            isInFrontOf = true;
        }
        return isInFrontOf;
    }

}
