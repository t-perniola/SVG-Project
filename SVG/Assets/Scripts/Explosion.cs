using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField]GameObject explosion;
    [SerializeField]float destroyTime = 6f;
    //Quaternion usato per identificare rotazioni
    public void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, destroyTime);
    }

    //Spostamento alla collisione
    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
            IveBeenHit(contact.point);
    }
}
 
