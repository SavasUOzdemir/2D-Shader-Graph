using UnityEngine;
using System;
using System.Collections;

public class testscript : MonoBehaviour
{
    Material material;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    bool isFading = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        isFading = true;
        float materialFade = material.GetFloat("_Fade");
        float targetFade = materialFade >= 0.5f ? 0.0f : 1.0f; // Determine target fade based on initial value

        while (Mathf.Abs(materialFade - targetFade) > 0.01f)
        {
            // Use Time.deltaTime as the interpolation factor for smooth fading
            materialFade = Mathf.MoveTowards(materialFade, targetFade, Time.deltaTime);

            material.SetFloat("_Fade", materialFade);
            yield return null;
        }

        material.SetFloat("_Fade", targetFade);
        isFading = false;
    }

}
