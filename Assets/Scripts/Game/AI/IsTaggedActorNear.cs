using AI;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class IsTaggedActorNear : SelectWithOption
{
    [SerializeField]bool isTaggedNear;
    [SerializeField] GameObject[] enemies;

    public GameObject enemigoMasCercano;
    protected override bool Check()
    {
        return isTaggedNear;
    }
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
        GameObject gameobToRemove = this.gameObject;
        enemies = enemies.Where(val => val != gameobToRemove).ToArray();


    }

    public override void Execute()
    {
        
        
        
        float distanciaMinima = 80;
        enemigoMasCercano = null;
      
        foreach (GameObject objeto in enemies)
        {
            
            if (objeto.GetComponent<AIController>().IsTagged == true || objeto.GetComponent<HumanController>().IsTagged == true)
            {
                enemigoMasCercano = objeto;
                float distancia = (objeto.transform.position - gameObject.transform.position).sqrMagnitude;
                if (distancia < distanciaMinima)
                {
                    isTaggedNear = true;
                    base.completed = isTaggedNear;
                    base.Execute();
                }
                if (distancia > distanciaMinima)
                {
                    isTaggedNear = false;
                    base.completed = isTaggedNear;
                    base.Execute();
                }
            }
        }
    }
}