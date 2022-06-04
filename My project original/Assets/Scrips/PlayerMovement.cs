using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f;
    public Rigidbody2D rb;
    Vector3 movement;
    public Animator animator;
    public int MaxDiamond = 10;
    public int CountDiamond = 0;
    public GameObject Door_level_1;
    public GameObject PanelQuestion;
    public GameObject diamond;
    public GameObject door;
    public GameObject Grid;
    
    void Start()
    { 
    
    }

    void Update() 
    {
        ProcessInputs();
        Move();
    }

    private void Move() 
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        animator.SetBool("isWalking", x != 0 || y != 0);
        
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } 
        else if (x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.velocity = new Vector2(movement.x, movement.y);
    }

    private void ProcessInputs()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "diamond")
        {
            PanelQuestion.SetActive(true);
            Grid.SetActive(false);
            diamond.SetActive(false);
            door.SetActive(false); 
            
            CountDiamond++;
            
            Destroy(target.gameObject);
       
        }

        if (CountDiamond >= MaxDiamond)
        {
            Door_level_1.GetComponent<Collider2D>().isTrigger = true;
            Door_level_1.GetComponent<door>().OpenDoor();
            //mocu2a;
            if (target.tag == "door")
            {
                ManagerScene.Instance.CurrentScence = ManagerScene.Instance.CurrentScence + 1;
                SceneManager.LoadScene(ManagerScene.Instance.CurrentScence);
            }

        }
    }
}
