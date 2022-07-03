using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldEnemyUI : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [SerializeField]RectTransform barRectTransform;
    
    
    float maxWidth;
    

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        EventManager.onEnemyTakeDamage += UpdateShieldDisplay;
    }

    void OnDisable()
    {
        EventManager.onEnemyTakeDamage -= UpdateShieldDisplay;
    }

    void LateUpdate()
    {
        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }

    public void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 50f);
    }
}

