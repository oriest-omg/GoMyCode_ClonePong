using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Balle : MonoBehaviour
{
    public float speed;
    public Text scorerightText;
	public Text scoreleftText;
	public Text Winner;
    public GameObject panel;
	int scoreRight;
	int scoreLeft;
    private bool InGame = false;
    private bool finish = false;

    void Start()
    {
        // Initial Velocity
        if(InGame == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        if(InGame == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
        transform.position = new Vector3(0.004f,-0.004f,2);
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight) {
    // ascii art:
    // ||  1 <- at the top of the racket
    // ||
    // ||  0 <- at the middle of the racket
    // ||
    // || -1 <- at the bottom of the racket
    Debug.Log( "ballPs.y :"+ballPos.y);
    Debug.Log("racketPos.y :"+racketPos.y);
    Debug.Log("ballPos.y - racketPos.y :"+(ballPos.y - racketPos.y));
    Debug.Log("racketHeight :"+racketHeight);

    Debug.Log((ballPos.y - racketPos.y) / racketHeight);
    return (ballPos.y - racketPos.y) / racketHeight;
}

void OnCollisionEnter2D(Collision2D col) {
  
  
    // Note: 'col' holds the collision information. If the
    // Ball collided with a racket, then:
    //   col.gameObject is the racket
    //   col.transform.position is the racket's position
    //   col.collider is the racket's collider

    // Hit the left Racket?
    if (col.gameObject.name == "RacketLeft") 
		{
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    // Hit the right Racket?
    if (col.gameObject.name == "RacketRight") {
        // Calculate hit Factor
        float y = hitFactor(transform.position,
                            col.transform.position,
                            col.collider.bounds.size.y);

        // Calculate direction, make length=1 via .normalized
        Vector2 dir = new Vector2(-1, y).normalized;

        // Set Velocity with dir * speed
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
    
if (col.gameObject.name == "Wallright") {
			//this line will just add 1 point to the score
			scoreLeft ++;
			//this line will convert the int score variable to a string variable
			scoreleftText.text = scoreLeft.ToString ();
            InGame = false;
            Start();

		}
		if (col.gameObject.name == "Wallleft") {
			scoreRight ++;
			scorerightText.text = scoreRight.ToString ();
            InGame = true;
            Start();
		}
}
private void Update() {
    if(finish == false)
    {
        if(scoreLeft == 5 ){
        panel.SetActive(true);
        finish = true;
        Winner.text = " Victoire joueur gauche";
            StartCoroutine(ReStart());

        }
        if(scoreRight == 5 ){
        panel.SetActive(true);
        finish = true;
        Winner.text = " Victoire joueur droite";
            StartCoroutine(ReStart());
            
        }
    }

    }
        
    IEnumerator ReStart()
    {
        //Print the time of when the function is first called.
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        finish = false;
        SceneManager.LoadScene("Pong");

        //After we have waited 5 seconds print the time again.
        // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }    
}