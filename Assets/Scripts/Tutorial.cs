using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameManager gm;
    int textCount;
    public List<TextMeshProUGUI> menuTut = new List<TextMeshProUGUI>();
    public TextMeshProUGUI currMenuText;
    public GameObject charTut;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetNextText()
    {
        textCount++;

        if (textCount >= menuTut.Count)
        {
            textCount = 0;
        }
        UpdateMenuTutText(textCount);
    }

    public void SetPrevCharacter()
    {
        textCount--;


        if (textCount < 0)
        {
            textCount = menuTut.Count - 1;
        }
        UpdateMenuTutText(textCount);
    }

    void UpdateMenuTutText(int selectedOption)
    {
        currMenuText = menuTut[selectedOption];
    }
}