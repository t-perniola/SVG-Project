using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Trail : MonoBehaviour
{
    Light boostLight;
    void Awake()
    {
        boostLight = GetComponent<Light>();
    }

    
    void Start()
    {
        boostLight.enabled = false;
    }

    public void LightBoost(bool boosting){
        if(boosting == true){
            boostLight.enabled = true;
        } 
        else
        {
            boostLight.enabled = false;
        }
    }
}
