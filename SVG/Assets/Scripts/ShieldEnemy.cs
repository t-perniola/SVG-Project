using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : MonoBehaviour
{
    [SerializeField] float maxHealth = 10f;
    [SerializeField] float curHealth = 0.0f;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerateAmount = 1;
    [SerializeField] GameObject subject;
    ShieldEnemyUI healthBar;
    Animator animator;

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

        healthBar.SetHealthBarPercentage(curHealth / maxHealth);
        /*if(subject.tag == "Player")
        {
            EventManager.TakingDamage(curHealth / (float)maxHealth);   
        }*/
        
    }

    public void TakeDamage(float dmg = 1f)
    {
    curHealth -= dmg;
    if(curHealth < 0)
    {
        curHealth = 0;
    }
    healthBar.SetHealthBarPercentage(curHealth / maxHealth);
    
    if(curHealth < 1)
    {   
        GetComponent<Explosion>().BlowUp();
        //remove life from counter 
        animator.SetBool("Die", true);
        healthBar.gameObject.SetActive(false);
        Debug.Log("I died");
    }
        
    }



}