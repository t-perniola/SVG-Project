using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionDialog : MonoBehaviour
{
    [SerializeField] private InteractionUI interactionUI;
    [SerializeField] private string name;
    [SerializeField] private string text;

    void Awake()
    {
        Hide();
    }
    void OnTriggerEnter(Collider player)
    {
        interactionUI.gameObject.SetActive(true);

        if (player.gameObject.tag == "Player")
        {
            Show();
            interactionUI.Text.text = text;
            interactionUI.Name.text = name;
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Hide();
            interactionUI.Text.text = "";
            interactionUI.Name.text = "";
        }
    }

    void Hide()
    {
        interactionUI.gameObject.SetActive(false);
    }

    void Show()
    {
        interactionUI.gameObject.SetActive(true);
    }
}
