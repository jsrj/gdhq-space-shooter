using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEmitter : MonoBehaviour
{

    [SerializeField]
    private GameObject _puTripleShot;

    [SerializeField]
    private GameObject _puScatterShot;

    [SerializeField]
    private GameObject _puNeutronShot;

    [SerializeField]
    private GameObject _puSmartBomb;

    [SerializeField]
    private float _lateralSpeed;

    [SerializeField]
    private GameObject _playerRef;

    [SerializeField]
    private float _horizontalBounds;

    [SerializeField]
    private char _currentDirection;


    void Start()
    {
        // Define the constant movement speed of the emitter
        this._lateralSpeed = 5.00f;

        // Define the limit in either direction that emitter can move (should match player horizontalBounds)
        this._horizontalBounds = 9.25f; 

        // Define the starting direction. Should be right since emitter first starts on left edge.
        this._currentDirection = 'r';

        // Define emitter starting position on left edge
        transform.position = new Vector2(-9.25f, 9.00f);
    }


    void FixedUpdate() {
        
        // Reverse direction at edges of horizontal bounds
        if (transform.position.x < -this._horizontalBounds) {
            this._currentDirection = 'r';
        }
        if (transform.position.x > this._horizontalBounds) {
            this._currentDirection = 'l';
        }

        // Move emitter left and right at a fixed interval
        if (this._currentDirection == 'r') {
            transform.Translate(Vector2.right * this._lateralSpeed * Time.deltaTime);
        }
        if (this._currentDirection == 'l') {
            transform.Translate(Vector2.left * this._lateralSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        
    }
}
