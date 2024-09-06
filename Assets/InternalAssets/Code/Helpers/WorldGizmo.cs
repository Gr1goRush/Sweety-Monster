#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class WorldGizmo : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner ObstacleSpawner;
    [SerializeField] private HealthBehaviour playerHealthBehaviour;

    public void OnDrawGizmos()
    {
        if (ObstacleSpawner != null)
        {
            Handles.Label(transform.position, $"OBSTS_STATS" +
                $"\n SpawnerEnabled = {ObstacleSpawner.managerEnabled}" +
                $"\n RelevantObstacles = {ObstacleSpawner.RelevantObstaclesCount()}");
        }
        if (playerHealthBehaviour != null)
        {
            Handles.Label(transform.position + Vector3.right * 6, $"PLAYER_STATS" +
                $"\n IsAlive = {playerHealthBehaviour.health > 0}");
        }
    }


}
#endif
