using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionDialogUI : MonoBehaviour
{
    public String LevelIndex;
    [SerializeField] private DialogUI dialogUI;

    void OnTriggerEnter(Collider player)
    {
        dialogUI.gameObject.SetActive(true);

        if (player.gameObject.tag == "Player")
        {            
            dialogUI.yesBtn.onClick.AddListener(YesClicked);
            dialogUI.noBtn.onClick.AddListener(NoClicked);
        }

    }

    void YesClicked()
    {
        Hide();
        Debug.Log("Yes Clicked");
        SceneManager.LoadScene(LevelIndex);
    }

    void NoClicked()
    {
        Hide();
        Debug.Log("No Clicked");
    }

    private void Hide()
    {
        dialogUI.gameObject.SetActive(false);
    }
}
