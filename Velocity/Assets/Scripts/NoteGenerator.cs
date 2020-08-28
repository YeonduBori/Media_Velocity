using System.IO;
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
        if(timeLineQueue.Count != 0)
        {
            string[] data = timeLineQueue.Peek().Split("/".ToCharArray()[0]);

            if (float.Parse(data[0]) <= Time.time)
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
