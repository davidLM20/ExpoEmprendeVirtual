using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
     
    [SerializeField]
    PiUIManager piUi;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject blur;
    [SerializeField]
    GameObject texto;
    CursorController cursorController;
    
    bool menuActive;
    
    void Start()
    {
        cursorController = FindObjectOfType<CursorController>();
        menuActive = false ;           
        blur.SetActive(false);
        texto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        if (Input.GetKeyDown(KeyCode.Q))
        {          
            MostarOcultarMenu("Pi Menu");           
        }
        

    }
    public void MostarOcultarMenu(string nombreMenu)
    {  
        menuActive = !menuActive;
        piUi.ChangeMenuState(nombreMenu, new Vector2(Screen.width / 2f, Screen.height / 2f));
        if (!menuActive)
        {
            cursorController.HideCursor();
            blur.SetActive(false);
            texto.SetActive(false);
        }
        else if (menuActive)
        {
            cursorController.ShowCursor();
            blur.SetActive(true);
            texto.SetActive(true);
        }                
    }
}
