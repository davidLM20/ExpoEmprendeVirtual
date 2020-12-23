using System;

/// <summary>
/// The user class, which gets uploaded to the Firebase Database
/// </summary>

[Serializable] // This makes the class able to be serialized stringo a JSON
public class Usuario
{
    public string nombre;
    public string correo;
    public string ocupacion;
    public bool utpl;
 
    public Usuario(string nombre, string correo, string ocupacion, bool utpl)
    {
        this.nombre = nombre;
        this.correo = correo;
        this.ocupacion = ocupacion;
        this.utpl = utpl;
    }
}