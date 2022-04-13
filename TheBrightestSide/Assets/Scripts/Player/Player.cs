using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    bool isGrounded;

    public bool IsGrounded { get => isGrounded; }

    [SerializeField]
    public PlayerInput inputScript;

    [SerializeField]
    public PlayerMovement moveScript;

    [SerializeField]
    public PlayerShoot shootScript;

    [SerializeField]
    public CharacterInfo playerInfo;

    internal Animator anim;
    internal Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

}
