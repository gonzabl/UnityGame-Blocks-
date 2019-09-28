using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPelota : MonoBehaviour {

	// necesitamos las referencias a los audioSources
	public AudioSource rebote;
	public AudioSource punto;

	void OnCollisionEnter(Collision otro){ // Cuando la pelota colisione con cualquier otro objeto se llamara a este metodo.

		if (otro.gameObject.CompareTag ("Bloque")) {
			punto.Play ();
		} else {
			rebote.Play ();
		}
	}
}

/// *** Notas*** ////
/// 
/*
Play on Awake hace que los sonidos se ejecuten siempre. Para los sonidos de rebote
y punto deben estar desactivadas. Solo si ponemos musica para el nivel.


Vamos a configurar los sonidos de la pelota dependiendo de con que objeto colisione.
como el is Trigger esta desactivado el metodo que debemos usar es OnCollisionEnter

En el tipo OnTriggerEnter(Collider: este es el tipo del parametro que se usaria)

para poder distinguier que sonido se va a ejecutar cuando la pelota colisione con otro
es a travez del parametro definido aqui como "otro", con este llamamos al metodo gameObject
y en el caso de los bloques que son varios dentro de una jerarquia, podemos añadirles un tipo
de etiqueta (Tag) personalizada desde el inspector para diferenciarlos y asi usar el metodo CompareTag().

*/