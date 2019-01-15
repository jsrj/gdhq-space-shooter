using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private float startX = 0.0f;
    private float startY = -3.85f;

    [SerializeField]
    private float verticalAxis;
    [SerializeField]
    private float horizontalAxis;
    [SerializeField]
    private float topBuffer;
    [SerializeField]
    private float verticalBounds;
    [SerializeField]
    private float horizontalBounds;
    [SerializeField]
    private float accelerationMultiplier;

    public GameObject laserBolt;

    public int laserBoltCount;

    private ArrayList boltArray = new ArrayList();


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
        transform.position = new Vector2(this.startX, this.startY);
    }

    void FixedUpdate()
    {
        this.processMovement();
    }

    // Update is called once per frame
    void Update()
    {
        this.boundaryCheck();

        // TODO: Add conditional sprite animation depending on which direction player is moving

        // If spacekey pressed, spawn laser prefab and accelerate forward along Y axis 
        if (Input.GetKeyDown(KeyCode.Space) && laserBoltCount < 3) {
            this.fireLaserBolt();
        }

        // Updates laser bolt count
        this.laserBoltCount = this.boltArray.ToArray().Length;

        // Checks if any laser bolts have self-destructed
        foreach (GameObject bolt in this.boltArray) {

            if (bolt == null) {
                this.boltArray.Remove(bolt);
                break; // <- Required to avoid a collection modification error
            }
        }
    }

    private void processMovement() {

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

    private void boundaryCheck() {

        // Establish play area boundaries
        if (transform.position.x < -horizontalBounds) {
            transform.position = new Vector2(-horizontalBounds, transform.position.y);
        }
        if (transform.position.x > horizontalBounds) {
            transform.position = new Vector2(horizontalBounds, transform.position.y);
        }
        if (transform.position.y < -verticalBounds) {
            transform.position = new Vector2(transform.position.x, -verticalBounds);
        }
        if (transform.position.y > verticalBounds+topBuffer) {
            transform.position = new Vector2(transform.position.x, verticalBounds+topBuffer);
        }
    }

    private void fireLaserBolt() {

        GameObject bolt = Instantiate(
            this.laserBolt, 
            new Vector3(transform.position.x, transform.position.y+0.73f, 0.00f), 
            Quaternion.identity
        );

        this.boltArray.Add(bolt);
    }
}
