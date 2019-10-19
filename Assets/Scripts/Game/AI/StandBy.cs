using AI;
using UnityEngine;
using UnityEngine.AI;

public class StandBy : Node
{
    
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject objeto;

    public override void Execute()
    {
        
        agent.SetDestination(agent.transform.position);
    }
}