using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] RoadSpawnerSO _roadSpawnerSO;
	[SerializeField] EnemySpawnerSO _enemySpawnerSO;

	void Awake()
	{
		RoadPiece.OnRoadPassed = SpawnRandomRoad;
		
		RoadInit();
		
		InvokeRepeating(nameof(SpawnEnemy), _enemySpawnerSO._enemySpawnRatio, _enemySpawnerSO._enemySpawnRatio);
	}

	void SpawnRandomRoad()
	{
		_roadSpawnerSO.SpawnRandomRoad();
	}

	void RoadInit()
	{
		_roadSpawnerSO.Initialization();
	}

	void SpawnEnemy()
	{
		var position = PlayerController.Instance.transform.position;
		float randX = Random.Range(-2f, 2f);
		Vector3 enemyPosition = position + Vector3.forward * 40f + Vector3.right * randX;
		
		Vector3 lookDirection = position - enemyPosition;
		EnemyCar enemyCar = _enemySpawnerSO.SpawnEnemy(enemyPosition, Quaternion.LookRotation(lookDirection.normalized, Vector3.up));
		AttackEnemy(enemyCar);
	}

	void AttackEnemy(EnemyCar enemyCar)
	{
		enemyCar.Attack(PlayerController.Instance.transform);
	}
}