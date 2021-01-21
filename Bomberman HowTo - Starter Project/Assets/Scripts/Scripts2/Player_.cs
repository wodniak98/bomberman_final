using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ : MonoBehaviour
{
    public GlobalStateManage globalManager;
    [Range(1, 2)]
    public int PlayerNumber = 1;
    public float moveSpeed = 5f;
    public bool canDropBombs = true;
    public bool canMove = true;
    public bool dead = false;
    

    public GameObject bombPrefab;

    private Rigidbody rigidBody;
    private Transform myTransform;
   
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        myTransform = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        

        if (!canMove)
        {
            return;
        }

        if (PlayerNumber == 1)
        {
            UpdatePlayer1Movement();
        }
        else
        {
            UpdatePlayer2Movement();
        }
    }
    private void UpdatePlayer1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        if (Input.GetKey(KeyCode.A))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            
        }
        if (Input.GetKey(KeyCode.S))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            
        }

        if (Input.GetKey(KeyCode.D))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            
        }
        if (canDropBombs && (Input.GetKeyDown(KeyCode.Space) ))
        { //Drop Bomb. gracz z wsadem używa spacji,bo blisko i pod ręką
            DropBomb();
        }
    }
    private void UpdatePlayer2Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        { //Up movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        { //Left movement
            rigidBody.velocity = new Vector3(-moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 270, 0);
            
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { //Down movement
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -moveSpeed);
            myTransform.rotation = Quaternion.Euler(0, 180, 0);
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        { //Right movement
            rigidBody.velocity = new Vector3(moveSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
            myTransform.rotation = Quaternion.Euler(0, 90, 0);
            
        }

        if (canDropBombs && (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)))
        { //Drop Bomb.grzacz używający strzałek używa entera
            DropBomb();
        }
    }
    private void DropBomb()
    {
        if (bombPrefab)
        {
            Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTransform.position.x),
  bombPrefab.transform.position.y, Mathf.RoundToInt(myTransform.position.z)),
  bombPrefab.transform.rotation);


        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            Debug.Log("P" + PlayerNumber + " hit by explosion!");
            dead = true; // 1
            globalManager.PlayerDied(PlayerNumber); // 2
            Destroy(gameObject); // 3  
        }
    }
}
