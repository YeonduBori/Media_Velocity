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
    public Text ScoreBoard;
    public Text ComboBoard;

    public MemoryPool DespawnPool;
    public GameObject despawnPrefab;
    public GameStatus gameStatus;
    WaitForSeconds term = new WaitForSeconds(0.1f);
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameStatus.OnGoing;
        StartCoroutine(heightChangeAsync());
        DespawnPool = new MemoryPool(despawnPrefab, 20, 30);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.text = $"점수 {TotalScore}";

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
            yield return term;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }
}
