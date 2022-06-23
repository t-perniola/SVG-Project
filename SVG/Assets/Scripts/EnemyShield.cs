using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int curHealth;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerateAmount = 1;
    //[SerializeField]GameObject Explosion;

    void Start()
    {
        curHealth = maxHealth;

        InvokeRepeating("Regenerate", regenerationRate, regenerationRate);
    } 
   
    void Regenerate()
    {
        if(curHealth < maxHealth)
        {
            curHealth += regenerateAmount;
        }
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
            CancelInvoke();
        }
        
    }

    public void TakeDamage(int dmg = 1)
    {
    curHealth -= dmg;
    if(curHealth < 0)
    {
        curHealth = 0;
    }
    
    if(curHealth < 1)
    {   
        GetComponent<EnemyExplosion>().BlowUp();
        //remove life from counter 
        Debug.Log("Enemy died");
    }
        
    }



}
