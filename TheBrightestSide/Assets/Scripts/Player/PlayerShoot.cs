using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField] bool verbose;

	public CharacterInfo character1;
	public GameObject fireSpot;
	Rigidbody rb;
	GroundCheck gCheck;

	public GameObject projectile;
	public int maxAmmo;
	public int curAmmo;

	// Start is called before the first frame update
	void Start()
	{
		if(!(rb = GetComponent<Rigidbody>()))
		{
			if(verbose)
			Debug.Log("You forgot the rigidBody on " + gameObject.name);
		}
		if (!(gCheck = GetComponentInChildren<GroundCheck>()))
		{
			if (verbose)
				Debug.Log("You forgot to put on a GroundCheck component idiot");
		}
		if (!fireSpot)
		{
			if(verbose)
			Debug.Log("You forgot to put a firing spot idiot");
		}
		if (maxAmmo <= 0)
		{
			maxAmmo = 3;
			if (verbose)
			Debug.Log("Setting maxAmmo to 3");
		}
		if (curAmmo != maxAmmo)
		{
			curAmmo = maxAmmo;
			if (verbose)
				Debug.Log("Setting curAmmo to maxAmmo");
		}
	}

	// Update is called once per frame
	void Update()
	{
	//	if (gCheck.IsGrounded)
	//	{
	//		curAmmo = maxAmmo;
	//	}
		Vector3 mousePos = Input.mousePosition;
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Mathf.Abs(Camera.main.transform.position.z)));
		Vector3 mousePlanePos = Vector3.ProjectOnPlane(mouseWorldPos, Vector3.forward);

		Vector3 dirToFire = (mousePlanePos - transform.position).normalized;

		Quaternion fireSpotRotation = Quaternion.LookRotation(dirToFire);

		if (verbose)
			Debug.DrawLine(fireSpot.transform.position, mousePlanePos, Color.red, 0.5f);

		fireSpot.transform.rotation = fireSpotRotation;

		if (Input.GetButtonDown("Fire1"))
		{
			if (curAmmo > 0)
			{
				if (rb.velocity.y <= 0)
				{
					rb.AddForce(-dirToFire * character1.recoilForce + Vector3.up * Mathf.Abs(rb.velocity.y) * character1.recoilFixCoef, ForceMode.Impulse);
				}
				else
				{
					rb.AddForce(-dirToFire * character1.recoilForce, ForceMode.Impulse);
				}
				GameObject temp = Instantiate(projectile, fireSpot.transform.position, fireSpot.transform.rotation);
				//moves on proj script
				Destroy(temp.gameObject, character1.projTime);
				//also change this ^^ to something on the char info
				curAmmo--;
				if (verbose)
				{
					Debug.Log("we have " + curAmmo + " shots left");
				}
			}
		}
	}
}
