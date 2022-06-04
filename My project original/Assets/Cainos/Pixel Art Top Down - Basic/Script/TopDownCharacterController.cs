using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        //public float speed;

        private Animator animator;
        public GameObject diamond;

        public float speed = 1f;
        Vector3 movement;
        public int MaxDiamond = 10;
        public int CountDiamond = 0;
        public GameObject PanelQuestion;
        public GameObject Grid;


        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                dir.x = -10;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                dir.x = 10;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                dir.y = 10;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                dir.y = -10;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir * 2;

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
}