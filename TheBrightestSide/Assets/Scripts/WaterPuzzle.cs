using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPuzzle : PuzzleBase
{
    public struct ResetValues
    {
        public Vector3 position;
        public Quaternion rotation;
        public ResetValues(Vector3 v, Quaternion q)
        {
            position = v;
            rotation = q;
        }
    }

    [SerializeField] WaterPipe[] pipePieces;
    ResetValues[] originalValues;

    bool isComplete;

    public bool IsComplete { get => isComplete; }

    public override void Completed()
    {
        foreach(WaterPipe wp in pipePieces)
        {
            if(!wp.CheckPipe())
            {
                isComplete = false;
                return;
            }
        }
        isComplete = true;
    }

    // Reset pipe rotation and position to original values for each pipe piece
    public override void ResetSelf()
    {
        for (int i = 0; i < pipePieces.Length; i++)
        {
            pipePieces[i].transform.position = originalValues[i].position;
            pipePieces[i].transform.rotation = originalValues[i].rotation;
            pipePieces[i].ResetSelf();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(pipePieces.Length > 0)
        {
            originalValues = new ResetValues[pipePieces.Length];
            for (int i = 0; i < pipePieces.Length; i++)
            {
                originalValues[i] = new ResetValues(
                    new Vector3(pipePieces[i].transform.position.x, pipePieces[i].transform.position.y, pipePieces[i].transform.position.z),
                    Quaternion.Euler(pipePieces[i].transform.rotation.eulerAngles.x, pipePieces[i].transform.rotation.eulerAngles.y, pipePieces[i].transform.rotation.eulerAngles.z)
                    );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
            ResetSelf();
    }
}
