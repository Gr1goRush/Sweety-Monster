using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ModelAnimator : MonoBehaviour
{
    [SerializeField] private Animator _charAnimator;
    private MovementBehaviour _charMovementBehaviour;

    private void OnValidate()
    {
        _charAnimator = GetComponent<Animator>();
        _charMovementBehaviour = FindObjectOfType<MovementBehaviour>();
    }

    private void Update()
    {
        _charAnimator.enabled = !Settings.GameIsPaused;
        _charAnimator.SetBool("IsFly", _charMovementBehaviour.isFlying);
    }

}
