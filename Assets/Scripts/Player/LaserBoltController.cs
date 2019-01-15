using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBoltController : MonoBehaviour
{
    [SerializeField]
    private float laserBoltSpeed = 6.00f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Accelerates each laserBolt instance forward along Y axis
        transform.Translate(Vector2.up * Time.deltaTime * this.laserBoltSpeed);

        // Destroy a laser bolt once it has moved a certain range out of camera frustrum
        if (transform.position.y > 10.00f) {
            GameObject.Destroy(this.gameObject);
        }
    }
}
