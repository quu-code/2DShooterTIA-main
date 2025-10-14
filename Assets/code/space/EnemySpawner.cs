using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField]
  GameObject enemyPrefab;

  [SerializeField]
  float timeBetweenEnemies = 0.5f;
  float timeSinceLastEnemy = 0;

  // Update is called once per frame
  void Update()
  {
    timeSinceLastEnemy += Time.deltaTime;
    if (timeSinceLastEnemy > timeBetweenEnemies)
    {
      Instantiate(enemyPrefab);
      timeSinceLastEnemy = 0;
    }
  }
}
