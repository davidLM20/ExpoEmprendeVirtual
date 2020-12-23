using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaTeletrasportacion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    PiUIManager piUi;
    [SerializeField]
    Transform[] teleportPoint;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject mapaTeleport;
    [SerializeField]
    Menu menu;
    CursorController cursorController;
     
    
    void Start()
    {
        cursorController = FindObjectOfType<CursorController>();
        mapaTeleport.SetActive(false);             
    }

    // Update is called once per frame

    public void Activar()
    {

        menu.MostarOcultarMenu("Menu Player");
        cursorController.ShowCursor();
        mapaTeleport.SetActive(true);      
    }
    public void Salir()
    {
        mapaTeleport.SetActive(false);
        cursorController.HideCursor();     
    }
    public void Teleport(int nStand)
    {
        player.transform.position = new Vector3(teleportPoint[nStand].position.x, player.transform.position.y, teleportPoint[nStand].position.z);
        player.transform.rotation = teleportPoint[nStand].rotation;
        Salir();
    }  
}
