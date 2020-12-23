using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirLonk : MonoBehaviour
{
    public string link;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Abrir(string link)
    {
        Application.OpenURL(link);
    }
}
