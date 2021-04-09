using System;
using UnityEngine;

public class RoadExitPoint : MonoBehaviour
{
	static Action exitPointPass;

	public void Init(Action callback)
	{
		exitPointPass = callback;
	}
	
	void OnTriggerExit(Collider other)
	{
		exitPointPass.Invoke();	
	}
}