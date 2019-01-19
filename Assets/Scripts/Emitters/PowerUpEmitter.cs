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
        this._lateralSpeed = 5.00f;
        this._horizontalBounds = 9.25f; 
        this._currentDirection = 'r';
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
