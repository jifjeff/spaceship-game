using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button campaign;
    public Button scoreBtn;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    public void campaignMode()
    {

    }

    public void scoreMode()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
