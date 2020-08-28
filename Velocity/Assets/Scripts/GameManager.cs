using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public int TotalScore;
    public int Combo;

    public float Min;
    public float Max;
    public float ViewPortHeight;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI ComboBoard;

    public GameStatus gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameStatus.OnGoing;
        StartCoroutine(heightChangeAsync());
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

    private IEnumerator heightChangeAsync()
    {
        while (gameStatus.Equals(GameStatus.OnGoing))
        {
            ViewPortHeight = Random.Range(Min, Max);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
