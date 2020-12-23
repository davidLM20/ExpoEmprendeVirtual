using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{

    /* Solución por GameDevTraum
     * 
     * Página: https://gamedevtraum.com/es/
     * Canal: https://youtube.com/c/GameDevTraum
     * 
     * Visita la página para encontrar más soluciones, Assets y artículos
    */

    /*
     * Los Scripts que se hagan para resolver acciones y que serán activados por los interruptores
     * deben implementar esta interfaz, de esa forma deberán tener definido un método Activate que
     * se ejecutará cuando activemos el interruptor.
     * Dentro de Activate se resuelve el comportamiento de la acción.
     * 
    */

    void Activate();

    
}
