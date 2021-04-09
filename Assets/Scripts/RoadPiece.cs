using System;
using UnityEngine;

public class RoadPiece : MonoBehaviour
{
	public static Action OnRoadPassed;

	public RoadExitPoint _exitPoint;

	void Awake()
	{
		_exitPoint.Init(() => OnRoadPassed.Invoke());
	}
}