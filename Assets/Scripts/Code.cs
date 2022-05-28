using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Code : MonoBehaviour
{
    private string code;
    public TMP_InputField inputText;
    public TextMeshProUGUI errorText;
    public CharacterListSO characters;
    public CharacterSelectionMulti multi;
    public float timer = 2;

    void Update()
    {
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