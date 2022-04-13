using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    Player playerScript;
    Rigidbody rb;

    [HideInInspector]
    public Vector3 mousePos;

    [HideInInspector]
    public float hValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        hValue = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            //rb.AddForce(-playerScript.shootScript.dirToFire * 4, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Jump") && playerScript.IsGrounded == true)
        {
            rb.AddForce(Vector3.up * playerScript.playerInfo.jumpForce);
        }
    }
}
