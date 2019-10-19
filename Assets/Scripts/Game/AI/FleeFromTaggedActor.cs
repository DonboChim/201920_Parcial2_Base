using AI;
using UnityEngine;
using UnityEngine.AI;


public class FleeFromTaggedActor : Node
{
    [SerializeField]
    private GameObject[] navPoints;
    [SerializeField] IsTaggedActorNear isTaggedNear;
    [SerializeField] NavMeshAgent agent;
    
    [SerializeField]
    private void Start()
    {
        
        navPoints = GameObject.FindGameObjectsWithTag("PuntoT");
    }
    public override void Execute()
    {
        float furthestDistanceSoFar = 0;
        Vector3 runPosition = Vector3.zero;

        //Check each point
        foreach (GameObject point in navPoints)
        {
           
            float currentCheckDistance = Vector3.Distance(isTaggedNear.enemigoMasCercano.transform.position, point.transform.position);
            if (currentCheckDistance > furthestDistanceSoFar)
            {
                furthestDistanceSoFar = currentCheckDistance;
                runPosition = point.transform.position;
            }
        }
        agent.SetDestination(runPosition);
    }
}