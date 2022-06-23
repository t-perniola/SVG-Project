using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUI : MonoBehaviour
{
    [SerializeField]RectTransform barRectTransform;
    
    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        EventManager.redBoost += UpdateBoostDisplay;
    }

    void OnDisable()
    {
        EventManager.redBoost -= UpdateBoostDisplay;
    }

    void UpdateBoostDisplay(float percentage)
    {
        if(GameObject.FindWithTag("Player"))
        {
          barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 50f);     
        }
        
    }
}