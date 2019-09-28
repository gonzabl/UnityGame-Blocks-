using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		// queremos comprobar si en cada fotograma se ha pulsado la tecla...
		if(Input.GetButtonDown("Fire1")){
			// no usamos el Aplication.LoadLevel("Nivel01") porque esta obsoleto

			//Reiniciamos las variables cuando cargamos el nivel.
			Puntos.puntos = 0;
			Vidas.vidas = 3;
			SceneManager.LoadScene("Nivel01");
		}
	}
}

///// *** NOTAS *** /////
/// 
/*
	Para solucionar el problema de luces al cargar de la portada al nivel, estando cargada la escena portada, 
ir a window->lighting->settings y abajo de todo desactivar el auto y darle a build, esto generara una carpeta
que guardara al configuracion de las luces en la escena.Estio solo para propositos del editor. si se cambia 
algun objeto de sitio lo ideal es volver a pulsar build en lighting

*/
