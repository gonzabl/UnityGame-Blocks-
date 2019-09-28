using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // libreria para usar SceneManager.LoadScene

public class Salir : MonoBehaviour {

	public bool salir; // si salir esta activado indicara que queremos salir del juego, sino es que qeremos cargar la escena de portada.
	
	// Update is called once per frame
	void Update () {
		// necesitamos saber si en cada fotograma se ha pulsado una tecla.

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (salir) {
				Debug.Log ("Salimos del juego"); // Escribimos esta linea para probar que se ejecuta el metodo ya que en unity no se va  a cerrar tal cual, solo en el ejecutable del juego.
				Application.Quit (); // Metodo para salir del juego
			}else{
				
			//	Application.LoadLevel("Portada"); // para cuando estemos en el juego y pulsemos Esc no salga totalmente sino que cargue la portada.
				SceneManager.LoadScene("Portada");
			}
		}
		
	}
}



///////////  ***NOTAS*** ////////////
/// 
/*
Input.GetButtonDown(KeyCode.Escape) es otra forma de detectar una tecla en concreto sin tener
 que usar los Axis del input. Las teclas que usemos con este metodo no seran configurables.
KeyCode."aqui sale una lista de teclas "


Application.LoadLevel("Portada") aparece obsolote, unity recomienda usar SceneManager.LoadScene....
*/