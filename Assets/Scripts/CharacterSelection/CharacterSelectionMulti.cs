using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//This script is used to display the characters that the user has in a grid format on the grid menu
public class CharacterSelectionMulti : MonoBehaviour
{
    //This is used to hold curr character selected so that it can be instantiated
    //This is public to set the character slot information when referenceing the SO
    public CharacterBaseSO _currSelectedCharacter;

    [Header("Inspector Fill")]
    //Reference the list of characters from the List SO
    public CharacterListSO characters;
    //Reference the slot Prefab that will be filled with info when instantiated
    [SerializeField] private GameObject emptyCharSlot;
    //Reference the parent that the slot will be instantiated to
    public GameObject charPanel;

    [Header("Display Current Selected Character")]
    //Reference the empty info that will be filled up later 
    [HideInInspector] public TextMeshProUGUI characterDisplayName, characterDisplayDesc, characterDisplayPoints;
    //Reference the spot that the character model will be instantiated
    public Transform characterSpot;

    [Header("System Stuff")]
    //Reference the buttons that will be used to instantiate the model and
    //to trade in the curr selected character
    [SerializeField] private GameObject selectButton;
    [SerializeField] private GameObject tradeButton;

    void OnEnable()
    {
        //when the grid layout opens up:
        //1. Clear the slots so that no repeating slots will be made
        //2. Set Info and Buttons to be empty and not active since nothing is selected
        //3. Remake the slots according to the updated list
        ClearSlots();
        SetInfoAndButton("", "", "", false,false);
        MakeSlots();
    }
    void Start()
    {
        //Set the default values to empty and not active
        SetInfoAndButton("", "", "", false,false);
    }

    void Update()
    {
        //If there are no characters left in the list set default values
        if(charPanel.transform.childCount <= 0)
        {
            SetInfoAndButton("", "", "", false,false);
        }
    }

    public void MakeSlots()
    {
        //check if charPanel exists
        if (charPanel)
        {
            //create a slot for every character existing within the list
            for(int i = 0; i < characters.charList.Count; i++)
            {
                //create a temp go. that holds the 'emptySlot' and set it's transform according
                //to the 'charPanel' parent
                GameObject temp =
                        Instantiate(emptyCharSlot,
                        charPanel.transform.position, Quaternion.identity,charPanel.transform);
                temp.transform.SetParent(charPanel.transform);
                //Reference the CharacterSlot class within the instantiated go. 
                CharacterSlot newSlot = temp.GetComponent<CharacterSlot>();
                //if there a slot setup the character
                if (newSlot)
                {
                    newSlot.Setup(characters.charList[i], this);
                }
            }
        }
    }
    
    //Clear all the remaining/existing slots by referening the children of the charPanel
    public void ClearSlots()
    {
        for (int i = 0; i < charPanel.transform.childCount; i++)
        {
            Destroy(charPanel.transform.GetChild(i).gameObject);
        }
    }

    //take in values from the CharacterBaseSo and display them onto the UI
    //and set the buttons to being actively when the slot is selected
    public void SetInfoAndButton(string newName, string newDesc, string newPoints, bool isButton,bool isTrade)
    {
        characterDisplayName.text = newName;
        characterDisplayDesc.text = newDesc;
        characterDisplayPoints.text = newPoints;
        selectButton.SetActive(isButton);
        tradeButton.SetActive(isTrade);
    }

    //Remove any model currently remaining in the scene 
    //and then add the new selected model
    public void SelectCharacter()
    {
        RemoveCurrCharModel();
        AddCurrentCharModel();
    }

    //Check if there is any children from the characterSpot
    //and if there is destory it
    public void RemoveCurrCharModel()
    {
        if (characterSpot.childCount != 0)
        {
            foreach (Transform child in characterSpot.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    //Check if there are any children in the characterSpot
    //and if there are none, add in the new selected model
    //and instantiate it to the position
    public void AddCurrentCharModel()
    {
        if (characters.charList.Count != 0)
        {
            GameObject model = Instantiate(_currSelectedCharacter.characterModel, characterSpot.position, Quaternion.identity);
            model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            model.transform.SetParent(characterSpot);
        }
    }

    //Button function that removes the currSelectedCharacter
    //when the user once to trade in the character
    public void TradeIn()
    {
        if (_currSelectedCharacter)
        {
            Debug.Log(_currSelectedCharacter);
            characters.charList.Remove(_currSelectedCharacter);
            _currSelectedCharacter = null;
            //Clear all of the inventory slots
            ClearSlots();
            //Refill all slots with new numbers
            MakeSlots();
        }
    }
}