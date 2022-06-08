using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelectionSingle : MonoBehaviour
{
    //hold the currSelectedCharacter
    private CharacterBaseSO _currSelectedCharacter;


    [Header("Display Current Selected Character")]
    //Reference the object that will display the name
    [SerializeField] private TextMeshProUGUI characterDisplayName;
    //Reference the object that will display the desc
    [SerializeField] private TextMeshProUGUI characterDisplayDesc;
    //Reference the object that will display the image
    [SerializeField] private Image characterDisplayImage;
    //Reference the object that will display the points
    [SerializeField] private TextMeshProUGUI characterDisplayPoints;
    //Reference the object the transform where the selected character will be instantiated
    [SerializeField] private Transform characterSpot;
    //Reference all the info display objects and set into an array
    [SerializeField] private GameObject[] displayInfo;


    [Header("Character Database")]
    //Reference the list and array of characters
    [SerializeField] public CharacterListSO characters;
    
    //Index of the currSelectedChar
    public int selectedOption = 0;

    private void OnEnable()
    {
        //Set the character info according to the selctedOptions
        UpdateCharInfo(selectedOption);
    }

    private void Start()
    {
        //Set the first character to show up as element 0
        UpdateCharInfo(0);
    }
    private void Update()
    {
        //turns off the buttons when there is no characters left in the list
        TurnOffButtons();
    }

    #region Character Display Functions

    //have the the int increase everytime it runs
    //and set it back to 0 once it reaches the list count
    public void SetNextCharacter()
    {
        selectedOption++;

        if(selectedOption >= characters.charList.Count)
        {
            selectedOption = 0;
        }
        UpdateCharInfo(selectedOption);
    }

    //have the int decrease everytime it runs
    //and set it to the list.count - 1 so that
    //it doesnt exceed the list elements
    public void SetPrevCharacter()
    {
        selectedOption--;


        if (selectedOption < 0)
        {
            selectedOption = characters.charList.Count - 1;
        }
        UpdateCharInfo(selectedOption);
    }

    //Takes in the selectedOption int and sets up the information
    //according to the CharacterBaseSO that is within that elemnent
    void UpdateCharInfo(int selectedOption)
    {
        _currSelectedCharacter = characters.charList[selectedOption];

        characterDisplayName.text = _currSelectedCharacter.characterName;
        characterDisplayImage.sprite = _currSelectedCharacter.characterSprite;
        characterDisplayPoints.text = "Points: " + _currSelectedCharacter.characterPoints;
        characterDisplayDesc.text = _currSelectedCharacter.characterDesc;
        Debug.Log(selectedOption);
    }
    #endregion

    #region Button Functions
    void TurnOffButtons()
    {
        //if there are no remaining characters,
        //set the buttons to be false
        if (characters.charList.Count == 0)
        {
            foreach(GameObject go in displayInfo)
            {
                go.SetActive(false);
            }
        }
    }
    
    //Trade in the character which removes it from the
    //list and the scene and replacing the info to default values
    //if there are no characters left
    public void TradeIn()
    {
        if(characters.charList.Count != 0)
        {
            characters.charList.RemoveAt(selectedOption);
        }
        else
        {

        }
        if(characters.charList.Count != 0)
        {
            RemoveCurrCharModel();
            UpdateCharInfo(0);
        }
        else
        {
            RemoveCurrCharModel();
            characterDisplayName.text = "You Have No Characters";
            characterDisplayImage.sprite = null;
            characterDisplayPoints.text = "";
            characterDisplayDesc.text = "Purchase Hotel Amenities To Unlock Characters";
        }
    }
    
    //Removes the curr model in scene and replaces the currently 
    //selected character model
    public void SelectCharacter()
    {
        RemoveCurrCharModel();
        AddCurrentCharModel();
    }

    //Checks if any model in scene and if there is remove it
    void RemoveCurrCharModel()
    {
        if (characterSpot.childCount != 0)
        {
            foreach (Transform child in characterSpot.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    //Checks if any model is in scene and if there isnt, add currselectedcharacter model into scene
    void AddCurrentCharModel()
    {
        if (characters.charList.Count != 0)
        {
            GameObject model = Instantiate(_currSelectedCharacter.characterModel, characterSpot.position, Quaternion.identity);
            model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            model.transform.SetParent(characterSpot);
        }
    }
    #endregion
}