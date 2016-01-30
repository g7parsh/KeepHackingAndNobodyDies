using UnityEngine;
using System.Collections;

public class HealthNode : MonoBehaviour {

	public int Health = 2;

	public bool IsDead { get { return Health <= 0; } }

	public void Damage()
	{
		if (Health > 0)
			Health--;
	}
}
