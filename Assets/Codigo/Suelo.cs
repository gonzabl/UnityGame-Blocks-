using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour {

	public Vidas vidas; // creamos una referencia a la clase vidas para poder llamar desde este scrip al metodo de la clase Vidas en gestor de juego.

	void OnTriggerEnter(){
		vidas.PerderVidas ();// Cuando la pelota toque el suelo se ejecutara este metodo
	}
}
