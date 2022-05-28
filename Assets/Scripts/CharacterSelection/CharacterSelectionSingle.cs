using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelectionSingle : MonoBehaviour
{
    private CharacterBaseSO _currSelectedCharacter;

    [Header("Display Current Selected Character")]
    [SerializeField] private TextMeshProUGUI characterDisplayName;
    [SerializeField] private TextMeshProUGUI characterDisplayDesc;
    [SerializeField] private Image characterDisplayImage;
    [SerializeField] private TextMeshProUGUI characterDisplayPoints;
    [SerializeField] private Transform characterSpot;
    [SerializeField] private GameObject[] displayInfo;


    [Header("Character Database")]
    [SerializeField] public CharacterListSO characters;

    //Index
    public int selectedOption = 0;

    private void OnEnable()
    {
        UpdateCharInfo(selectedOption);
    }

    private void Start()
    {
        UpdateCharInfo(0);
    }
    private void Update()
    {
        TurnOffButtons();
    }

    #region Character Display Functions
    public void SetNextCharacter()
    {
        selectedOption++;

        if(selectedOption >= characters.charList.Count)
        {
            selectedOption = 0;
        }
        UpdateCharInfo(selectedOption);
    }

    public void SetPrevCharacter()
    {
        selectedOption--;


        if (selectedOption < 0)
        {
            selectedOption = characters.charList.Count - 1;
        }
        UpdateCharInfo(selectedOption);
    }

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
        if (characters.charList.Count == 0)
        {
            foreach(GameObject go in displayInfo)
            {
                go.SetActive(false);
            }
        }
    }
    
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
    
    public void SelectCharacter()
    {
        RemoveCurrCharModel();
        AddCurrentCharModel();
    }

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