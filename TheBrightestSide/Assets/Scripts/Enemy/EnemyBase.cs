using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Animator), typeof(Collider), typeof(HealthHandler))]
public class Enemy : MonoBehaviour
{
	public bool verbose = false;

	[SerializeField] GameObject viewCone;

	[SerializeField] protected int maxHealth;
	protected int _health;

	protected Animator anim;
	protected HealthHandler healthHandler;

	bool seesPlayerCollider = false;
	bool seesPlayerRaycast = false;
	bool active;
	float rayCastFloat;

	protected void DestroyObj(float deathDelay)
	{
		Destroy(gameObject, deathDelay);
	}

	public virtual void Start()
	{
		anim = GetComponent<Animator>();

		if (verbose)
		{
			if (!viewCone)
			{
				Debug.Log("No view cone on " + this.name);
			}
		}
	}

	public virtual void Death()
	{
		// Die animation should be handled on the enemy anim controller
		anim.SetBool("Dead", true);
		Destroy(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			seesPlayerCollider = true;
		}
	}

	private void Update()
	{
		if (seesPlayerCollider == true)
		{
			//this should limit the number of raycasts each enemy does
			//idk if this is too many or too little im untalented at optimizing
			if (Physics.Raycast(this.transform.position, transform.forward, rayCastFloat))
			{                                       //change this ^^ to playerpos - this.pos when game manager is in
				seesPlayerRaycast = true;
				anim.SetBool("SeesPlayer", true);
			}
			else
			{
				seesPlayerRaycast = false;
				anim.SetBool("SeesPlayer", false);
			}
		}
	}
}
