using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour {
	// en este script lo llamaremos por un metodo cuando el jugador gane o pierda el nivel.

	public string nivelACargar; // estableceremos su valor desde el inspector y le escribimos el nombre del escenario a cargar.
	public float retraso; // estableceremos el tiempo de retraso para que cargue el siguiente nivel desde el inspector.

	[ContextMenu("Activar Carga")] // Forzar llamado a un metodo para probar la funcionalidad del mismo y activarlo desde el inspector.

	public void ActivarCarga(){ // este metodo sera llamado por otros scripts una vez que el usuario gane o pierda.
		Invoke("CargarNivel",retraso); // sirve para llamar metodos con retrazo. el primer parametro contiene el nombre del metodo a llamar y el segundo el tiempo.
	}


	void CargarNivel(){
		SceneManager.LoadScene (nivelACargar);
	}

	public bool EsUltimoNivel(){
		return nivelACargar == "Portada";
	}
}

/////// ***NOTAS*** //////
/// 
/*
[ContextMenu("_nombreDelMetodo_")]:
Forzar la llamada de una metodo desde el inspector solo funcionara con metodos que no reciban parametro
En este caso una vez que ejecutemos el juego podemos darle click Der -> Activar Carga(que es el nombre que pusimos) y se ejecutara el script 
*/