using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour
{
    
    [SerializeField] InputField nombre;
    [SerializeField] InputField correo;
    [SerializeField] Dropdown ocupacion;
    [SerializeField] Toggle utpl;

    [SerializeField] GameObject error;
    [SerializeField] GameObject pantallaCarga;

    public void IngresarUsuario()
    {
        if (!nombre.text.Equals("") && !correo.text.Equals(""))
        {
            var user2 = new Usuario(nombre.text, correo.text, ocupacion.options[ocupacion.value].text, utpl.isOn);
            DatabaseHandler.PostUser(user2, nombre.text, () =>
            {
                DatabaseHandler.GetUser("1", usuario =>
                {
                    Debug.Log($"{usuario.nombre} {usuario.correo} {usuario.ocupacion}");
                });
            });
            pantallaCarga.SetActive(true);
        }
        else
        {
            Debug.Log("No hay datos");
            error.SetActive(true);
        }
    }
    public void DesactivarError()
    {
        error.SetActive(false);
    }
}
