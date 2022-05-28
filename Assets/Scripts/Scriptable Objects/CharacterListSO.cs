using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterList", menuName = "ScriptableObjects/Character List")]
public class CharacterListSO : ScriptableObject
{
    public List<CharacterBaseSO> charList = new List<CharacterBaseSO>();
    public CharacterBaseSO[] charArray;
}