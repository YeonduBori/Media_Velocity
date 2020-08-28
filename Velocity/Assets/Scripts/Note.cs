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
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        buttonImage.fillAmount = 0.0f;
        StartCoroutine(RotateButton());
    }
    
    public void Despawn()
    {
        StopCoroutine(RotateButton());
        float weight = 1;

        if (buttonImage.fillAmount >= 0.75f && buttonImage.fillAmount <= 1.0f)
        {
            //Perfect
            weight = 2.0f;
            GameObject DesapwnObject =
            GameManager.instance.DespawnPool.Respawn(transform.position, Quaternion.identity);
            DesapwnObject.GetComponent<DespawnEffect>().status = DespawnStatus.Perfect;
        }
        else if(buttonImage.fillAmount > 0.5f && buttonImage.fillAmount <= 0.75f)
        {
            //Good
            weight = 1.5f;
            GameObject DesapwnObject =
            GameManager.instance.DespawnPool.Respawn(transform.position, Quaternion.identity);
            DesapwnObject.GetComponent<DespawnEffect>().status = DespawnStatus.Good;
        }
        else
        {
            //Bad
            weight = 1.0f;
            GameManager.instance.Combo = 0;
            GameObject DesapwnObject =
            GameManager.instance.DespawnPool.Respawn(transform.position, Quaternion.identity);
            DesapwnObject.GetComponent<DespawnEffect>().status = DespawnStatus.Bad;
        }

        GameManager.instance.TotalScore += (int)(score * weight);
        GameManager.instance.Combo += 1;
        OnDespawn(gameObject);
    }

    private IEnumerator RotateButton()
    {
        while (gameObject.activeSelf)
        {
            buttonImage.fillAmount += speed;
            if(buttonImage.fillAmount >= 1.0f)
            {
                GameManager.instance.Combo = 0;
                StopCoroutine(RotateButton());
                OnDespawn(gameObject);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
