using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    //The image of the character 
    [SerializeField] private Image charImage;

    [Header("Variables from the Char")]
    //Reference the current char for this particular slot
    private CharacterBaseSO thisChar;
    //Reference the function of the Multi Class
    private CharacterSelectionMulti thisManager;

    //Takes in the the new char and manager and changes  the character image
    public void Setup(CharacterBaseSO newChar, CharacterSelectionMulti newManager)
    {
        thisChar = newChar;
        thisManager = newManager;
        if (thisChar)
        {
            charImage.sprite = thisChar.characterSprite;
        }
    }

    //if the slot is clicked on display the current information
    public void ClickedOn()
    {
        if (thisChar)
        {
            //check if the character does exist and then set in the ifnormation about it 
            thisManager.SetInfoAndButton(thisChar.characterName, thisChar.characterDesc, thisChar.characterPoints.ToString(), true,true);
        }
        //this is to tell the system what character is currrently is being selected
        thisManager._currSelectedCharacter = thisChar;
    }
}