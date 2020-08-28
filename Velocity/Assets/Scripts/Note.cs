using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour, IDespawnable
{
    public int score;
    public float speed;
    [SerializeField] Button button;
    [SerializeField] Canvas canvas;
    Image buttonImage;

    public event Action<GameObject> OnDespawn;

    void Awake()
    {
        canvas.worldCamera = Camera.main;
        buttonImage = button.GetComponent<Image>();
        OnDespawn += ResetStatus;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        buttonImage.fillAmount = 0.0f;
        StartCoroutine(RotateButton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Despawn()
    {
        StopCoroutine(RotateButton());
        OnDespawn(gameObject);
    }

    void ResetStatus(GameObject gameObject)
    {
        buttonImage.fillAmount = 0.0f;
    }

    private IEnumerator RotateButton()
    {
        while (gameObject.activeSelf)
        {
            buttonImage.fillAmount += 0.002f;
            yield return new WaitForEndOfFrame();
        }
    }
}
