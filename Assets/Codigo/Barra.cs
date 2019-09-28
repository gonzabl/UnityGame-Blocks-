using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour {

	// variable que contenga el numero para incrementar la posicion.
	// si pon emos public aparecera la variable en el inspector de unity
	public float velocidad = 0.0f;

	Vector3 posicionInicial;

	// Use this for initialization
	void Start () {
		posicionInicial = transform.position; // le pasamos el valor actual.
	}

	public void Reset(){
		// metodo para reiniciar la posicion en base a la posicion inicial que ya guardamos en Start() y que sera llamado en otros Scripts al ser public.
		transform.position = posicionInicial;
	}
	
	// Update es llamado una vez por cada frame(fotograma).(entre 30 o 60 frames por segundo dependiendo)
	void Update () {
		// el metodo GetAxisRaw toma un string con los nombres que ya estan definidos en axis(ejes).
		// este metodo toma valores negativo -1, positivo +1 o 0 cuando no pulsamos nada.
		// Si buscamos Horizontal en Input se puede ver que el valor negativo y positivo esta asignado a right y left respectivamente, que son las flechas del teclado.
		// se los puede ver desde la pestaña edit-> Proyect Settings -> Input.
		// Administrador de entrada(Input) es donde define todos los diferentes ejes de entrada y acciones de juego para su proyecto.

		float teclaHorizontal = Input.GetAxisRaw ("Horizontal");
		// para cambiar la posicion debemos acceder a la variable de la posicion del eje x, sumarle el movimiento que hagamos con la tecla y a este multiplicarle la velocidad con la cual se va 
		// a mover la barra. Ademas de multiplicarlo por el tiempo que ha durado el ultimo fotograma, asi la velocidad se calcula en base al ultimo fotograma y no a un segundo.
		// es decir, cuanto tenemos que desplazarnos para un fotograma y no para un segundo.
		//(los fotogramas se ejecutan 30 veces por segundo o 60 en otros casos.)

		float posicionX = transform.position.x + (teclaHorizontal * velocidad * Time.deltaTime);


		// aqui necesito actualizar la posicion del objeto barra con lo cual le paso los valores del eje x que estoy
		// modificando y en los otros ejes simplemente le indico la posicion que tiene actualmente en el inspector.

		// agrego un metodo Clamp de la clase Mathf, para que la posicion se mantenga dentro de un rango de valores y no pueda moverse mas alla de ellos

		transform.position = new Vector3 (Mathf.Clamp( posicionX,-8,8),transform.position.y,transform.position.z);
	}



	/****** Notas*******/

	/* No es bueno mover un objeto que tenga un Box Collider, porque perdemos rendimiento. Unity tiene una cache donde se guardan todos
	los objetos que se cosideran estaticos. Por lo tanto cuando movemos un objeto estatico, unity debe recontruir esa cache por cada cambio del objeto.
	por lo tanto cambiamos el objeto estatico por uno dinamico para no tener perdida dde rendimiento. para ellos le ponemos un RigitBody, que es un componente que podemos añadir.
	Una vez añadido le desmarcamos la opcion Use Gravity para que la, en el caso de la barra, no caiga al vacio y activamos la opcion Is Kinematic para que no se vea afectado por ninguna fuerza.
	Es decir que nos vamos a encargar por codigo de moverlo nosotros mismos.

	Constrains sirve para indicar restricciones, es decir no queremos que se mueva o rote en ciertos ejes, si tenemos activado Is kinematic no tiene sentido marcar estas restricciones, pero por las dudas siempre sirve.

	Usamos emparentamiento (herencia?) para hacer un objeto hijo de otro, el padre controla la posicion, rotacion y escala, con lo cual la posicion del hijo va a ser siempre 
	relativa a la del padre.Esto lo usamos para cuando movemos la barra al inicio del juego y la pelota la siga.Simplemente arrastramos el objeto que va a ser hijo hacia el objeto padre, en este caso arrastramos la 
	pelota hacia la barra.

	*/
}
