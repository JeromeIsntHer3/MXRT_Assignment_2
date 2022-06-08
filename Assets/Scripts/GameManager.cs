using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Reference the character list
    public CharacterListSO characters;
    //Reference the grid layout
    public GameObject multi;
    //Reference the single layout
    public GameObject single;
    //refernce the new Char menu
    public GameObject newCharMenu;

    void Start()
    {
        //Fill the list from the array
        ClearNCreateCharList();
        multi.SetActive(false);
        single.SetActive(true);
    }

    void Update()
    {
    }

    //Since SO are affected outside of runtime
    //refill the list the game runs for the first time
    void ClearNCreateCharList()
    {
        characters.charList.Clear();
        foreach (CharacterBaseSO characterBaseSO in characters.charArray)
        {
            characters.charList.Add(characterBaseSO);
        }
    }

    //Set the grid layout to show itself and have the single layout as off
    public void SwapToMulti()
    {
        multi.SetActive(true);
        single.SetActive(false);
    }

    //vise versa /\
    public void SwapToSingle()
    {
        multi.SetActive(false);
        single.SetActive(true);
    }

    //Sets up the character menu
    public void NewCharacterMenu()
    {
        newCharMenu.SetActive(true);
    }

    //Turns off the character menu
    public void CloseCharacterMenu()
    {
        newCharMenu.SetActive(false);
    }
}