using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashTime;

    private Coroutine damageFlashRoutine;

    private SpriteRenderer spriteRenderer;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        material = spriteRenderer.material;
    }

    public void CallDamageFlash()
    {
        Debug.Log("Called");
        damageFlashRoutine = StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher()
    {
        SetMaterialColour();

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedTime / flashTime);
            material.SetFloat("_flashAmount", currentFlashAmount);

            yield return null;
        }
    }

    private void SetMaterialColour()
    {
        material.SetColor("_flashColor", flashColor);
    }
}
