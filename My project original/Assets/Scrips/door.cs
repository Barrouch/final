using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class door : MonoBehaviour
{
	public static door instance;

	private Animator anim;

	void Awake()
	{
		
		anim = GetComponent<Animator>();
		
	}
	public void OpenDoor()
    {
		gameObject.SetActive(true);
		anim.Play("MoCua");
	}

}














