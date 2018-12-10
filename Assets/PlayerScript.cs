using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    private readonly float timeBetweenShots = 1;
    public float timer;
    readonly float prevscroll;
    public float playerSpeed;
    public float minForce;
    public float maxForce;
    [Range(0f, 100000f)]
    public float force;
    public int skotFjoldi;
    public int par;
    Vector3 lastposition = new Vector3();
    public bool finished;
    //public Camera main;
    public Rigidbody playerBall;
    public AudioSource golfHitSound;
    public Slider powerSlider;
    public Text shotAmount;
    public LineRenderer line;

    private void Start()
    {
        powerSlider.value = force;
        Physics.sleepThreshold = 0.1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        powerSlider.value = force;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (force > minForce)
            {
                force = force - 1000;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (force < maxForce)
            {
                force = force + 1000;
            }
            else
            { }
        }
        if (playerSpeed <= 0.01 && timer >= timeBetweenShots)
        {
            line.enabled = true;
            //playerBall.constraints = RigidbodyConstraints.FreezeRotation;
            playerBall.velocity = Vector3.zero;
            playerBall.angularVelocity = Vector3.zero;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //timer += Time.deltaTime;
        if (!finished)
        {
            if (playerSpeed <= 0.000001)
            {
                if (Input.GetButtonDown("Shoot"))
                {
                    line.enabled = false;
                    timer = 0f;
                    playerBall.AddForce(Camera.main.transform.forward * force);
                    golfHitSound.Play(0);
                    skotFjoldi = skotFjoldi + 1;
                    shotAmount.text = "Shots taken: " + skotFjoldi;
                }
            }
            if (playerSpeed >= 0.01)
            {
                line.enabled = false;
            }
        }

        playerSpeed = (transform.position - lastposition).magnitude;
        lastposition = transform.position;
    }

    private void OnCollisionEnter(Collision finish)
    {
        if (finish.gameObject.tag == "Finish")
        {
            finished = true;
        }
    }
}
