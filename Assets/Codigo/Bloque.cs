using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour {

	public GameObject efectoParticulas;
	public Puntos puntos; // necesitamos referenciar al componente puntos para usar el metodo GanarPuntos

	void OnCollisionEnter(){
	
		Instantiate (efectoParticulas, transform.position, Quaternion.identity); // Instanciamos el efecto de particulas. Requiere 3 parametors, el efecto,la posicion del objeto dada por su transform
																				//y la rotacion, el cual usamos la clase Quaternion que pide y el metodo identity con el cual le pasamos el que tenga por 
																				// defecto.
		Destroy (gameObject);// gameObject hace referencia al objeto que tenga este script
		transform.SetParent(null);// este metodo hace que el bloque destruido deje de ser un bloque hijo, para que al llevar la cuenta en el metodo childCount del script Puntos, se tengan valores reales.
		puntos.GanarPuntos();
	}


}


////////////// ***Notas*** ////////////////
/*
// Vamos a usar metodos que se usan cuando un objeto colisiona con otro: 

void OnCollisionEnter(){ // llama al objeto que tiene al Is Trigger DESACTIVADO }

void OnTriggerEnter(){ // llama al objeto que tiene al Is Trigger ACTIVADO }
	
	Con respecto a los metodos por ejemplo si asignamos a dos bloques con sus respectivos Is Triggers activado y desactivado,
cuando la pelota colisione con alguno de estos se llamara a los metodos respectivos, es decir, si la pelota colisiona con un bloque 
con trigger desactivado, se ejecuta el metodo OnCollisionEnter, por el contrario, si colisiona la pelota con un bloque con el Is Trigger 
activado se ejecuta el metodo OnTriggerEnter()

*/
