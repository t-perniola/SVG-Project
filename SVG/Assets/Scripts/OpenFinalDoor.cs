using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFinalDoor : MonoBehaviour
{
    public GameObject boss;
    //public Animator animator;
    public GameObject door2up;
    public GameObject door2down;
    public GameObject collisore;
    // Start is called before the first frame update
    void Start()
    {
       // boss = GetComponent<GameObject>();
        //door2up = GetComponent<GameObject>();
        //door2down = GetComponent<GameObject>();
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
        {
            door2up.SetActive(false);
            door2down.SetActive(false); 
            collisore.SetActive(false);   
        }
        else
        {
            Debug.Log("Il boss è vivo");
        }
    }
}
