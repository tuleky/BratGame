using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Create LevelGenerator", fileName = "LevelGenerator", order = 0)]
public class RoadSpawnerSO : ScriptableObject
{
	[SerializeField] RoadPiece[] _roadPieces;
	Queue<RoadPiece> _buffer = new Queue<RoadPiece>(); // one for entering, one for exiting node
	RoadPiece _lastInstantiatedRoadPiece;
	
	public void Initialization()
	{
		RoadPiece firstRoad = Instantiate(_roadPieces[0], Vector3.zero, quaternion.identity);
		_buffer.Enqueue(firstRoad);

		_lastInstantiatedRoadPiece = Instantiate(_roadPieces[0], firstRoad._exitPoint.transform.position, quaternion.identity);
		_buffer.Enqueue(_lastInstantiatedRoadPiece);
	}
	
	public RoadPiece SpawnRandomRoad()
	{
		int randomIndex = Random.Range(0, _roadPieces.Length);
		RoadPiece spawningRoad = _roadPieces[randomIndex];

		// add new one
		_lastInstantiatedRoadPiece = Instantiate(spawningRoad, _lastInstantiatedRoadPiece._exitPoint.transform.position, Quaternion.identity);
		
		RoadPiece firstRoadPieceinQueue = _buffer.Dequeue();
		Destroy(firstRoadPieceinQueue.gameObject);
		
		_buffer.Enqueue(_lastInstantiatedRoadPiece);
		Debug.Log("Spawning New Road");
		return _lastInstantiatedRoadPiece;
	}
}
