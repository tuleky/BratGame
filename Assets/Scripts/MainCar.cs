using System;
using UnityEngine;

public class MainCar : MonoBehaviour, IDamageable
{
	static Action playerTakeDamage;

	public Renderer visual;
	
	public void Init(Action callback)
	{
		playerTakeDamage = callback;
	}

	public void TakeDamage()
	{
		playerTakeDamage.Invoke();
	}
}