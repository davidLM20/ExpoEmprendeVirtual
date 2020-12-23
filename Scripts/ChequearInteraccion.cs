using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

public class ChequearInteraccion : MonoBehaviour
{
    /* Solución por GameDevTraum
     * 
     * Página: https://gamedevtraum.com/es/
     * Canal: https://youtube.com/c/GameDevTraum
     * 
     * Visita la página para encontrar más soluciones, Assets y artículos
    */


    [SerializeField]
    private float minInteractionDistance;
   


    [SerializeField]
    private GameObject origenRayo;


    private Ray ray;

    private bool canInteract;

    private ReceptorInteraccion receptorActual;

    private InterfazGrafica intG;

    private void Start()
    {
        intG = FindObjectOfType<InterfazGrafica>();
    }

    void Update()
    {
        //if (!photonView.IsMine) return;
        CheckRaycast();
        if (canInteract)
        {
            //En esta región el personaje está viendo un objeto con el que puede interactuar
            //En mi caso voy a hacer la lectura de la tecla E aquí mismo, pero esto se puede manejar de distintas formas
            if (Input.GetKeyDown(KeyCode.E))
            {
                receptorActual.Activate();
            }
            
        }

    }

    private void CheckRaycast()
    {
        ray = new Ray(origenRayo.transform.position, origenRayo.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           

            if (hit.distance < minInteractionDistance)
            {


                receptorActual = hit.transform.gameObject.GetComponent<ReceptorInteraccion>();

                if (receptorActual != null)
                {

                    intG.showMessage(receptorActual.GetInteractionMessage());

                    canInteract = true;
                   
                }
                else
                {
                    canInteract = false;
                }
            }
        }

      
    }

}
