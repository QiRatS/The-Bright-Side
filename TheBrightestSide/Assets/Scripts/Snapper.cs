using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    [Tooltip("Snapping increment for rotation")]
    [SerializeField] float rotationSnapDistance;
    [Tooltip("Snapping increment for position")]
    [SerializeField] float positionSnapDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        if (!(positionSnapDistance == 0f) && (UnityEditor.Tools.current == UnityEditor.Tool.Move))
        {
            Vector3 correctedPosition = new Vector3(
                correctedPosition.x = Mathf.Round(transform.position.x / positionSnapDistance) * positionSnapDistance,
                correctedPosition.y = Mathf.Round(transform.position.y / positionSnapDistance) * positionSnapDistance,
                correctedPosition.z = Mathf.Round(transform.position.z / positionSnapDistance) * positionSnapDistance
                );
            transform.position = correctedPosition;
        }


        if (UnityEditor.Tools.current == UnityEditor.Tool.Rotate && isActiveAndEnabled)
        {
            Vector3 correctedRotation = new Vector3(
                correctedRotation.x = Mathf.Round(transform.rotation.eulerAngles.x / rotationSnapDistance) * rotationSnapDistance,
                correctedRotation.y = Mathf.Round(transform.rotation.eulerAngles.y / rotationSnapDistance) * rotationSnapDistance,
                correctedRotation.z = Mathf.Round(transform.rotation.eulerAngles.z / rotationSnapDistance) * rotationSnapDistance
                );

            transform.eulerAngles = correctedRotation;
        }
    }

    
}
