﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public string[] NoteData;
    public Transform[] GeneratePos;
    public GameObject NotePrefab;
    MemoryPool NotePool;
    Queue<string> timeLineQueue;
    private void Awake()
    {
        NotePool = new MemoryPool(NotePrefab, 20, 50);
        NoteData = File.ReadAllLines(Application.streamingAssetsPath + "/test.txt");
        timeLineQueue = new Queue<string>(NoteData.Length);
        foreach (var note in NoteData)
        {
            //Debug.Log(note);
            timeLineQueue.Enqueue(note);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        string[] data = timeLineQueue.Peek().Split("/".ToCharArray()[0]);

        if (float.Parse(data[0]) <= Time.time)
        {
            for(int loopCount = 1; loopCount < data.Length; loopCount++)
            {
                NotePool.Respawn(GeneratePos[int.Parse(data[loopCount])].position, Quaternion.identity);
                //Instantiate(NotePrefab, GeneratePos[int.Parse(data[loopCount])]);
                Debug.Log($"Generate note at {int.Parse(data[loopCount])}, Time : {Time.time}");
            }
            timeLineQueue.Dequeue();
        }
        //Debug.Log(data[0]);
        //Debug.Log(Time.time);
        //if(data[0].Equals(Time.))
    }
}