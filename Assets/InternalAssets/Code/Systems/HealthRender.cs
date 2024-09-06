using UnityEngine;

public class HealthRender : MonoBehaviour
{
    [SerializeField] private HealthBehaviour healthBehaviour;
    [SerializeField] private AnimatedImage[] _heartsArray;
    [Space(10f)]
    [SerializeField] private Sprite heartSprite;
    [SerializeField] private Sprite damagedSprite;

    private void OnValidate()
    {
        healthBehaviour ??= FindObjectOfType<HealthBehaviour>();
    }

    private void OnEnable()
    {
        healthBehaviour.OnHealthChange += UpdateView;
    }

    private void OnDisable()
    {
        healthBehaviour.OnHealthChange -= UpdateView;
    }

    private void UpdateView(int currentHealth)
    {
        foreach (var heart in _heartsArray)
        {
            heart.sprite = damagedSprite;
        }

        for (int i = 0; i < currentHealth; i++)
        {
            if (i >= _heartsArray.Length) break;
            _heartsArray[i].sprite = heartSprite;
        }
    }
}
