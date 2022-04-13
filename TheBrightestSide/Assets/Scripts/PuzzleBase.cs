using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleBase : MonoBehaviour
{
    // Resets the puzzle to its original state
    public abstract void ResetSelf();
    // Does things when the puzzle is completed
    public abstract void Completed();
}
