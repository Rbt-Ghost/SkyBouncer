using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSound;
    private float pitchRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spacePressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool screenTapped = Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if ((spacePressed || screenTapped) && birdIsAlive)
        {
            pitchRange = UnityEngine.Random.Range(0.8f, 1.2f);
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            flapSound.pitch = pitchRange;
            flapSound.Play();
        }

        if (myRigidBody.position.y > 17 || myRigidBody.position.y < -17)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
