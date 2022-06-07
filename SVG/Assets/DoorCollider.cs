using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public Animator _doorAnim;

    private void OnTriggerEnter(DoorCollider other)
    {
        _doorAnim.SetBool("character_nearby", true);
    }

    private void OnTriggerExit(DoorCollider other)
    {
        _doorAnim.SetBool("character_nearby", false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
