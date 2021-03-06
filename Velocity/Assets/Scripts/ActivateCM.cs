﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ActivateCM : MonoBehaviour
{
    public PlayableDirector director;
    [SerializeField]
    string tagName = "Player";

    public PlayerMoveController Player;

    bool isPlayOnce = false;


    void Awake()
    {
        director.played += PlayerStopOn;
        director.stopped += PlayerStopOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayOnce && collision.CompareTag(tagName))
        {
            director.played += PlayerStopOn;
            director.stopped += PlayerStopOff;
            isPlayOnce = true;
            director.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagName))
        {
            if (director.state.Equals(PlayState.Playing))
            {
                Debug.Log("ON");
                Player.isPlayed = false;
            }
            else
            {
                Player.isPlayed = true;
            }
        }

    }

    private void PlayerStopOn(PlayableDirector playable)
    {
        Player.isPlayed = false;
    }

    private void PlayerStopOff(PlayableDirector playable)
    {
        Player.isPlayed = true;
    }
}