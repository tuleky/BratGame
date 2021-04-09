using System;
using UnityEngine;

public class ControllableCar : MonoBehaviour, IDamageable
{
	static Action controllableCarTakeDamage;
	
	public void Init(Action callback)
	{
		controllableCarTakeDamage = callback;
	}
	
	public void TakeDamage()
	{
		controllableCarTakeDamage.Invoke();
		Destroy(gameObject);
	}
}