using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawner", menuName = "Enemy Spawner", order = 0)]
public class EnemySpawnerSO : ScriptableObject
{
	public float _enemySpawnRatio;
	[SerializeField] EnemyCar _enemyCar;

	public EnemyCar SpawnEnemy(Vector3 position, Quaternion rotation)
	{
		return Instantiate(_enemyCar, position, rotation);
	}
}