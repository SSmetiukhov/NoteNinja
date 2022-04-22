using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class LifesScript : MonoBehaviour
{

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public static int Lifes = 3;
    private int currentLifes = 3;

    void Start()
    {
        ResetLifes();
    }

    public void ResetLifes()
    {
        Lifes = 3;
        currentLifes = 3;
    }

    public static void RemoveLife()
    {
        Lifes--;
        Debug.Log("Remove life static called");
    }

    private void SetLifes()
    {
        switch(currentLifes--)
        {
            case 3: 
                Destroy(life3);
                break;
            case 2:
                Destroy(life2);
                break;
            case 1:
                Destroy(life1);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLifes > Lifes)
        {
            SetLifes();
        }
    }
}
