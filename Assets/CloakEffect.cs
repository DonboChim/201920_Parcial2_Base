using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakEffect : MonoBehaviour
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
        if (timer < duracion)
        {
            
            go.GetComponent<MeshRenderer>().material.SetColor(name: "_Color", new Color(1, 1, 1, 0.5f));
            go.tag = "ghost";
        }
        if (timer >= duracion)
        {
            go.GetComponent<MeshRenderer>().material.SetColor(name: "_Color", new Color(1, 1, 1));
            go.tag = "Player";
            Destroy(this);
        }
    }
}
