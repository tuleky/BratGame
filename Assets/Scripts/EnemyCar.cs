using UnityEngine;
using DG.Tweening;

public class EnemyCar : MonoBehaviour
{
	public void Attack(Transform target)
	{
		transform.DOMove(target.position, 2f);
	}

	void OnTriggerEnter(Collider coll)
	{
		IDamageable damageable = coll.GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage();
			DOTween.KillAll();
			Destroy(gameObject);
		}
	}
}