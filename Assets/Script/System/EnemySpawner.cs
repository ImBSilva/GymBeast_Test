using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    private void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab não atribuído!");
            return;
        }

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Nenhum ponto de spawn atribuído!");
            return;
        }

        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Não é possível spawnar inimigos. Verifique o prefab e os pontos de spawn.");
            return;
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        if (spawnPoint == null)
        {
            Debug.LogWarning("Ponto de spawn nulo encontrado!");
            return;
        }

        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Inimigo spawnado em: " + spawnPoint.position);
    }
}
