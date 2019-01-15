using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private float startX = 0.0f;
    private float startY = -3.85f;
    private float startZ = 0.0f;

    public float topBuffer;
    public float verticalBounds;
    public float horizontalBounds;
    public float accelerationMultiplier;


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(this.name + " Initialized...");

        // Set starting movement values
        this.topBuffer              = -2.45f;
        this.verticalBounds         = 3.85f;
        this.horizontalBounds       = 9.25f;
        this.accelerationMultiplier = 6.00f;

        // Set starting position
        transform.position = new Vector3(this.startX, this.startY, this.startZ);
    }

    void FixedUpdate()
    {

        // move ship forward
        if (
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
            && 
            transform.position.y <= verticalBounds+topBuffer
        ) {
            transform.Translate(Vector2.up * Time.deltaTime * accelerationMultiplier);
        }

        // move ship backward
        if (
            (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
            && 
            transform.position.y >= -verticalBounds
        ) {
            transform.Translate(Vector2.down * Time.deltaTime * accelerationMultiplier);
        }

        // move ship left
        if ((
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
            && 
            transform.position.x >= -horizontalBounds
        ) {
            transform.Translate(Vector2.left * Time.deltaTime * accelerationMultiplier);
        }

        // move ship right
        if (
            (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
            && 
            transform.position.x <= horizontalBounds
        ) {
            transform.Translate(Vector2.right * Time.deltaTime * accelerationMultiplier);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // TODO: Add conditional sprite animation depending on which direction player is moving
    }
}
