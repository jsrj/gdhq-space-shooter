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
        this._posx = transform.position.x;

        // Move power up toward bottom of screen
        transform.Translate(Vector2.down * this._descendSpeed * Time.deltaTime);
        
        // clip fractional position value on edges of drift range
        if (this._posx < -this._driftRange) {
            this._posx = -this._driftRange;
        }

        if (this._posx > this._driftRange) {
            this._posx = this._driftRange;
        }
    

        // Move power up left and right as it descends
        // IF x position is at max drift range or greater than negative drift range
        // THEN move left
        if (this._posx > -this._driftRange || this._posx == this._driftRange) {

            transform.Translate(Vector2.left * this._driftSpeed * Time.deltaTime);
        }

        // IF x position is at max negative drift range or less than drift range
        // THEN move right
        if (this._posx < this._driftRange || this._posx == -this._driftRange) {

            transform.Translate(Vector2.right * this._driftSpeed * Time.deltaTime);
        }

        // IF x position is exactly 0
        // THEN randomly choose a drift direction
    }
}
