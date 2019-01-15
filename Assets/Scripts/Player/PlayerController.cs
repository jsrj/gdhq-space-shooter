using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private float startX = 0.0f;
    private float startY = -3.85f;
    private float startZ = 0.0f;

    public float topBuffer = -2.45f;
    public float verticalBounds = 3.85f;
    public float horizontalBounds = 9.25f;
    public float accelerationMultiplier = 0.15f;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(this.name + " Initialized...");
        transform.position = new Vector3(this.startX, this.startY, this.startZ);
    }

    void FixedUpdate()
    {

        // move ship forward
        if (Input.GetKey(KeyCode.W) && transform.position.y <= verticalBounds+topBuffer) {
            transform.Translate(Vector2.up * accelerationMultiplier);
        }

        // move ship backward
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -verticalBounds) {
            transform.Translate(Vector2.down * accelerationMultiplier);
        }

        // move ship left
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -horizontalBounds) {
            transform.Translate(Vector2.left * accelerationMultiplier);
        }

        // move ship right
        if (Input.GetKey(KeyCode.D) && transform.position.x <= horizontalBounds) {
            transform.Translate(Vector2.right * accelerationMultiplier);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
