using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour {

    public PlayerScript playerScript;
    public Text onPar;
    //public int par = playerScript.par;

    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (playerScript.skotFjoldi == 1)
        {
            onPar.text = "Hole in one, good job";
        }
        else if (playerScript.skotFjoldi == (playerScript.par - 1))
        {
            onPar.text = "Birdie";
        }
        else if (playerScript.skotFjoldi == (playerScript.par - 2))
        {
            onPar.text = "Eagle";
        }
        else if (playerScript.skotFjoldi == (playerScript.par - 3))
        {
            onPar.text = "Albatross";
        }
        else if (playerScript.skotFjoldi == (playerScript.par + 1))
        {
            onPar.text = "Bogey";
        }
        else if (playerScript.skotFjoldi == (playerScript.par + 2))
        {
            onPar.text = "Double bogey";
        }
        else if (playerScript.skotFjoldi == playerScript.par)
        {
            onPar.text = "On par";
        }
        if (playerScript.finished)
        {
            StartCoroutine(Wait());
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("level01");
            }
        }
    }

    IEnumerator Wait()
    {
        anim.SetTrigger("BallInHole");
        yield return new WaitForSeconds(3.0f);
    }
}
