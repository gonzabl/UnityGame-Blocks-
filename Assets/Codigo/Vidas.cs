using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // libreria para la clase Text entre otras

public class Vidas : MonoBehaviour {

	public static int vidas = 3; // variable static para que solo exista una sola para todas las intancias. Variable unica para todos los componentes o es decir variable unica compartida. 
	public Text textoVidas; // Creamos una variable para poder refernciar el texto que queremos utilizar de otro componente. Es necesario importar la libreria para la clase Text.
	public Barra barra;
	public Pelota pelota;
	public GameObject gameOver; // aqui nos referimos al objeto GameOver y no al componente texto que esta dentro de GameOver
	public SiguienteNivel siguienteNivel; //aqui referenciamos al tipo SiguienteNivel del script con el mismo nombre
	public SonidosFinPartida sonidosFinPartida;


	// Use this for initialization
	void Start () {
		ActualizarMarcadorVidas();
	}

	void ActualizarMarcadorVidas(){
		textoVidas.text = "Vidas: " + Vidas.vidas;
	}
	public void PerderVidas(){
		if (Vidas.vidas <= 0)return; // dice que si tenemos cero vidas no se ejecuta nada de lo de abajo.
									// Este tipo de anotacion es rara, cambiarlo!
		Vidas.vidas--;
		ActualizarMarcadorVidas ();

		if (Vidas.vidas <= 0){
			sonidosFinPartida.GameOver (); // Esto reproducira el audio de gameOver .
			// mostraremos gameOver
			gameOver.SetActive (true);// con este metodo activo o desactivo un objeto, en este caso activo el texto en pantalla del mismo.
			pelota.DetenerMovimiento();
			barra.enabled = false; // con este metodo activo o desactivo un componente que esta en el objeto, en este caso el script.
									// como en este scrip ya tenemos una referencia a la barra podemos acceder por medio de la variable
								   // y llamar a su metodo "enabled" para activar o desactivar el script barra, y de esa forma hacer que la barra deje de moverse.

			siguienteNivel.nivelACargar = "Portada"; // establecemos como caso especial en escenario a cargar cuando el usuario pierda, sino el metodo 
													// ActivarCarga cargaria el siguiente nivel cuando perdamos y no queremos eso.
			siguienteNivel.ActivarCarga(); // con la referencia al componente siguienteNivel llamamos a su metodo.
		} else {
			barra.Reset ();
			pelota.Reset ();
		}
	}
}
	/// ***NOTAS***////
	/*
	Al hacer la variable estatica, estamos haciendo que sea una variable de la clase. Por eso accedemos
	a ella referenciando a la clase, no con la referencia a ningun objeto/componente.
	
	llamamos Vidas.vidas para que asi se sepa que vidas es una varariable de clase y no de instancia como 
	las demas, de esta forma le da mas claridad al codigo.

	Debemos asignar este scrip en algun sitio para que tenga efecto por lo tanto, creamos en la jerarquia 
	un objeto vacio que llamaremos Gestor de juegos para poder utilizarlos. Luego arrastramos la referencia 
	del componente vidas a la variable textoVidas.

	Para resetear la barra y la pelota necesitamos crear las referencias a esos componentes, arrastrar los 
	mismos para referencialos y luego en start() llamar a sus respectivos metodos reset previamente creados 
	para que se ejecuten cada vez que la pelota toca el suelo.

	Vamos a crear referencias a los componentes de GameOver y el componente con el script siguienteNivel par 
	poder activarlos cuando la vida llegue a cero o se rompan todos los bloques.

	La diferencia por la cual usamos SetActive en uno y enabled en otro es porque en el primero hacemos referencia
	a todo el objeto GameObject, y usamos enabled para referirnos a un componente de ese objeto, en este caso el 
	que hace referencia al script barra. 

	Por ejemplo si quisiera desactivar un objeto en el que esta un componente, en este caso el objeto barra(el GameObject) del componente barra(el script):
	barra.gameObject.SetActive(true);
	Con esto hago referencia al componente: barra"(script)".gameObject"(con esto accedo al GameObject en el que esta colocado)".SetActive(true)"(ahora si uso el metodo)"

	public SiguienteNivel siguienteNivel quedo primero establecido la portada como siguiente al no tener mas niveles, si fuera el ultimo nivel si valdria, por ahora al no tenerlos
	queda por defecto en el inspector "Portada". Lo normal seria el siguiente nivel a cargar, ejemplo "Nivel2"
	*/

