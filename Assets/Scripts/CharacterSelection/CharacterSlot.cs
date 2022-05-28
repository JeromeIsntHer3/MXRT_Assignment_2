using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private Image charImage;

    [Header("Variables from the Char")]
    private CharacterBaseSO thisChar;
    private CharacterSelectionMulti thisManager;

    public void Setup(CharacterBaseSO newChar, CharacterSelectionMulti newManager)
    {
        thisChar = newChar;
        thisManager = newManager;
        if (thisChar)
        {
            charImage.sprite = thisChar.characterSprite;
        }
    }

    public void ClickedOn()
    {
        if (thisChar)
        {
            thisManager.SetInfoAndButton(thisChar.characterName, thisChar.characterDesc, thisChar.characterPoints.ToString(), true,true);
        }
        thisManager._currSelectedCharacter = thisChar;
        Debug.Log(thisManager._currSelectedCharacter);
    }
}