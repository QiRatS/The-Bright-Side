using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform locationTransform;
    [SerializeField] KeyCode activationKey; // Should be removed after player input has an "Interact Key"
    // Start is called before the first frame update
    void Start()
    {
        if (!locationTransform) locationTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TeleportToLocation(GameObject thingTeleported_)
    {
        thingTeleported_.transform.position = locationTransform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(activationKey))
            {
                TeleportToLocation(other.gameObject);
            }
        }
    }
}
