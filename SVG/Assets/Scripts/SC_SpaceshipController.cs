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
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed; 
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    //Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y= Screen.height * .5f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        //Dove si trova il mouse dallo schermo
        lookInput.x = Input.mousePosition.y;
        lookInput.y = Input.mousePosition.x;
        
        //Distanza del mouse dal centro dello schermo
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxis("Roll"), rollAcceleration * Time.deltaTime);
        //Applicare rotazione
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime , Space.Self);

        // su e giu
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Hover") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        // accelerazione
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Vertical") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        // destra sinistra
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Horizontal") * hoverSpeed, hoverAcceleration * Time.deltaTime);
        
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime);
        transform.position += (transform.up * activeHoverSpeed * Time.deltaTime) + (transform.forward * activeForwardSpeed * Time.deltaTime);
        
        

    }
 }