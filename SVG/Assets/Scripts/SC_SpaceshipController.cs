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

    //Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // su e giu
        activeForwardSpeed = Input.GetAxisRaw("Hover") * forwardSpeed;
        // accelerazione
        activeStrafeSpeed = Input.GetAxisRaw("Vertical") * strafeSpeed;
        // destra sinistra
        activeHoverSpeed = Input.GetAxisRaw("Horizontal") * hoverSpeed;
        
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime);
        transform.position += (transform.up * activeHoverSpeed * Time.deltaTime) + (transform.forward * activeForwardSpeed * Time.deltaTime);
        
        

    }
}