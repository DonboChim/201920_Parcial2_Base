using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastEffect : MonoBehaviour
{
    float timer;
    float duracion = 5;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < duracion)
        {
            go.GetComponent<NavMeshAgent>().speed = 6;
            go.GetComponent<MeshRenderer>().material.SetColor(name: "_Color", new Color(1,0,0));
        }
        if(timer>= duracion)
        {
            go.GetComponent<MeshRenderer>().material.SetColor(name: "_Color", new Color(1, 1, 1));
            go.GetComponent<NavMeshAgent>().speed = 3.5f;
            Destroy(this);
        }
       
    }
}
