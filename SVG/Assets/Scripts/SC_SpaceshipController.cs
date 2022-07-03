using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SC_SpaceshipController : MonoBehaviour
{
    
    // forward = su e giu, strafe = lateralmente, hover= avanti e dietro
    public float forwardSpeed = 20f;
    public float strafeSpeed = 20f;
    public float hoverSpeed = 20f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed, activeUpSpeed, activeRightSpeed, recoverTime = 1f; 
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    private float boostInput;
    public float boostSpeed =60f, boostAcceleration = 10f, maxBoostAmount = 500f, curBoostAmount = 0, boostRegenerateRate = .5f;
    int boostRechargeRate = 1;
    public bool boosting = false; 
    public bool inputBlocked = false;
    float regenerateTime = 0;
    [SerializeField]BoostLight[] boostLight;
     
    

    
    void OnEnable()
    {
        EventManager.onSpaceFightGame += Update;
    }

    void OnDisable()
    {
        EventManager.onSpaceFightGame -= Update;
    }
   
    //Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y= Screen.height * .5f;
        boosting = false;
        Cursor.lockState = CursorLockMode.Confined;
        curBoostAmount = maxBoostAmount;
        //InvokeRepeating("RegenerateBoost", boostRegenerateRate, boostRegenerateRate);

    }

    // Update is called once per frame
    void Update()
    {
        mouseMovement();

        // su e giu
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        // accelerazione
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        
        
        if(Input.GetAxis("Boost")>0) {
            boosting = true;
            boost();
            regenerateTime = 0;
        }
        else
        {
            foreach (BoostLight bl in boostLight)
                {
                    bl.Activate(false);
                }
            boosting = false;
            forwardSpeed = 20f;
            strafeSpeed = 20f;
            hoverSpeed = 20f;
            RegenerateBoost();
            regenerateTime += Time.deltaTime;
        }
        

        // destra sinistra
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);
        
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime);
        transform.position += (transform.up * activeHoverSpeed * Time.deltaTime) + (transform.forward * activeForwardSpeed * Time.deltaTime);
        
        

    }
    public void FixedUpdate()
    {
        Vector3 forward = transform.forward * activeForwardSpeed * Time.fixedDeltaTime;
        Vector3 strafe = transform.right * activeStrafeSpeed * Time.fixedDeltaTime;
        Vector3 hover = transform.up * activeHoverSpeed * Time.fixedDeltaTime;

        Vector3 movement = forward + strafe + hover;
        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }
    
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Collide());
    }
    

    void mouseMovement()
    {
        //Dove si trova il mouse dallo schermo
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;
        
        //Distanza del mouse dal centro dello schermo
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);
        //Applicare rotazione
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime , Space.Self);
    }    
    void RegenerateBoost()
    {
        if(regenerateTime > 4)
        {
          Debug.Log("Regenerating Boost");
        
        if(curBoostAmount < maxBoostAmount)
         {
            curBoostAmount += boostRechargeRate;
         }
        if(curBoostAmount > maxBoostAmount)
        {
            curBoostAmount = maxBoostAmount;
            //CancelInvoke();
        }
           

        EventManager.ReductingBoost(curBoostAmount / (float)maxBoostAmount);  
        }
        
    }

    public void boost(float boostDmg = .05f)
    { 
        if(boosting == true)
        {
            if(curBoostAmount > 0)
            {
                curBoostAmount -= boostDmg;
                EventManager.ReductingBoost(curBoostAmount / (float)maxBoostAmount);
                boosting = true;
                foreach (BoostLight bl in boostLight)
                {
                    bl.Activate();
                }
                forwardSpeed = boostSpeed;
                strafeSpeed = boostSpeed;
                hoverSpeed = boostSpeed; 
            }
            else
            {
                boosting = false;
                forwardSpeed = 20f;
                strafeSpeed = 20f;
                hoverSpeed = 20f;
                foreach (BoostLight bl in boostLight)
                    {
                        bl.Activate(false);
                    }
            }
            
        }
        else
        {
            boosting = false;
        }
    }

    

    IEnumerator Collide()
    {
        inputBlocked = true;

        activeForwardSpeed = -activeForwardSpeed;
        activeRightSpeed = -activeRightSpeed;
        activeUpSpeed = -activeUpSpeed;

        yield return new WaitForSeconds(recoverTime);

        inputBlocked = false;
    }
    
   

 }