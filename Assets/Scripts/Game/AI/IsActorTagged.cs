﻿using UnityEngine;
using AI;

public class IsActorTagged : SelectWithOption
{
    GameController gamecontroller;

    // Start is called before the first frame update
    private void Start()
    {
        gamecontroller = GameObject.Find("Plane").GetComponent<GameController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Execute();
        }
    }
    public override void Execute()
    {
        base.Execute();
        gamecontroller.UpdateTaggedScore(gameObject.name);
        Check();
    }

    protected override bool Check()
    {
        return true;
    }
}