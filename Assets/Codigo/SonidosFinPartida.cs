using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosFinPartida : MonoBehaviour {

	public AudioSource audioSource; // Aqui en vez de usar asignar un nuevoa audio Souerce usamos el que ya esta asignado como componente
									// y simplemente lo intercambiamos por codigo cuando sea relevante.
									

	public AudioClip completado; // referencio a los sonidos
	public AudioClip gameOver; // referencia a los sonidos

	// Definimos metodos publicos para que sean llamados desde otros scrips y ejecuten el sonido pretendido

	public void GameOver(){
		ReproduceSonido (gameOver);
	}


	public void NivelComletado(){
		ReproduceSonido (completado);
	}

	void ReproduceSonido(AudioClip sonido){
		audioSource.clip = sonido; // con esta variable clip, le asigno el sonido que quiero que se reprodusca. 
		audioSource.loop = false; // variable para activar o desactivar el loop
		audioSource.Play(); // metodo para que se reprodusca el sonido
	}

}

// FALTARIA EL SONIDO DE ERROR CUANDO LA PELOTA TOCA EL SUELO.


/// *** NOTAS *** ////

/* AudioSource solo puede reproducir un archivo a la vez

Ahora establecemos en donde se maneje el fin de partida o el nivel completado por medio de una variable referenciando
a la clase de este scrip, como esos metodos estan en los scripts Vidas y Puntos, le asignaremos la referencia de este script a la variable de tipo SonidoFinPartida en 
ellos.




*/


