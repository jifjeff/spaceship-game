using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MainMenu mainMenu;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSelected(gameObject.name.ToString());

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mainMenu.campaignText.color = Color.black;
        mainMenu.scoreText.color = Color.black;
        mainMenu.exitText.color = Color.black;
    }

    void buttonSelected(string g)
    {
        switch (g)
        {
            case "Campaign":
                mainMenu.campaignText.color = Color.red;
                break;
            case "Score":
                mainMenu.scoreText.color = Color.green;
                break;
            case "Exit Game":
                mainMenu.exitText.color = Color.gray;
                break;
        }
    }
}
