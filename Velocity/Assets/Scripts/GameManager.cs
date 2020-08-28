using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int TotalScore;
    public int Combo;

    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI ComboBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.text = $"Score : {TotalScore}";

        if (Combo != 0)
        {
            ComboBoard.text = $"{Combo} Hit!";
        }
        else
        {
            ComboBoard.text = "Break!!";
        }

    }
}
