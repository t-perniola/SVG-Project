using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class BoostLight : MonoBehaviour
{
    Light boostLight;
    
    // Start is called before the first frame update
    void Awake()
    {
        boostLight = GetComponent<Light>();
    }

    void Start()
    {
        boostLight.enabled = false;
    }
    // Update is called once per frame
    public void Activate(bool activate = true)
    {
        if(activate)
        {
            boostLight.enabled = true;
        }
        else
        {
            boostLight.enabled = false;
        }
    }
}
