using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterFace : MonoBehaviour
{
    [SerializeField] private Sprite GoodFaceSprite;
    [SerializeField] private Sprite BadFaceSprite;

    [SerializeField] private HealthBehaviour characterHealthBehaviour;
    [SerializeField, HideInInspector] private SpriteRenderer spriteRenderer;

    private WaitForSeconds await = new WaitForSeconds(1);
    private void OnValidate()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        characterHealthBehaviour ??= FindAnyObjectByType<HealthBehaviour>();
    }

    private void Start()
    {
        characterHealthBehaviour.OnTakeDamage.AddListener(FaceEffect);
    }

    public void FaceEffect()
    {
        if (isActiveAndEnabled)
        StartCoroutine(FaceEffectRoutine());
    }

    private IEnumerator FaceEffectRoutine()
    {
        spriteRenderer.sprite = BadFaceSprite;
        yield return await;
        spriteRenderer.sprite = GoodFaceSprite;
    }

    
}
