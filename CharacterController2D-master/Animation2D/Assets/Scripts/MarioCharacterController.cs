using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarioCharacterController : MonoBehaviour {

    public float motionSpeed;
    public float jumpForce;

    bool isMoving;

    int coin = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        isMoving = false;

        // Horizontal Motion
        if(Input.GetKey(KeyCode.RightArrow)) {
            isMoving = true;
            this.transform.Translate(Vector3.right * motionSpeed);
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey(KeyCode.LeftArrow)) {
            isMoving = true;
            this.transform.Translate(Vector3.left * motionSpeed);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        this.GetComponent<Animator>().SetBool("MarioIsMoving", isMoving);

        // Jump
        if(Input.GetKeyDown(KeyCode.Space)) {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.GetComponent<Animator>().SetBool("MarioIsOnFloor", false);
        }
    }

    //Esta funcion es activada cuando Mario toca otro Collider
    void OnCollisionEnter2D(Collision2D col) {

        if(col.gameObject.tag == "Floor"){
            
            //Le avisa al amimator controller que active la aomacion de Idle
            this.GetComponent<Animator>().SetBool("MarioIsOnFloor", true);

        }

        //Si Mario yoca un coco
        if(col.gameObject.tag == "Coin"){

            //Destruimos la cocos
            GameObject.Destroy(col.gameObject);

            //Aumentamos el contador de cocos
            coin += 1;

            //Le oedimos al componente Text que actualice la cantidad de cocos mostradas
            GameObject.Find("Canvas/PanelCoco/Text").GetComponent<Text>().text = coin.ToString();
        }


    }

    public void HacerSalto(){

        //Hace que Mario salte
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        this.GetComponent<Animator>().SetBool("MarioIsOnFloor", false);
  
    }
}
