using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAsensor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]GameObject[] mapasPisos;
    

    public void mostrarMapa(int piso)
    {
        int aux=0;     
        foreach (var item in mapasPisos)
        {
            mapasPisos[aux].SetActive(false);
            aux++;
        }       
        mapasPisos[piso].SetActive(true);
    }    
}
