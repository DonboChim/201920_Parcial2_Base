using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerspawner : MonoBehaviour
{
    [SerializeField] GameObject powertoinstantiate;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        instanciar();
    }

  
    void instanciar()
    {
        GameObject instance = Instantiate(powertoinstantiate, transform.position, Quaternion.identity);
    }
}
