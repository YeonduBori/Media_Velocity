using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    PlayableDirector director;
    GameObject pianist;
    GameObject player;
    public GameObject pianistPos;
    public GameObject playerPos;

    void Awake()
    {
        pianist = FindObjectOfType<PlayerMoveController>().gameObject;
        player = FindObjectOfType<PianistAIScript>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        director = gameObject.GetComponent<PlayableDirector>();
        director.played += Ending;
        director.stopped += GoToNextScene;
    }

    void Ending(PlayableDirector playableDirector)
    {
        Debug.Log("EndingOn");
        pianist.SetActive(false);
        player.SetActive(false);
        pianistPos.SetActive(true);
        playerPos.SetActive(true);
    }

    void GoToNextScene(PlayableDirector playableDirector)
    {
        StopAllCoroutines();
        SceneManager.LoadSceneAsync("MainGameScene", LoadSceneMode.Single);
    }
}
