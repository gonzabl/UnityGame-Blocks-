using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

	public Rigidbody rig; // si lo dejamos asi, sinplemente en el inpector arrastramos la referencia Rigitbody a la variable del componente.
	public float velocidadInicial = 600f;// variable que indica la fuerza con la que vamos a lanzar la pelota.
	bool enJuego = false;
	Vector3 posicionInicial;
	public Transform barra; // usamos para poder referenciar al objeto barra que esta como padre de pelota


	/* // Forma en codigo para pasar la referencia del objeto barra.
	   // La que queda es la forma public y simplemente en el inspector arrastramos el objeto barra a la variable.
	 * // Transform barra; 
	void Awake(){
		// De esta forma obtenemos la referencia al objeto barra que esta como padre y debe buscarlo en la clase padre y no en la clase pelota 
		barra = GetComponentsInParent<Transform>();
	}*/

	/* // forma de asignar un componente mediante el metodo awake. 
	void Awake(){
		//teniendo la variable RigidBody sin public
		// metodo que se ejecuta antes del metodo Start() y sera donde tengamos referencias a otros componentes

		rig = GetComponent<Rigidbody>; // esto busca al componente de tipo RigidBody dentro del mismo objeto en el que este colocado este Script. 
										// por lo tanto guarda la referencia del RigidBody y podemos acceder a ella.
	}*/

	// Use this for initialization
	void Start () {
		posicionInicial = transform.position; // guardamos la posicion inicial de la pelota que esta respecto a la barra.
		
	}

	public void Reset(){
		transform.position = posicionInicial; // cada vez que reinicie, la posicion de la pelota sera asignada por el valor inicial guardado previamente.
		transform.SetParent(barra); // le indicamos al padre y que guarde su transform inicial.
		enJuego = false; // Aqui tambien ponemos por defecto el estado del juego al resetear.
		DetenerMovimiento();
	}

	public void DetenerMovimiento(){
		rig.isKinematic = true; // Aqui aplicamos el efecto para que la pelota siga a la barra, es decir se mueva en relacion al padre.
		rig.velocity = Vector3.zero;// similar a  new Vector3(), seteamos la variable velocity a cero, pero como espera un vector3 esto debe ser asignado.
	}

	
	// Update is called once per frame
	void Update () {
		if (!enJuego && Input.GetButtonDown ("Fire1")) { // esto dice: si no empezo el juego y pulsamo la tecla "tal" entonces...
			enJuego = true;

			// Luego indicamos que la pelota deje de ser hija de la barra para que se mueva independientemente de la barra.
			transform.SetParent(null); // con este metodo seteamos el padre del objeto, como no queremos que tenga le ponemos null.

			rig.isKinematic = false; // de esta forma accedemos a la variable y la activamos o desactivamos.

			// aplicamos fuerza a la pelota
			rig.AddForce(new Vector3(velocidadInicial,velocidadInicial,0)); // queremos que la pelota valla hacia arriba y hacia los lados, eje Y y el eje X respectivamente.
																			// el eje Z es para que se mueva hacia adentro y haci afuera.
		}
	}


	///////// *****NOTAS**** //////////
	/* 
	Usamos un rigitBody para que la pelota sea dinamica, le desactivamos la gravedad y no activamos
	Is Kinematic porque queremos que la pelota sea afectada por la fisica. Pero inicialmente esta acticada para que solo
	sea afectada por la barra, cuando lanzamos la pelota esta debera desactivarse por medio de metodos.

	En Input es donde tenemos la entrada de teclados, Joystick, raton.Aqui de entre todos los metodos tenemos
	GetButtonDown: es duando se pulsa o se empieza a pulsar. Aqui hay que indicarle el nombre del eje de ese boton.
	GetButtonUp: es cuando se suelta o se deja de pulsar.
	GetButton: es para saber si sigue pulsada esa tecla en ese fotograma.
	Recordar que en input estan los nombres asignados para cada entrada. Fire1 tiene asignado solo el boton positivo: left ctrl y mouse 0.
	Para efectos de adaptar a un juego tactil, se debera quitar para evitar problemas con la pantalla tactil.

	Para que la pelota pueda rebotar debemos agragarle un material de tipo elastico, para ellos creamos un Physic Material
	y para que no pierda velocidad por friccion le ponemos en cero las variables Dynamic y Static friction.
	En Bounciness el valor para que rebote.

	En el inspector los coliders de los objetos tienen una opcion de marcado Is Trigger, el cual si esta activado cualquier objeto que 
	colisiona con este lo atraviesa, si esta desactivado se vuelve "solido" y ya no puede atravesarlo

	*/
}
