﻿using System.Collections;
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
        
        // Move power up toward bottom of screen
        transform.Translate(Vector2.down * this._descendSpeed * Time.deltaTime);

        // Move power up left and right as it descends
        // IF x position is less than 0 and greater than negative drift range
        // THEN move left
        if (transform.position.x > -this._driftRange) {

        }
        
        // IF x position is greater than 0 and and less than drift range
        // THEN move right

        // IF x position is exactly 0
        // THEN randomly choose a drift direction

    }
}
