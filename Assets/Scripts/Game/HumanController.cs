using UnityEngine;
using UnityEngine.AI;

public class HumanController : PlayerController
{
     NavMeshAgent agent1;
    [SerializeField]
    private LayerMask walkable;
    private void Start()
    {
        agent1 = gameObject.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            agent1.SetDestination(GetLocation());
        }
            
    }
    protected override Vector3 GetLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit, walkable) ? hit.point : transform.position;

    }
    
}