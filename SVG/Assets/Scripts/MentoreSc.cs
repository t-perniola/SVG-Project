using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentoreSc : MonoBehaviour
{
    public GameObject canvasComandi;
    // Start is called before the first frame update
    void Start()
    {
        canvasComandi.SetActive(false);
    }

    public void ShowCommands()
    {
        canvasComandi.SetActive(true);
    }

    public void ExitCommands()
    {
        canvasComandi.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
