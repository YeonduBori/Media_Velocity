using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DespawnEffect : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;
    public DespawnStatus status = DespawnStatus.Bad;
    [SerializeField] Text effectText;

    private void OnEnable()
    {
        effectText.color = new Color(1.0f, 0.9960784f, 0.9098039f, 1.0f);
        StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        yield return new WaitForEndOfFrame();
        effectText.text = status.ToString();
        switch (status)
        {
            case DespawnStatus.Bad:
                effectText.color = new Color(1.0f, 0.9960784f, 0.9098039f, 1.0f);
                break;
            case DespawnStatus.Good:
                effectText.color = new Color(1.0f, 0.9254902f, 0.6470588f, 1.0f);
                break;
            case DespawnStatus.Perfect:
                effectText.color = new Color(1.0f, 0.8156863f, 0.509804f, 1.0f);
                break;
        }
        while(effectText.color.a >= 0.0f)
        {
            Color textColor = effectText.color;
            effectText.color = new Color(textColor.r,textColor.g,textColor.b,textColor.a - 0.05f);
            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine(Effect());
        OnDespawn(gameObject);
    }
}
