using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormChangeMenuUI : MonoBehaviour
{
    FormChangeCardUI formChangeCardUI;

    // Game Object references for each of the required UI elements
    public GameObject mainMenu;
    public GameObject cardBaseOne;
    public GameObject cardBaseTwo;

    // Bools that determine if menus are already opened
    public bool mainMenuActive = false;
    public bool cardBaseTwoActive = false;
    public bool cardBaseOneActive = false;

    // Original scale of card UI elements, and bools to determine if they're scaled up
    private Vector3 cardBaseOneOriginalScale;
    private Vector3 cardBaseTwoOriginalScale;
    private bool isCardBaseOneEnlarged = false;
    private bool isCardBaseTwoEnlarged = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ensures the menu isn't active when the game begins, also determines the original scale of the cards
        mainMenu.SetActive(false); 
        cardBaseOneOriginalScale = cardBaseOne.transform.localScale;
        cardBaseTwoOriginalScale = cardBaseTwo.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ToggleMenu();
    }

    // Detects player input to turn the main menu off and on
    public void ToggleMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mainMenuActive = !mainMenuActive; 
            mainMenu.SetActive(mainMenuActive);  
        }
    }

    // Takes the original scale of the card and enlarges it by 1.5x, toggles the bool once enlarged
    public void ToggleCardSize(GameObject card, ref bool isEnlarged, Vector3 originalScale)
    {
        if (isEnlarged)
        {
            card.transform.localScale = originalScale; 
        }
        else
        {
            card.transform.localScale = originalScale * 1.5f; 
        }

        isEnlarged = !isEnlarged; 
    }

    // Event functionality for card 1 that will trigger the size change and check the state of the bools, as well as return it to original scale if clicked again
    public void OnCardBaseOneClick()
    {
        ToggleCardSize(cardBaseOne, ref isCardBaseOneEnlarged, cardBaseOneOriginalScale);
    }

    // Event functionality for card 2 that will trigger the size change and check the state of the bools, as well as return it to original scale if clicked again
    public void OnCardBaseTwoClick()
    {
        ToggleCardSize(cardBaseTwo, ref isCardBaseTwoEnlarged, cardBaseTwoOriginalScale);
    }
}
