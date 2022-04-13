using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeConnectionChecker : MonoBehaviour
{
    bool isConnected;

    public bool IsConnected { get => isConnected;}

    private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Pipe"))
        {
            isConnected = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Pipe"))
        {
            isConnected = false;
        }
    }
}
