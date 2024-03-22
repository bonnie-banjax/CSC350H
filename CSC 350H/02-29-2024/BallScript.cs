using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Mathematics;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (!Application.isPlaying)

        float randAngle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
        float magnitude = UnityEngine.Random.Range(3, 5);
        Vector2 direction = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
        // Vector2 direction = Vector2(magnitude * Mathf.Cos(randAngle), magnitude * Mathf.Sin(randAngle));// 
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(magnitude * direction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
