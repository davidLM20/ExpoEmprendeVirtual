using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancia : MonoBehaviour
{
    public GameObject stand;
    public Transform lugar;

    GameObject standIns;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.U))
        {
            standIns= Instantiate(stand, lugar.position, lugar.rotation);
            urlManager panel = standIns.GetComponentInChildren<urlManager>();
            panel.url.Clear();
            panel.url.Add("Facebook", "https://www.facebook.com/jhandryl1");
            panel.url.Add("Youtube", "https://www.youtube.com/?hl=es-419");
            panel.url.Add("Google", "https://www.google.com/search?client=opera&q=david&sourceid=opera&ie=UTF-8&oe=UTF-8");


        }
        
    }
}
