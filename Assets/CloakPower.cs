using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloakPower : MonoBehaviour
{
    bool counttime;
    float timer;
    int duracion=5;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer>().sharedMaterial.SetColor(name: "_Color", new Color(0, 0, 0));
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
        if (other.gameObject.tag == "Player" && (other.GetComponent<AIController>().IsTagged==false && other.GetComponent<AIController>().IsTagged == false))
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.AddComponent<CloakEffect>();
            
            counttime = true;
        }
    }
}