using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;

     protected NavMeshAgent agent { get; set; }

    public int taggedscore;
    [SerializeField] public bool IsTagged; 

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public  IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        taggedscore++;

        yield return new WaitForSeconds(stopTime);
        gameObject.GetComponent<NavMeshAgent>().speed =3.5f;
        
        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SwitchRoles();

            if (IsTagged)
            {
                StartCoroutine("StopLogic");
            }
        }
    }
}