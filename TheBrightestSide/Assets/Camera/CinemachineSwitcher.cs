using Cinemachine;
using UnityEngine;



public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _mainFollowVCam, _topDownCam;

    private Animator animator;

    private bool ssCamera;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            animator.Play("TopDownCamera");
            
        }
        Debug.Log("Switching");
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            animator.Play("SideScrollerCamera");

        }
        Debug.Log("Switching");
    }
    private void ChangePriorityToFollow()
    {
        animator.Play("SideScrollerCamera");
    }
    

    void Start()
    {
      
    }

    /*private void SwitchPriority()
    {
        if(ssCamera)
        {
            _topDownCam.Priority = _mainFollowVCam.Priority + 1;
        }
        else
        {
            _topDownCam.Priority = _mainFollowVCam.Priority - 1;
        }
        ssCamera = !ssCamera;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
