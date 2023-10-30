using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class ControlBot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float FindTargetRate;
    [SerializeField] private float initialDelay;

    private int HP;
    public int Velocidad;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("FindTarget", initialDelay, FindTargetRate);
        HP = 100;
    }

    private void Update()
    {
        agent.destination = target.position;
    }

    public void RecibirDaño() 
    {
        HP = HP - 25;

        if (HP <= 0) 
        {
            this.Desaparecer();
        }  
    }
    private void Desaparecer()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala")) 
        {
            RecibirDaño();
        }
    }
    private void FindTarget()
    {
        
    }
}
