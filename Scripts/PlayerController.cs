using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Camera cam;

    [SerializeField] AparecerTexto mapaEmp;

    private Vector3 camPos;

    private float alturaBaja;
    private float alturaNormal;

    


    float walkSpeed = 2f;
    float runSpeed = 5f;
    float gravity = 20;

    //Movimiento del mouse Vetical o Horizontal
    float mouseMovH;
    float mouseMovV;

    //Velocidad del mouse
    float mouseVelH = 2f;
    float mouseVelV = 1.8f ;

    Vector3 move = Vector3.zero;

    
    void Start()
    {

        ///camParent.SetActive(photonView.IsMine);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;

        alturaNormal = characterController.height;
        alturaBaja = alturaNormal / 2.5f;

        


    }

    void Update()
    {
        //if (!photonView.IsMine) return;
        PlayerMovement();
        if (Input.GetKey(KeyCode.C))
        {
            Crouching();
        }
        else if(Input.GetKeyUp(KeyCode.C))
        {

            GetUp();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mapaEmp.Activate();
        }

    }


    public void PlayerMovement()
    {
        //Se producira movimiento de acuerdo a la velocida si el mouse se mueve en X y/o Y
        mouseMovH = mouseVelH * Input.GetAxis("Mouse X");
        mouseMovV += -mouseVelV * Input.GetAxis("Mouse Y");

        //En el eje Y se movera con restricciones para evitar que de la vuelta completa
        mouseMovV = Mathf.Clamp(mouseMovV, -20f, 65f);

        //Se rotara segun el eje Y del jugador la cantidad de movimiento Horizontal 
        transform.Rotate(0, mouseMovH, 0);

        //Se rotara segun el eje X de la camara la cantidad de movimiento Vertical
        cam.transform.localEulerAngles = new Vector3(mouseMovV, 0, 0);

        // Si el personaje esta en el suelo si se produce una entrada de movimiento el personaje se movera en esa direccion
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
                move = transform.TransformDirection(move) * runSpeed * Time.deltaTime;
            else
                move = transform.TransformDirection(move) * walkSpeed * Time.deltaTime;


            
        }

        move.y -= gravity * Time.deltaTime;
        characterController.Move(move);

    }

    void Crouching()
    {
        if (characterController.isGrounded)
        {
            characterController.height = alturaBaja;
            characterController.center = new Vector3(0f, -0.5f, 0f);
            cam.transform.localPosition = camPos;
        }
    }

    void GetUp()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        characterController.center = new Vector3(0f, 0f, 0f);
        characterController.height = alturaNormal;
        cam.transform.localPosition =  new Vector3(0f, 0.7f, 0f); ;
    }
}
