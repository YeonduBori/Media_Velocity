using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public int Index;
    Camera camera;
    float min;
    float max;
    WaitForSeconds term = new WaitForSeconds(0.15f);
    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
    }

    private void Start()
    {
        StartCoroutine(ElevateObject());
    }
    // Update is called once per frame
    void Update()
    {
        min = GameManager.instance.Min;
        max = GameManager.instance.Max;
    }

    private IEnumerator ElevateObject()
    {
        while (GameManager.instance.gameStatus.Equals(GameStatus.OnGoing))
        {
            float height = GameManager.instance.ViewPortHeight;
            transform.position 
                = camera.ViewportToWorldPoint(new Vector3(1.0f/7.0f * Index, height, camera.nearClipPlane + 1));
            yield return term;
        }
    }
}
