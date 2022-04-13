using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPipe : MonoBehaviour
{
    public enum PipeOrientation
    {
        CLOCKWISE_0,
        CLOCKWISE_90,
        CLOCKWISE_180,
        CLOCKWISE_270,
    }

    [Tooltip("Snapping increment for rotation")]
    [SerializeField] float rotationStep;
    [SerializeField] PipeOrientation correctOrientation;
    PipeOrientation currentOrientation;

    [Header("Other Object Components")]
    [SerializeField] PipeConnectionChecker pipeEnd2;
    [SerializeField] PipeConnectionChecker pipeEnd1;
    [SerializeField] MeshRenderer pipeModel;

    bool isOreinted;
    bool isConnected;

    [Tooltip("The material used when the pipe is connected to a flowing pipe")]
    public Material waterFlowMat;
    public Material emptyMat;

    public bool OrientationIsCorrect { get => isOreinted; }

    // Start is called before the first frame update
    void Start()
    {
        if (rotationStep == 0f) rotationStep = 90f;
        SnapRotation();       
    }

    private void Update()
    {
        UpdateConnections();
    }

    void RotateY(float angle)
    {
        currentOrientation++;

        // Rotate pipe to correct position
        switch (currentOrientation)
        {
            case PipeOrientation.CLOCKWISE_0:
                SetAngleOfY(0f);
                break;
            case PipeOrientation.CLOCKWISE_90:
                SetAngleOfY(90f);
                break;
            case PipeOrientation.CLOCKWISE_180:
                SetAngleOfY(180f);
                break;
            case PipeOrientation.CLOCKWISE_270:
                SetAngleOfY(270f);
                break;
            default:
                currentOrientation = PipeOrientation.CLOCKWISE_0;
                SetAngleOfY(0f);
                break;
        }

        // Remove later and only check when puzzle is activated
        UpdateConnections();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PlayerProjectile"))
        {
            RotateY(rotationStep);
        }
    }

    // Updates orientation and pipe connections
    void UpdateConnections()
    {
        if (currentOrientation == correctOrientation)
            isOreinted = true;
        else
            isOreinted = false;

        if (pipeEnd1.IsConnected && pipeEnd2.IsConnected)
        {
            isConnected = true;
            //pipeModel.material = waterFlowMat;
        }
        else
        {
            isConnected = false;
            //pipeModel.material = emptyMat;
        }
    }

    // Will change mesh/material if pipe is connected
    // Also returns true if pipe orientation is correct
    public bool CheckPipe()
    {
        if (isConnected)
            pipeModel.material = waterFlowMat;
        else
            pipeModel.material = emptyMat;

        return isOreinted;
    }

    public void ResetSelf()
    {
        UpdateConnections();
        SnapRotation();
        pipeModel.material = emptyMat;
    }

    // Snaps rotation to nearest right angle and sets current orientation to match
    void SnapRotation()
    {
        #region Initial Angle Correction For Pipe Editor Rotation
        float angleToCheck = transform.rotation.eulerAngles.y;

        if (angleToCheck > 315.0f || angleToCheck <= 45.0f || (angleToCheck < -315.0f && angleToCheck >= -45.0f))
        {
            SetAngleOfY(0f);
            currentOrientation = PipeOrientation.CLOCKWISE_0;
        }
        else if ((angleToCheck > 45.0f && angleToCheck <= 135.0f) || (angleToCheck < -45.0f && angleToCheck >= -135.0f))
        {
            SetAngleOfY(90f);
            currentOrientation = PipeOrientation.CLOCKWISE_90;
        }
        else if ((angleToCheck > 135.0f && angleToCheck <= 225.0f) || (angleToCheck < -135.0f && angleToCheck >= -225.0f))
        {
            SetAngleOfY(180f);
            currentOrientation = PipeOrientation.CLOCKWISE_180;
        }
        else if ((angleToCheck > 225.0f && angleToCheck <= 315.0f) || (angleToCheck < -225.0f & angleToCheck >= -315.0f))
        {
            SetAngleOfY(270f);
            currentOrientation = PipeOrientation.CLOCKWISE_270;
        }
        #endregion
    }

    void SetAngleOfY(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(
                transform.rotation.eulerAngles.x,
                angle,
                transform.rotation.eulerAngles.z));
    }

}
