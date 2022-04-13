using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float shootSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += this.transform.forward * shootSpeed * Time.deltaTime;
    }
}
