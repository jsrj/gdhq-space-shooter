using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLogic : MonoBehaviour
{

    [SerializeField]
    private float _descendSpeed;

    [SerializeField]
    private float _driftSpeed;

    [SerializeField]
    private float _driftRange;

    [SerializeField]
    private char driftDirection;

    [SerializeField]
    private float _posx;

    [SerializeField]
    private float spawnAxis;

    [SerializeField]
    private float _leftEdge;

    [SerializeField]
    private float _rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        this._descendSpeed = 1.15f;
        this._driftSpeed = 4.25f;
        this._driftRange = 4.00f;

        // Set spawn axis to the x position on instantiation
        this.spawnAxis = transform.position.x;

        // Set left and right drift edges
        this._leftEdge = -this._driftRange+this.spawnAxis;
        this._rightEdge = this._driftRange+this.spawnAxis;

        // Set a random starting drift direction
        if (Mathf.FloorToInt(Random.Range(0.00f, 10.00f)) % 2 == 0) {
            this.driftDirection = 'l';
        } else {
            this.driftDirection = 'r';
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Update value of pos (position on x axis)
        this._posx = transform.position.x;

        // Move power up toward bottom of screen
        transform.Translate(Vector2.down * this._descendSpeed * Time.deltaTime);
        
        // change drift direction when an edge is reached
        if (this._posx < this._leftEdge) {
            this.driftDirection = 'r';
        }
        if (this._posx > this._rightEdge) {
            this.driftDirection = 'l';
        }
    
        // Move power up based on current driftDirection value
        if (this.driftDirection == 'l') {
            transform.Translate(Vector2.left * this._driftSpeed * Time.deltaTime);
        }
        if (this.driftDirection == 'r') {
            transform.Translate(Vector2.right * this._driftSpeed * Time.deltaTime);
        }
    }
}
