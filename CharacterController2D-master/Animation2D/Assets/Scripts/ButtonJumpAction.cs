using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJumpAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EjecutarSaltoDeMario(){
        Debug.Log("Boton de salto presionado");

        GameObject.Find("Mario").GetComponent<MarioCharacterController>().HacerSalto();

    }
}
