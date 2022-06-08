using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Create a list to hold the characters at runtime and an array to hold it during editor 
//to add the demo characters to the list at start 
//Since scriptable objects are independant of monobehaviour and lose info when changed
[CreateAssetMenu(fileName = "CharacterList", menuName = "ScriptableObjects/Character List")]
public class CharacterListSO : ScriptableObject
{
    public List<CharacterBaseSO> charList = new List<CharacterBaseSO>();
    public CharacterBaseSO[] charArray;
}