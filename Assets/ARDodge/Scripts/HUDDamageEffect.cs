using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HUDDamageEffect : MonoBehaviour
{
    public float initialIntensity = 0.0F;
    public float maxIntensity = 1.3F;
    public float intensityStepPerMicroSecond = 0.2F;
    public string shaderIntensityValueName = "_EffectIntensity";

    private Image HUD;
    private IEnumerator effectCoroutine;
    private float effectIntensity;

    private void Start()
    {
        HUD = GetComponent<Image>();
        HUD.material = new Material(HUD.material);
    }

    public void PlayDamageEffect()
    {
        if (effectCoroutine != null) StopCoroutine(effectCoroutine);
        StartCoroutine(effectCoroutine = OnDamageEffect());
    }

    private IEnumerator OnDamageEffect()
    {
        effectIntensity = maxIntensity;
        while (initialIntensity < effectIntensity)
        {
            yield return new WaitForSeconds(0.01F);
            HUD.material.SetFloat(shaderIntensityValueName, effectIntensity);
            effectIntensity -= intensityStepPerMicroSecond;
        }
        HUD.material.SetFloat(shaderIntensityValueName, initialIntensity);

        yield return null;
    }
}
