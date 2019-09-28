using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour {

	public static int puntos = 0;
	public Text textoPuntos;
	// creamos referencias a los objetos que contienen los mensajes que necesitamos mostrar
	public GameObject nivelCompletado;
	public GameObject juegoCompletado;
	public SiguienteNivel siguienteNivel;
	// referencia los objetos barra y pelota que necesitamos para desactivarla
	public Pelota pelota;
	public Barra barra;

	public SonidosFinPartida sonidosFinPartida;

	public Transform contenedorBloques; // usamos transform y no Bloques, a que este se encarga de las relaciones padre-hijo y nos permitira acceder mejor a saber cuantos hijos tiene, etc

	// Use this for initialization
	void Start () {
		ActualizarMarcadorPuntos ();
	}

	void ActualizarMarcadorPuntos(){
		textoPuntos.text = "Puntos: " + Puntos.puntos;
	}

	public void GanarPuntos(){ // cada vez que se llame a este metodo se ejecuta todo 
		Puntos.puntos++;
		ActualizarMarcadorPuntos ();

		if (contenedorBloques.childCount <= 0) {// comprobamos si nos quedamos sin bloques(sin hijos).
			pelota.DetenerMovimiento();
			barra.enabled = false;

			if (siguienteNivel.EsUltimoNivel ()) {
				juegoCompletado.SetActive (true);
			} else {
				nivelCompletado.SetActive (true);
			}
			sonidosFinPartida.NivelComletado (); // Metodo para asignar el sonido de nivel completo.

			siguienteNivel.ActivarCarga();
		}
	}

}


///// *** NOTAS *** /////
/// 
/*

childCount nos da el numero de hijos que tiene el transform.

Hay un problema en el script de Bloque, cuando un objeto colisiona con el bloque este se destruye a si mismo,
el problema al ejecutar Destroy es que no va a ejecutarce hasta que no se halla procesado todo lo que se deba 
procesar para tener listo el fotograma que se va a ejecutar, por lo cual cuando se llama seguido de este destroy
a GanarPuntos(), no va a estar realmente el valor real de la cantidad de hijos, es decir de bloques. Va a existir 
un retraso de valor respecto de lo que realmente deberia ser, una forma de solucionarlo medianamente es que en
if (contenedorBloques.childCount <= 0) cambiar el cero por el 1.
Lo que se debe hacer es ademas de destruir los bloques es que dejen de ser hijos, con lo cual el childCount tendra 
la cantidad real de blñoques hijos.


*/