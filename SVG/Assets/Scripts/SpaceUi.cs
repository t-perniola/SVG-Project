using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceUi : MonoBehaviour
{
    [SerializeField]GameObject gameUI;
    [SerializeField]GameObject mainMenu;

    [SerializeField]GameObject playerPrefab;
    [SerializeField]GameObject playerStartPosition;
    bool isDisplayed = true;
    
    void Start()
    {
        //Da decidere
        //ShowMainMenu();
        ShowGameUI();
        EventManager.StartGame();
        
    }

    void OnEnable()
    {
        EventManager.onSpaceFightGame += ShowGameUI;
        //EventManager.onPlayerDeath += ShowMainMenu;
    }

    void OnDisable()
    {
        EventManager.onSpaceFightGame -= ShowGameUI;
        //EventManager.onPlayerDeath -= ShowMainMenu;
    }    
  

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);    
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
       // Instantiate(playerPrefab, playerStartPosition.transform.position, playerStartPosition.transform.rotation);
    }

}
