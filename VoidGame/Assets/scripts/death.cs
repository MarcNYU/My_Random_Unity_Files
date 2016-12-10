using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

	public int hp = 1;

	public bool isEnemy = true;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		shot s = otherCollider.gameObject.GetComponent<shot>();
		if (s != null)
		{
			// Avoid friendly fire
			if (s.isEnemyShot != isEnemy)
			{
				Damage(s.damage);
				
				// Destroy the shot
				Destroy(s.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}