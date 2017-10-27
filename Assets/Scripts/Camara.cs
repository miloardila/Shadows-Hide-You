using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour {

    public Transform heroe;
    public Vector3 desplazamiento;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(heroe.position.x + desplazamiento.x, heroe.position.y + desplazamiento.y, desplazamiento.z);
		
	}
}
