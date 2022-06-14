using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [SerializeField]RectTransform barRectTransform;
    
    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;
    }

    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }

    void UpdateShieldDisplay(float percentage)
    {
        if(GameObject.FindWithTag("Player"))
        {
          barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 50f);     
        }
        
    }
}
