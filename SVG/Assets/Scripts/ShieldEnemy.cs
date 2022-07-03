using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        healthBar = GetComponentInChildren<ShieldEnemyUI>();
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

        //healthBar.SetHealthBarPercentage(curHealth / maxHealth);
      
            EventManager.EnemyTakingDamage(curHealth / maxHealth);   
        
        
    }

    public void TakeDamage(float dmg = 1f)
    {
    Debug.Log("Il nemico prende danno");
    curHealth -= dmg;
    if(curHealth < 0)
    {
        curHealth = 0;
    }
    
        EventManager.EnemyTakingDamage(curHealth / maxHealth); 
    //healthBar.SetHealthBarPercentage(curHealth / maxHealth);
    
    if(curHealth < 1)
    {   
        GetComponent<EnemyExplosion>().BlowUp();
        //remove life from counter 
        //animator.SetTrigger("Die");
        healthBar.gameObject.SetActive(false);
        Debug.Log("I died");

        if(subject.tag == "Boss")
            {
                SceneManager.LoadScene("WinScreen");
            }
    }
        
    }



}