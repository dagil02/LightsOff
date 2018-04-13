using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb;
	RaycastHit2D activa;
	public float playerSpeed;
	public float playerJump;
	bool enTierra;
	public bool miraDerecha;
	public Transform posJugador, posSuelo;
	Quaternion pepe;
    Animator playerAnim;
	Transform tamaño;
	// Use this for initialization
	void Awake () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		pepe = gameObject.transform.rotation;
		enTierra = true;
		miraDerecha = true;
		tamaño = gameObject.transform;
	}
    void Start()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate () {
		Girar (miraDerecha);
		if (pepe != gameObject.transform.rotation)
			gameObject.transform.rotation = pepe;
		DetectaSuelo ();
		if (Input.GetKey(KeyCode.D)){
			miraDerecha = true;
            if (Input.GetKey(KeyCode.W) && enTierra)
            {
                playerAnim.SetBool("walkJump", true);
            }
            else
            {
                playerAnim.SetBool("walkJump", false);
            }
            rb.velocity = new Vector2 (playerSpeed, rb.velocity.y);
            playerAnim.SetBool("walk", true);
        }
        if (Input.GetKey(KeyCode.A)) {
			miraDerecha = false;
            if (Input.GetKey(KeyCode.W) && enTierra)
            {
                playerAnim.SetBool("walkJump", true);
            }
            else
            {
                playerAnim.SetBool("walkJump", false);
            }
            rb.velocity = new Vector2 (-playerSpeed, rb.velocity.y);
            playerAnim.SetBool("walk", true);

        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            playerAnim.SetBool("walk", false);
        }
        if (Input.GetKeyDown (KeyCode.W) && enTierra) {
			enTierra = false;
			rb.AddForce (new Vector2 (0, playerJump), ForceMode2D.Impulse);
            playerAnim.SetBool("jump", true);
            playerAnim.SetBool("walkJump", true);
        }
        else
        {
            playerAnim.SetBool("jump", false);
            playerAnim.SetBool("walkJump", false);
        }
        

    }
	void DetectaSuelo (){
		Debug.DrawLine (posJugador.position, posSuelo.position, Color.yellow);
		enTierra = Physics2D.Linecast(posJugador.position, posSuelo.position, 1 << LayerMask.NameToLayer("Plataformas"));
	}
	void Girar (bool miraDerecha){
		if (miraDerecha) {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		} else {
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
			gameObject.transform.localScale = tamaño.localScale;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "MovingPlatform")
			transform.parent = null;
	}
	public bool Activador (){
		if (Input.GetKey (KeyCode.B)) {
			activa = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, 2f);
			if (activa.collider != null && activa.collider.tag == "Palanca") {
				return true;
			} else
				return false;
		} else
			return false;
	}
	void DibujaActivador()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position,transform.position+Vector3.right*transform.localScale.x*2f);
	}
}
