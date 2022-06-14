using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartFightDelegate();
    public static StartFightDelegate onSpaceFightGame;
    public static StartFightDelegate onPlayerDeath;
    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;
     

    public static void StartGame()
    {
        if(onSpaceFightGame != null)
            onSpaceFightGame();
    }


    public static void TakingDamage(float percent)
    {
        Debug.Log("Take Damage: " + percent);
        if(onTakeDamage != null)
            onTakeDamage(percent);
    }

    public static void PlayerDeath()
    {
        Debug.Log("Player Died");
        if(onPlayerDeath != null)
            onPlayerDeath();
    }
}