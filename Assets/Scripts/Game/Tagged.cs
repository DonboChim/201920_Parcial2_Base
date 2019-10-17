using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tagged : MonoBehaviour
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
            gamecontroller.UpdateTaggedScore(gameObject.name);
        }
    }

    // Update is called once per frame

}
