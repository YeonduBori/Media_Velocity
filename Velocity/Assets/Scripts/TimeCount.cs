using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    int time = 3;
    Text timeText;
    public GameObject PausePanel;
    WaitForSeconds term = new WaitForSeconds(1.0f);
    private void Awake()
    {
        timeText = GetComponent<Text>();
    }

    void OnEnable()
    {
        StartCoroutine(TimeTick());
    }

    private IEnumerator TimeTick()
    {
        for(int tick = 0; tick < 3; tick++)
        {
            timeText.text = $"{time - tick}";
            yield return term;
        }
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
        time = 3;
        StopCoroutine(TimeTick());
        gameObject.SetActive(false);
        FindObjectOfType<AudioSource>().Play();
    }
}
