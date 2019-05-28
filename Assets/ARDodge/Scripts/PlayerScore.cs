using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshPro))]
public class PlayerScore : MonoBehaviour
{
    public float initialScale = 1.0F;
    public float effectScaleMultiplicator = 1.3F;
    public float scaleEffectStepPerMicroSecond = 0.2F;

    private TMPro.TextMeshPro textMesh;
    private IEnumerator effectScaleCoroutine;
    private float effectScaleScale;

    private int m_score;

    private void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        textMesh.text = "00000000";
    }

    private void PlayScaleEffect()
    {
        if (effectScaleCoroutine != null) StopCoroutine(effectScaleCoroutine);
        StartCoroutine(effectScaleCoroutine = OnScaleEffect());
    }

    public int score 
    { 
        get { return m_score; }
        set
        {
            if (m_score != value)
            {
                m_score = value;
                textMesh.text = String.Format("{0:0000000}", m_score);
                PlayScaleEffect();
            }
        }    
    }

    private IEnumerator OnScaleEffect()
    {
        effectScaleScale = initialScale * effectScaleMultiplicator;
        while (initialScale < effectScaleScale)
        {
            yield return new WaitForSeconds(0.01F);
            textMesh.fontSize = effectScaleScale;
            effectScaleScale -= scaleEffectStepPerMicroSecond;
        }
        textMesh.fontSize = initialScale;

        yield return null;
    }
}
