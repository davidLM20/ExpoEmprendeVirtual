using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAsensorController : MonoBehaviour , IAction
{
    /* Solución por GameDevTraum
     * 
     * Página: https://gamedevtraum.com/es/
     * Canal: https://youtube.com/c/GameDevTraum
     * 
     * Visita la página para encontrar más soluciones, Assets y artículos
    */

    
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private float velocity;
    private bool activated;
    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = Vector3.Normalize(endPoint.position - startPoint.position);
    }

    void FixedUpdate()
    {
        if (activated)
        {
            if (Vector3.Distance(gameObject.transform.position, endPoint.position)>0.05f)
            {
                gameObject.transform.position -= moveDirection * velocity/100;

            }

        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, startPoint.position) > 0.05f)
            {
                gameObject.transform.position += moveDirection * velocity/100;

            }
        }
    }

    public void Activate()
    {
        activated = !activated;
        if (activated)
        {
            Debug.Log("Portón activado");
        }
        else
        {
            Debug.Log("Portón desactivado");

        }
    }

}
