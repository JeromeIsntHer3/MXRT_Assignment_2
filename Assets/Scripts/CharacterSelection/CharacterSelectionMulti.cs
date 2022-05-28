using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterSelectionMulti : MonoBehaviour
{
    public CharacterBaseSO _currSelectedCharacter;

    [Header("Inspector Fill")]
    public CharacterListSO characters;
    [SerializeField] private GameObject emptyCharSlot;
    [HideInInspector] public GameObject charPanel;

    [Header("Display Current Selected Character")]
    [HideInInspector] public TextMeshProUGUI characterDisplayName;
    [HideInInspector] public TextMeshProUGUI characterDisplayDesc;
    [HideInInspector] public TextMeshProUGUI characterDisplayPoints;
    public Transform characterSpot;
    [SerializeField] private GameObject selectButton;
    [SerializeField] private GameObject tradeButton;

    void OnEnable()
    {
        ClearSlots();
        SetInfoAndButton("", "", "", false,false);
        MakeSlots();
    }
    void Start()
    {
        SetInfoAndButton("", "", "", false,false);
    }

    void Update()
    {
        if(charPanel.transform.childCount <= 0)
        {
            SetInfoAndButton("", "", "", false,false);
        }
    }

    public void MakeSlots()
    {
        if (charPanel)
        {
            for(int i = 0; i < characters.charList.Count; i++)
            {
                GameObject temp =
                        Instantiate(emptyCharSlot,
                        charPanel.transform.position, Quaternion.identity,charPanel.transform);
                temp.transform.SetParent(charPanel.transform);
                CharacterSlot newSlot = temp.GetComponent<CharacterSlot>();
                if (newSlot)
                {
                    newSlot.Setup(characters.charList[i], this);
                }
            }
        }
    }
    
    public void ClearSlots()
    {
        for (int i = 0; i < charPanel.transform.childCount; i++)
        {
            Destroy(charPanel.transform.GetChild(i).gameObject);
        }
    }

    public void SetInfoAndButton(string newName, string newDesc, string newPoints, bool isButton,bool isTrade)
    {
        characterDisplayName.text = newName;
        characterDisplayDesc.text = newDesc;
        characterDisplayPoints.text = newPoints;
        selectButton.SetActive(isButton);
        tradeButton.SetActive(isTrade);
    }

    public void SelectCharacter()
    {
        RemoveCurrCharModel();
        AddCurrentCharModel();
    }

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

    public void AddCurrentCharModel()
    {
        if (characters.charList.Count != 0)
        {
            GameObject model = Instantiate(_currSelectedCharacter.characterModel, characterSpot.position, Quaternion.identity);
            model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            model.transform.SetParent(characterSpot);
        }
    }

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