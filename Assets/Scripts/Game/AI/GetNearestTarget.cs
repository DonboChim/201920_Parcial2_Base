using AI;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GetNearestTarget : Node
{
    [SerializeField]GameObject[] enemies;
   public GameObject enemigoMasCercano;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player");
        GameObject gameobToRemove = this.gameObject;
        enemies =enemies.Where(val => val !=gameobToRemove).ToArray();
                     
        
    }
    public override void Execute()
    {

        float distanciaMinima = Mathf.Infinity;
        enemigoMasCercano= null;
        

        foreach (GameObject objeto in enemies)
        {
            float distancia = (objeto.transform.position - gameObject.transform.position).sqrMagnitude;
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                enemigoMasCercano = objeto;
            }
        }

        

    }
}