using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{

    private float _startX = 0.0f;
    private float _startY = -3.85f;

    [SerializeField]
    private float _verticalAxis;
    [SerializeField]
    private float _horizontalAxis;
    [SerializeField]
    private float _topBuffer;
    [SerializeField]
    private float _verticalBounds;
    [SerializeField]
    private float _horizontalBounds;
    [SerializeField]
    private float _accelerationMultiplier;

    [SerializeField]
    private GameObject _laserBolt;

    private float _fireRate;
    private int _boltCount;
    private float _cannonCooldown;

    [SerializeField]
    private int _boltsFired = 0;

    private ArrayList _boltArray = new ArrayList();

    public string shotType;


    void Start()
    {

        // Set starting movement values
        this._topBuffer              = -2.45f;
        this._verticalBounds         = 3.85f;
        this._horizontalBounds       = 9.25f;
        this._accelerationMultiplier = 6.00f;

        // Set starting position
        transform.position = new Vector2(this._startX, this._startY);

        // Initialize fire rate and cooldown values
        this._fireRate = 0.45f;
        this._cannonCooldown = 0.00f;

        // Simulate picking up triple shot powerup
        this.shotType = "triple";
    }

    void FixedUpdate()
    {
        // Handle player movement logic
        this.processMovement();

        // Monitor that player remains in game area
        this.boundaryCheck();
    }


    void Update()
    {

        // TODO: Add conditional sprite animation depending on which direction player is moving

        // Default laser bolt cannon 3-round burst and cooldown logic
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > this._cannonCooldown) {

            if (this._boltCount < 3 || _boltsFired < 3) {
                this.fireLaser();
                this._boltsFired++;
            } else {
                this._cannonCooldown = Time.time + this._fireRate;
                this._boltsFired = 0;
            }
        }

        // Updates laser bolt count
        this._boltCount = this._boltArray.ToArray().Length;

        // Remove any laser bolts that have self-destructed
        foreach (GameObject bolt in this._boltArray) {
            if (bolt == null) {
                this._boltArray.Remove(bolt);
                break; // <- Required to avoid collection modification errors
            }
        }
    }


    private void processMovement() {

        // move ship forward and backward
        if (transform.position.y >= -_verticalBounds && transform.position.y <= _verticalBounds+_topBuffer) {
            this._verticalAxis = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * Time.deltaTime * (_accelerationMultiplier * _verticalAxis));
        }

        // move ship left and right
        if (transform.position.x >= -_horizontalBounds && transform.position.x <= _horizontalBounds) {
            this._horizontalAxis = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * (_accelerationMultiplier * _horizontalAxis));
        }
    }


    private void boundaryCheck() {

        // Establish play area boundaries
        if (transform.position.x < -_horizontalBounds) {
            transform.position = new Vector2(-_horizontalBounds, transform.position.y);
        }
        if (transform.position.x > _horizontalBounds) {
            transform.position = new Vector2(_horizontalBounds, transform.position.y);
        }
        if (transform.position.y < -_verticalBounds) {
            transform.position = new Vector2(transform.position.x, -_verticalBounds);
        }
        if (transform.position.y > _verticalBounds+_topBuffer) {
            transform.position = new Vector2(transform.position.x, _verticalBounds+_topBuffer);
        }
    }


    private void fireLaser() {
        Debug.Log(shotType.ToUpper());
        switch (shotType.ToUpper()) {

            case "TRIPLE":
                Debug.Log("Tripleshot Enabled");
                this.fireTripleShot();
                break;

            case "SCATTER":
                Debug.Log("Scattershot Enabled");
                // this.fireScatterShot();
                break;    

            default:
                this.fireSingleShot();
                break;    
        }
    }


    private void fireSingleShot() {

        GameObject bolt = Instantiate(
            this._laserBolt, 
            new Vector3(transform.position.x, transform.position.y+0.73f, 0.00f), 
            Quaternion.identity
        );

        this._boltArray.Add(bolt);
    }

    private void fireTripleShot() {

        GameObject rightWingBolt = Instantiate(
            this._laserBolt,
            new Vector3(transform.position.x+0.40f, transform.position.y+0.73f,0.00f),
            Quaternion.Euler(0.00f, 0.00f, -25.00f)
        );

        GameObject centerBolt = Instantiate(
            this._laserBolt,
            new Vector3(transform.position.x, transform.position.y+0.73f, 0.00f),
            Quaternion.identity
        );

        GameObject leftWingBolt = Instantiate(
            this._laserBolt,
            new Vector3(transform.position.x-0.4f, transform.position.y+0.73f, 0.00f),
            Quaternion.Euler(0.00f, 0.00f, 25.00f)
        );
    }
}
