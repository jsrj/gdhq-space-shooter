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
    private string driftDirection;

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
    }

    // Update is called once per frame
    void Update()
    {
        // Update value of pos (position on x axis)
        this._posx = transform.position.x;

        // Move power up toward bottom of screen
        // transform.Translate(Vector2.down * this._descendSpeed * Time.deltaTime);
        
        // clip fractional position value on edges of drift range
        if (this._posx < -(this._driftRange+this.spawnAxis)) {
            Debug.Log("Clipping Position to Left Edge");
            transform.position = new Vector2(-(this._driftRange+this.spawnAxis), transform.position.y);
        }

        if (this._posx > (this._driftRange+this.spawnAxis)) {
            Debug.Log("Clipping Position to Right Edge");
            transform.position = new Vector2((this._driftRange+this.spawnAxis), transform.position.y);
        }
    

        // Move power up left and right as it descends
        // IF x position is at max drift range or greater than negative drift range
        // THEN move left
        // if (this._posx >= -(this._driftRange+this.spawnAxis)) {
        //     Debug.Log("Powerup Moving Left");
        //     transform.Translate(Vector2.left * Time.deltaTime);
        // }

        // IF x position is at max negative drift range or less than drift range
        // THEN move right
        // if (this._posx <= (this._driftRange+this.spawnAxis)) {
        //     Debug.Log("Powerup Moving Right");
        //     transform.Translate(Vector2.left * -Time.deltaTime);
        // }

        // IF x position is exactly 0
        // THEN randomly choose a drift direction
    }
}
