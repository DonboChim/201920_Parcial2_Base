using UnityEngine;
using AI;

public class IsActorTagged : SelectWithOption
{
    GameController gamecontroller;
    [SerializeField]AIController aicontroller;
    [SerializeField]bool isTagged;

    public bool IsTagged { get => isTagged; set => isTagged = value; }

    // Start is called before the first frame update
    private void Start()
    {
        gamecontroller = GameObject.Find("Plane").GetComponent<GameController>();
    }
    private void Update()
    {
        IsTagged = aicontroller.IsTagged;
    }

    public override void Execute()
    {
        
        base.completed = aicontroller.IsTagged;
        base.Execute();
    }

    protected override bool Check()
    {
       
        return aicontroller.IsTagged;
    }
}