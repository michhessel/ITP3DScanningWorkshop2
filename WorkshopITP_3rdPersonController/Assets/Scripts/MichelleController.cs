using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MichelleController : MonoBehaviour {
	//moving the character
	public float movingSpeed = 2f;
	public float rotationSpeed = 100f;
	static Animator anim;

	//Game Count:
	private int count;
	public Text countText;
	public Text endGame;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		count = 0;
		countToString ();
		endGame.text = "";

	}
	
	// Update is called once per frame
	void Update () {
		//controlling the character:
		if (Input.GetButtonDown ("Jump")) {
			Debug.Log ("pressed spacebar");
			anim.SetTrigger ("isJumping");
		}
		
		if (Input.GetKey ("up")) {
			transform.Translate(Vector3.forward *movingSpeed * Time.deltaTime);
			}
	
		if (Input.GetKey ("down")) {
				transform.Translate (Vector3.back * movingSpeed * Time.deltaTime);
			}
		if (Input.GetKey ("right")) {
				transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);
			}
		if (Input.GetKey ("left")) {
				transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime);
			}

		if ((Input.GetKey ("up")) || (Input.GetKey ("down"))) {
				anim.SetBool ("isRunning", true);
				anim.SetBool ("isIdle", false);
		
			} else {
				anim.SetBool ("isRunning", false);
				anim.SetBool ("isIdle", true);
			}
	
	}

	//colliding with things in the scene:
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			countToString ();
		}
		if (other.gameObject.CompareTag ("Poop")) {
//			other.gameObject.SetActive (false);
			Destroy(other.gameObject);
			count = count - 3;
			countToString ();
		}
	}

	//manipulating the counter and UI elements:
	void countToString (){
		countText.text = "Count: " + count.ToString ();

		if(GameObject.FindWithTag("Pick Up") == null){
			endGame.text = "Yay, you win!";
		}
		if (count <= 0) {
			endGame.text = "Boo, you ate too much poop";
		}
	}



}
