using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//Scriptable object to hold the information to each character that will be placed in a script
[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character")]
public class CharacterBaseSO : ScriptableObject
{
    public string characterName;
    public GameObject characterModel;
    public Sprite characterSprite;
    public int characterPoints;
    public string characterDesc;
}