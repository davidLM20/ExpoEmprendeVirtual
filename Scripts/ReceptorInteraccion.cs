using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorInteraccion : MonoBehaviour
{
    /* Solución por GameDevTraum
     * 
     * Página: https://gamedevtraum.com/es/
     * Canal: https://youtube.com/c/GameDevTraum
     * 
     * Visita la página para encontrar más soluciones, Assets y artículos
    */

    [SerializeField]
    private string interactMessage;

    [SerializeField]
    private GameObject[] objectsWithActions;


    public void Activate()
    {
        
        foreach (GameObject o in objectsWithActions) {
            o.GetComponent<IAction>().Activate();
        }

    }
    public string GetInteractionMessage()
    {
        return interactMessage;
    }
}
