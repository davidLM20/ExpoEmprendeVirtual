using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICargarINfo : MonoBehaviour
{
    [SerializeField] GameObject IUCargarInfo;
    [SerializeField] int totalInfos;
    public int infosCargadas;
    [SerializeField] CursorController cc;
    [SerializeField] GameObject boton;
    [SerializeField] Text cargadas;
    [SerializeField] Text totales;
    // Start is called before the first frame update


    void Start()
    {
        totales.text = totalInfos.ToString();
        cc.ShowCursor();
    }
    void FixedUpdate()
    {
        cargadas.text =  infosCargadas.ToString();
        if (infosCargadas>=totalInfos)
        {
            
            boton.SetActive(true);

        }


    }

    public void Salir()
    {
        cc.HideCursor();
        IUCargarInfo.SetActive(false);  

    }
}
