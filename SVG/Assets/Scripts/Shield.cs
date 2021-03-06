using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shield : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int curHealth;
    [SerializeField] float regenerationRate = 2f;
    [SerializeField] int regenerateAmount = 1;
    [SerializeField] GameObject subject;
     

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
        
        if(subject.tag == "Player")
        {
            EventManager.TakingDamage(curHealth / (float)maxHealth);   
        }
        
    }

    public void TakeDamage(int dmg = 1)
    {
    curHealth -= dmg;
    if(curHealth < 0)
    {
        curHealth = 0;
    }
    if(subject.tag == "Player"){
     EventManager.TakingDamage(curHealth / (float)maxHealth);  
    }
    
    if(curHealth < 1)
    {   
        GetComponent<Explosion>().BlowUp();
        //remove life from counter 

       
        Debug.Log("I died");

        if (subject.tag == "Player")
            {
                SceneManager.LoadScene("LoseScreen");
            }
    }
        
    }



}

