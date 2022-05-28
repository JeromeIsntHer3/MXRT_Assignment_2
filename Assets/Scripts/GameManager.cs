using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CharacterListSO characters;
    public GameObject multi;
    public GameObject single;
    public GameObject newCharMenu;
    public bool firstTime;

    void Start()
    {
        ClearNCreateCharList();
        multi.SetActive(false);
        single.SetActive(true);
        FirstTime();
    }

    void Update()
    {
    }

    void ClearNCreateCharList()
    {
        characters.charList.Clear();
        foreach (CharacterBaseSO characterBaseSO in characters.charArray)
        {
            characters.charList.Add(characterBaseSO);
        }
    }

    public void SwapToMulti()
    {
        multi.SetActive(true);
        single.SetActive(false);
    }

    public void SwapToSingle()
    {
        multi.SetActive(false);
        single.SetActive(true);
    }

    public void NewCharacterMenu()
    {
        newCharMenu.SetActive(true);
    }

    public void CloseCharacterMenu()
    {
        newCharMenu.SetActive(false);
    }

    void FirstTime()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            firstTime = true;
            Debug.Log("First Time");
        }
        else
        {
            firstTime = false;
            Debug.Log("NOT First Time Opening");
        }
    }
}