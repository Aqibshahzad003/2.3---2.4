using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float horizontalinput;
    private Gamemanager gamemanager;
    public float throwForce = 10f; 
    public float  rotateSpeed = 100f;

    private void Start()
    {
        gamemanager = FindAnyObjectByType<Gamemanager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.gameover)  //making condition so the player cant move if the game is over
        {
            horizontalinput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * horizontalinput * speed * Time.deltaTime);

        }
        //Setting boundaries according to display of the screen
        if(transform.position.x >= 7.5f)
        {
            transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -7.5f)
        {
            transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);

        }
        Debug.Log(Time.timeScale);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        { 
            //calling the function from Gamemanger script
            gamemanager.Addstar();
            Destroy(other.gameObject); //in the end destroying the gameobject i.e Star
        }
        if(other.gameObject.tag =="Bar")
        {
            Debug.Log("Bar");// debuging for testing

            other.gameObject.GetComponent<BoxCollider>().enabled = false;  //accesing the boxcollider setting it to false so it cant trigger with the player more then one time
            other.gameObject.transform.SetParent ( null); //setting the collided gameobject parent to false
            Rigidbody rb =other.gameObject.GetComponent<Rigidbody>();//accesing the rigidbody
            rb.useGravity = true;

            // Appling a force to the block's Rigidbody
            Vector3 throwDirection = new Vector3(Random.Range(-2f, 2f), Random.Range(5f, -5f),transform.position.z).normalized;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            //Appling rotation
            Vector3 randomRotation = new Vector3(transform.rotation.x,transform.rotation.y , Random.Range(-1f, 1f));
            rb.angularVelocity = randomRotation * rotateSpeed;

            gamemanager.SlowMo();//Doing the slowmo 
           
            gamemanager.Decreaselife(); //Finally decreasing the heart life by 1
        }
    }
}
