using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField]GameObject explosion;
    [SerializeField]GameObject blowUp;
    [SerializeField]Rigidbody rigidBody;
    [SerializeField]float destroyTime = 6f;
    [SerializeField]float laserHitModifier = 0.5f;
    [SerializeField]Shield shield;
    
    //Quaternion usato per identificare rotazioni
    void IveBeenHit(Vector3 pos)
    {
        Debug.Log("Vengo colpito");
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, destroyTime);

        if(shield == null)
        {
            Debug.Log("Lo shield è nullo");
            return;
        }
        else
        {
            shield.TakeDamage();
        }
    }

    //Spostamento alla collisione
    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision.contacts)
        {
            Debug.Log("Collisione con oggetto");
            IveBeenHit(contact.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        IveBeenHit(hitPosition);
        Debug.LogWarning("AddForce: " + gameObject.name + " -> " + hitSource.name);
        if(rigidBody == null)
            return;
       /*   
        Vector3 forceVector = (hitSource.position - hitPosition).normalized;
        Debug.Log(forceVector * laserHitModifier);
        rigidBody.AddForceAtPosition(forceVector.normalized * laserHitModifier, hitPosition, ForceMode.Impulse);
        */    
    }


    public void BlowUp()
    {
        EventManager.PlayerDeath(); // chiama onPlayerDeath event
        //richiama effetto esplosione
        GameObject temp = Instantiate(blowUp, transform.position, Quaternion.identity) as GameObject;
        //Delay destroy the particle effect
        Destroy(temp, 6f);
        //aggiungi punteggio se richiesto (da fare in enemy script)
        //autodistruzione
        Destroy(gameObject);

    }
}
 
