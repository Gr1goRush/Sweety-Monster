#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ObstacleGizmo : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;

    private void OnDrawGizmos()
    {
        if (obstacle == null) return;

        Handles.Label(transform.position, $"{obstacle.name}" +
            $"\n lifetime = {obstacle.lifeTime}" +
            $"\n speed = {obstacle.speed}");
    }
}
#endif