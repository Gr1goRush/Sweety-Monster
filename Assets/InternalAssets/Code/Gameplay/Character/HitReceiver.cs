using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBehaviour))]
public class HitReceiver : MonoBehaviour
{
    [SerializeField] private HealthBehaviour healthBehaviour;
    public UnityEvent OnBonusCollected;

    private void OnValidate()
    {
        healthBehaviour ??= GetComponent<HealthBehaviour>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            healthBehaviour.TakeDamage();
            VibroPlayer.PlayVibro();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            OnBonusCollected?.Invoke();
            if (healthBehaviour.health < 3)
            {
                healthBehaviour.Heal();
                collision.gameObject.SetActive(false);
            }
            else
            {

                PlayerBalance.AddMoney(1);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
