using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPowerUp : Pickup
{
    public override void OnPickup(Collider other)
    {
        Debug.Log("Do Whatever you want");
        Destroy(gameObject);
    }
}
