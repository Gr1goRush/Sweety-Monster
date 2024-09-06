#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CharacterStatsGizmo : MonoBehaviour
{
    [SerializeField] private MovementBehaviour _characterMovementBehavior;
    [SerializeField] private HealthBehaviour _healthBehaviour;

    private void OnDrawGizmos()
    {
        if (!AllComponentsExist())
        {
            Handles.Label(transform.position, "The script did not receive links to all components");
        }
        else
        {
            Handles.Label(transform.position + Vector3.up, $"CHAR_GIZMO_DEBUG" +
                $"\n CanJump = {_characterMovementBehavior.canJump} " +
                $"\n RemainPower = {_characterMovementBehavior.remainPower}" +
                $"\n IsFlying = {_characterMovementBehavior.isFlying}" +
                $"\n Health = {_healthBehaviour.health}");
        }
    }




    private bool AllComponentsExist()
    {
        if (_characterMovementBehavior == null) return false;
        if (_healthBehaviour == null) return false;
        return true;
    }
}
#endif
