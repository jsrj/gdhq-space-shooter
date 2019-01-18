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
    private float pos;

    // Start is called before the first frame update
    void Start()
    {
        this._descendSpeed = 1.15f;
        this._driftSpeed = 4.25f;
        this._driftRange = 8.00f;

    }

    // Update is called once per frame
    void Update()
    {
        // Update value of pos (position on x axis)
        this.pos = transform.position.x;

        // clip fractional position value on edges of drift range
        if (this.pos < -this._driftRange) {
            this.pos = -this._driftRange;
        }
        
        if (this.pos > this._driftRange) {
            this.pos = this._driftRange;
        }
    
        // Move power up toward bottom of screen
        transform.Translate(Vector2.down * this._descendSpeed * Time.deltaTime);

        // Move power up left and right as it descends
        // IF x position is less than 0 and greater than negative drift range
        // THEN move left
        if (transform.position.x < 0 && transform.position.x > -this._driftRange) {

            transform.Translate(Vector2.left * this._driftSpeed * Time.deltaTime);
        }

        // IF x position is greater than 0 OR less than negative drift range, and less than drift range 
        // THEN move right
        if (transform.position.x > 0 && transform.position.x < this._driftRange) {

            transform.Translate(Vector2.right * this._driftSpeed * Time.deltaTime);
        }

        // IF x position is exactly 0
        // THEN randomly choose a drift direction
        if (transform.position.x == 0) {

            if (Random.Range(0.00f, 1.00f) % 0.20f == 0) {
                // Move left
            } else {
                // Move right
            }
        }

    }
}
