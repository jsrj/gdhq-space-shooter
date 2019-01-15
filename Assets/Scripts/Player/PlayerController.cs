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
    public float verticalAxis;
    public float horizontalAxis;


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

        // move ship forward and backward
        if (transform.position.y >= -verticalBounds && transform.position.y <= verticalBounds+topBuffer) {
            this.verticalAxis = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * Time.deltaTime * (accelerationMultiplier * verticalAxis));
        }

        // move ship left and right
        if (transform.position.x >= -horizontalBounds && transform.position.x <= horizontalBounds) {
            this.horizontalAxis = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * (accelerationMultiplier * horizontalAxis));
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Bounceback into play area if player goes slightly out of bounds
        if (transform.position.x < -horizontalBounds) {
            transform.Translate(Vector2.right * Time.deltaTime * 1.00f);
        }
        if (transform.position.x > horizontalBounds) {
            transform.Translate(Vector2.right * Time.deltaTime * -1.00f);
        }
        if (transform.position.y < startY) {
            transform.Translate(Vector2.up * Time.deltaTime * 1.00f);
        }
        if (transform.position.y > verticalBounds+topBuffer) {
            transform.Translate(Vector2.up * Time.deltaTime * -1.00f);
        }

        // TODO: Add conditional sprite animation depending on which direction player is moving
    }
}
