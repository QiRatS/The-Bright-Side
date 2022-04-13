using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	Player playerScript;
	Rigidbody rb;

	GroundCheck gCheck;
	public CharacterInfo character1;

	[SerializeField] bool verbose;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		if(!(gCheck = GetComponentInChildren<GroundCheck>()))
		{
			if (verbose)
				Debug.Log("You forgot to put on a GroundCheck component idiot");
		}
	}

	// Update is called once per frame
	void Update()
	{
		// Player shooting mechanic should be in seperate script
		// and recieve mouse input in here
		float hValue = Input.GetAxis("Horizontal");
		if (hValue != 0)
		{
			//detects if player is pushing in same direction of current velocity
			if ((rb.velocity.x) * hValue >= 0.0f)
			{
				if (Mathf.Abs(rb.velocity.x) < character1.maxSpeed)
					rb.AddForce(Vector3.right * hValue * (character1.acell));
			}
			else
			{
				rb.AddForce(Vector3.right * hValue * (character1.acell));
			}
		   // Debug.Log("moving");
		}
		if (Input.GetButtonDown("Jump") && gCheck.IsGrounded == true)
		{
			rb.AddForce(Vector3.up * character1.jumpForce);
			StartCoroutine(Jumping());
		}
	}

	IEnumerator Jumping()
	{
		//adds force while player is holding jump.
		float timer = 0;
		while (timer < character1.floatTime)
		{
			if (Input.GetButton("Jump") && gCheck.IsGrounded == false)
			{
				rb.AddForce(Vector3.up * character1.floatForce * Time.deltaTime);
			}
			timer += Time.deltaTime;
			yield return null;
		}
		StopAllCoroutines();
		//this means we cannot put more coroutines on the playermovement script, but coroutines on other components should be fine
	}
}
