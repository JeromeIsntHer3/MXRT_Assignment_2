using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    //Reference where the player will input their text
    public TMP_InputField inputText;
    //Reference the text that will show when a code is input
    public TextMeshProUGUI errorText;
    //reference the list of characters SO 
    public CharacterListSO characters;
    //Reference the grid that hold the characters
    public CharacterSelectionMulti multi;
    //Create a timer to know when to turn off the text
    public float timer = 2;

    void Update()
    {
        //check if the text is active and if it is set
        //the timer to when it will be set to false
        if (errorText.gameObject.activeInHierarchy) 
        { 
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                errorText.gameObject.SetActive(false);
                timer = 2f;
            }
        }
    }

    //Check the code that the user input and add the related character to the list
    public void InputCode()
    {
        if (inputText.text != "")
        {
            switch (inputText.text)
            {
                case "2094":
                    NewCharacter(characters.charArray[0]);
                    break;
                case "1390":
                    NewCharacter(characters.charArray[1]);
                    break;
                case "1107":
                    NewCharacter(characters.charArray[2]);
                    break;
                case "5480":
                    NewCharacter(characters.charArray[3]);
                    break;
                case "9320":
                    NewCharacter(characters.charArray[4]);
                    break;
                case "9717":
                    NewCharacter(characters.charArray[5]);
                    break;
                default:
                    errorText.text = "Sorry, that code is unavailable! Try Another One.";
                    errorText.gameObject.SetActive(true);
                    break;
            }
        }
    }

    //Check if the same character is in the list and if so display an error message
    //if not add the character to the list and display the name
    void NewCharacter(CharacterBaseSO character)
    {
        if (characters.charList.Contains(character))
        {
            errorText.text = "Sorry You Already Have That Character";
            errorText.gameObject.SetActive(true);
        }
        else
        {
            errorText.text = "You have added " + character.characterName + " to your collection!";
            errorText.gameObject.SetActive(true);
            characters.charList.Add(character);
            multi.ClearSlots();
            multi.MakeSlots();
        }
    }
}