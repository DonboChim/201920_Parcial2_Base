using AI;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : Node
{   [SerializeField]GetNearestTarget getNearestTarget;
    [SerializeField]NavMeshAgent agent;
    [SerializeField] GameObject objeto;
    [SerializeField] AIController isTagged;
    
    public override void Execute()
    {
        if (isTagged.IsTagged==true)
        {
            agent.isStopped = false;
            
            agent.SetDestination(getNearestTarget.enemigoMasCercano.transform.position);
        }
        if(isTagged.IsTagged == false)
        {
            agent.isStopped = true;
        }
    }
    
}