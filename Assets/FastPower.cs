using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastPower : MonoBehaviour
{
    bool counttime;
    float timer;
    int duracion=5;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor(name: "_Color", new Color(1, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (counttime == true)
        {
            timer += Time.deltaTime;
            if (timer > duracion)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                this.gameObject.GetComponent<SphereCollider>().enabled = true;
                timer = 0;
                counttime = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && (other.GetComponent<AIController>().IsTagged == true && other.GetComponent<AIController>().IsTagged == true))
        {
            other.gameObject.AddComponent<FastEffect>();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            counttime = true;
        }
    }
}
