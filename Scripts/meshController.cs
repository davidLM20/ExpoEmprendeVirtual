using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;


public class meshController : MonoBehaviour
{

    public NavMeshAgent  myAgent;
    public Transform     target;
    public Transform[]   Nodos;
    public float         offSet = 1;
    private int          positionTarget = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (myAgent == null)
        {
            myAgent = this.gameObject.GetComponent<NavMeshAgent>();
        }
        target = Nodos[0];
    }

    // Update is called once per frame
    void Update()
    {
        myAgent.SetDestination (target.position);
        Vector3 distancia;

        distancia = target.position - transform.position;
        if (distancia.magnitude <= offSet)
        {
            positionTarget++;
            if (positionTarget >= Nodos.Length)
            {
                positionTarget = 0;
            }
            target = Nodos[positionTarget];
        }
    }
}
