using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceUi : MonoBehaviour
{
    bool isDisplayed = true;
    [SerializeField]GameObject playButton;
    void OnEnable()
    {
        EventManager.onSpaceFightGame += HidePanel;
    }

    void OnDisable()
    {
        EventManager.onSpaceFightGame -= HidePanel;
    }    
    void HidePanel()
    {
        isDisplayed = !isDisplayed;
        playButton.SetActive(isDisplayed);
    }

    public void PlayGame()
    {
        Debug.Log("Start the Game");
        EventManager.StartGame();
    }
}
