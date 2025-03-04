using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.SceneManagement;


public class playermovement : MonoBehaviour
{
   
    public float drag;
    public float groundSpeed;
    public float jumpSpeed;
    public int Respawn;
    public Rigidbody2D body;

public bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        float xInput=Input.GetAxis("Horizontal");
        float yInput=Input.GetAxis("Vertical");
        
        if(Mathf.Abs(xInput)>0){
        body.linearVelocity= new Vector2(xInput*groundSpeed,body.linearVelocity.y);
        }
        if(Mathf.Abs(yInput)>0){
        body.linearVelocity= new Vector2(body.linearVelocity.x,yInput*jumpSpeed);
        }
    }
    void FixedUpdate()
    {
        //CheckGround();
        if(grounded){

        
      body.linearVelocity*= 0.9f;

    }
    
    

    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("obstacle"))
        {
            Die();
            SceneManager.LoadScene(Respawn);
        }
       
    }
    void Die(){
        Debug.Log("YOU ARE DEAD!!!");
        Destroy(gameObject);
        
    }
}