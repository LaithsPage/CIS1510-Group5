using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    public Camera cam;
    private NavMeshAgent player;
    //public Animator playerAnimator;
    //public GameObject targetDest;
    private void Awake()
    {
        player = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitpoint;

            if(Physics.Raycast(ray, out hitpoint))
            {
                //targetDest.transform.position = hitpoint.point;
                player.SetDestination(hitpoint.point);
            }
        }

        /*if (player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isWalking", false);
        }*/
    }
}
