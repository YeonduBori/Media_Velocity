using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public string[] NoteData;
    public Transform[] GeneratePos;
    public GameObject NotePrefab;
    public AudioSource MusicSource;

    MemoryPool NotePool;
    Queue<string> timeLineQueue;
    float timeStamp;
    private void Awake()
    {
        NotePool = new MemoryPool(NotePrefab, 20, 30);
#if UNITY_EDITOR
        NoteData = File.ReadAllLines(Path.Combine(Application.streamingAssetsPath, "test.txt"));
#elif UNITY_ANDROID
        WWW reader = new WWW(Path.Combine(Application.streamingAssetsPath, "test.txt"));
        while (!reader.isDone) { }

        string realPath = Application.persistentDataPath + "/db";
        File.WriteAllBytes(realPath, reader.bytes);

        NoteData = File.ReadAllLines(realPath);
#endif
        timeLineQueue = new Queue<string>(NoteData.Length);
        foreach (var note in NoteData)
        {
            //Debug.Log(note);
            timeLineQueue.Enqueue(note);
        }
    }

    void Update()
    {
        if(timeLineQueue.Count != 0 && MusicSource.isPlaying)
        {
            timeStamp = Time.time;
            Debug.Log(timeStamp);
            string[] data = timeLineQueue.Peek().Split("/".ToCharArray()[0]);

            if (float.Parse(data[0]) <= Time.time - timeStamp)
            {
                for (int loopCount = 1; loopCount < data.Length; loopCount++)
                {
                    NotePool.Respawn(GeneratePos[int.Parse(data[loopCount])].position, Quaternion.identity);
                    Debug.Log($"Generate note at {int.Parse(data[loopCount])}, Time : {Time.time}");
                }
                timeLineQueue.Dequeue();
            }
        }
    }
}
