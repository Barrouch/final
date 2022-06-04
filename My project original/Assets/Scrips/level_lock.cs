using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level_lock : MonoBehaviour
{
    public Button[] lvlButtons;
    int k = 0;

    public void clic()
    {
        k++;
    }

    public void Start()
    {
        k = k + SceneManager.GetActiveScene().buildIndex + 1;
        int levelAt = 0;

        if (k > levelAt)
        {
            levelAt = k;
        }

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

  
}