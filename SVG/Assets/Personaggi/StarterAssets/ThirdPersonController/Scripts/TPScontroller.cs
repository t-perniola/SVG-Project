using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class TPScontroller : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private GameObject gun;
    [SerializeField] private float standardSensitivity;    
    [SerializeField] private float aimSensitivity;    
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransf;
    [SerializeField] private Transform vfxHitted;    
    [SerializeField] private Transform vfxNotHitted;  
    
    public AudioClip shoot;    
    [Range(0, 1)] public float ShootAudioVolume = 0.5f; 

    private bool isAiming = false;
    private StarterAssetsInputs startAssInput;
    private ThirdPersonController tpController;
    private Animator pAnimator;

    private void Awake()
    { // access to the scripts from the same object
        startAssInput = GetComponent<StarterAssetsInputs>();
        tpController = GetComponent<ThirdPersonController>();
        pAnimator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {   
        Vector3 mousePosition = Vector3.zero;
        Vector2 screenCenter = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        Transform hitTransform = null; //it is a valid target?

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask)) {
            debugTransf.position = raycastHit.point; 
            mousePosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        } else { 
            mousePosition = ray.GetPoint(20f);
            debugTransf.position = ray.GetPoint(20f);
        }

        if (startAssInput.aim) {    
            isAiming = true;
            gun.SetActive(true);    
            aimCamera.gameObject.SetActive(true);
            tpController.SetSensitivity(aimSensitivity);
            tpController.SetRotateOnMove(false); //we do this because we decided that the player rotates only with aiming and not while moving
            pAnimator.SetLayerWeight(1, Mathf.Lerp(pAnimator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));
            // 1 because we are indexing the second (aiming) layer

            Vector3 aimTarget = mousePosition;
            aimTarget.y = transform.position.y; //same y for player and target, we dont care about it, we want to rotate left and right
            Vector3 aimDirection = (aimTarget - transform.position).normalized;

            //rotate player while aiming
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        } else {
            gun.SetActive(false);
            isAiming = false;
            aimCamera.gameObject.SetActive(false);
            tpController.SetSensitivity(standardSensitivity);
            tpController.SetRotateOnMove(true);
            pAnimator.SetLayerWeight(1, Mathf.Lerp(pAnimator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));          

        }    

        if (startAssInput.shoot && isAiming) { // u can shoot only if ur aiming
            
            if (hitTransform != null) { // if i hit something     
                AudioSource.PlayClipAtPoint(shoot, transform.position, ShootAudioVolume);

                if (hitTransform.GetComponent<TargetOrNot>() != null) { // we use that Script to identify a target
                    Instantiate(vfxHitted, mousePosition, Quaternion.identity); // hit a target
                    Debug.Log("HIT A TARGET!!");
                    
                    SpawnExplosion(raycastHit.point, raycastHit.transform);

                } else { // hit something else
                    Instantiate(vfxNotHitted, mousePosition, Quaternion.identity);
                    Debug.Log("HIT SOMETHING!!");
                   
                    SpawnExplosion(raycastHit.point, raycastHit.transform);
                } 
            }
            startAssInput.shoot = false;
        }
        //TODO: se si spara senza mirare, e si mira subito dopo, è come se si fosse sparato in quell'istante
        // perchè i gameObject vfx rimangono in vita per qualche istante

        //Se colpisce qualcosa -> animazione esplosione
    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        EnemyExplosion temp = target.GetComponent<EnemyExplosion>();
            if(temp != null)
            {
             temp.AddForce(hitPosition, transform);
            }
    }
    
    }
}
