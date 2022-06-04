using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{
    public GameObject diamond;
    public int MaxDiamond = 10;
    public int CountDiamond = 0;
    public GameObject PanelQuestion;
    public GameObject Grid;

    public Vector2 speed = new Vector2(1, 1);
    public Animator animateur;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        animateur.SetFloat("speed", inputY);
        animateur.SetFloat("Speed", inputX);

        Vector3 movement = new Vector3(speed.x * (inputX/6), speed.y * (inputY/6), 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Diamond")
        {

            PanelQuestion.SetActive(true);
            Grid.SetActive(false);
            diamond.SetActive(false);

            CountDiamond++;

            Destroy(target.gameObject);

        }
    }
}
