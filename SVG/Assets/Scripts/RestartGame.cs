using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartGame : MonoBehaviour
{
    public  GameObject canvasComandi;

    public void Start()
    {
        canvasComandi.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Base");
    }

    public void Comandi()
    {
        canvasComandi.SetActive(true);
    }
     public void Indietro()
    {
        canvasComandi.SetActive(false);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
