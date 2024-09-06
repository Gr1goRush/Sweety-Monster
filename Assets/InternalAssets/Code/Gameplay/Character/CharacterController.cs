using UnityEngine;

[RequireComponent(typeof(MovementBehaviour), typeof(HealthBehaviour))]
public class CharacterController : MonoBehaviour
{
    //[SerializeField] private MovementBehaviour movementBehaviour;
    //[SerializeField] private HealthBehaviour healthBehaviour;

    //private void OnValidate()
    //{
    //    movementBehaviour ??= GetComponent<MovementBehaviour>();
    //    healthBehaviour ??= GetComponent<HealthBehaviour>();
    //}

    //private void OnEnable()
    //{
    //    healthBehaviour.OnDead += movementBehaviour.DisableMovement;
    //}

    //private void OnDisable()
    //{
    //    healthBehaviour.OnDead -= movementBehaviour.DisableMovement;
    //}


}
