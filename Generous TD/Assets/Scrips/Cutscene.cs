using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] public string[] Words;
    [SerializeField] public TextMeshProUGUI Words_UI_Text;
    int Count = 0;
    [SerializeField] public int End;
    [SerializeField] GameObject Game_UI;
    [SerializeField] GameObject Talk_UI;
    void Start()
    {
        Words_UI_Text.text = Words[Count].ToString();
    }

    public void Talk()
    {
        Count++;
        if (Count != End)
        {
            Words_UI_Text.text = Words[Count].ToString();
        }
        else
        {
            Game_UI.SetActive(true);
            Talk_UI.SetActive(false);
        }
    }
}
