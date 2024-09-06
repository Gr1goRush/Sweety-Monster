using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public bool managerEnabled { get; private set; } = false;

    [SerializeField] private Obstacle[] obstaclePool;
    [SerializeField] private Sprite[] obstacleSpriteVariants;
    [SerializeField] private Transform obstacleSpawnPosition;
    [SerializeField] private Transform bonusSpawnPosition;

    [SerializeField] private Sprite _bonusSprite;

    private Coroutine _spawnCoroutine;

    public void StartSpawn()
    {
        StopSpawn();

        managerEnabled = true;
        _spawnCoroutine = StartCoroutine(obstaclePoolEnumerator());
    }

    public void StopSpawn()
    {
        managerEnabled = false;

        if (_spawnCoroutine != null) StopCoroutine(_spawnCoroutine);
        foreach (var obstacle in obstaclePool)
        {
            obstacle.DeactivateSelf();
        }
    }

    private IEnumerator obstaclePoolEnumerator()
    {
        yield return new WaitForSeconds(1);

        while (true)
        {
            if (!Settings.GameIsPaused)
            {
                foreach (var obstacle in obstaclePool)
                {
                    if (!Settings.GameIsPaused)
                    {
                        if (!obstacle.gameObject.activeInHierarchy)
                        {
                            //obstacle.gameObject.SetActive(true);

                            if (obstacle.gameObject.tag == "Obstacle")
                            {
                                obstacle.Activate(obstacleSpawnPosition.position, 10, 5, GetRandomObstacleSprite());
                                yield return new WaitForSeconds(Random.Range(1, 3));
                            }

                            else if (obstacle.gameObject.tag == "Bonus" && Random.Range(0, 3) == 1)
                            {
                                obstacle.Activate(bonusSpawnPosition.position, 10, 5, _bonusSprite);
                                yield return new WaitForSeconds(Random.Range(1, 2));
                            }
                        }
                    }
                    else
                    {
                        yield return null;
                    }
                }
                yield return new WaitForSeconds(Random.Range(1, 2));
            }
            else
            {
                yield return null;
            }
        }
    }

    public Sprite GetRandomObstacleSprite()
    {
        return obstacleSpriteVariants[Random.Range(0, obstacleSpriteVariants.Length)];
    }

    public int RelevantObstaclesCount()
    {
        int relevant = 0;
        foreach (var obstacle in obstaclePool)
        {
            if (!obstacle.gameObject.activeInHierarchy)
            {
                relevant++;
            }
        }
        return relevant;
    }
}
