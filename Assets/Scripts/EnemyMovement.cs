using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;

    private NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // avoid MissingReferenceException when the player object has been
        // destroyed (e.g. after GameOver). Unity's overloaded == returns
        // true for destroyed objects, but the moment you access any property
        // (like position) the engine will complain if the native object is
        // gone.  We bail out early and even disable the component so that
        // the agent stops running entirely.
        if (player == null)
        {
            // no target anymore – stop chasing and disable further updates
            enabled = false;
            return;
        }

        navMeshAgent.SetDestination(player.position);
    }
}
