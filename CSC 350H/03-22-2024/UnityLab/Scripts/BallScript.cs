using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Mathematics;
using System;

public class BallScript : MonoBehaviour
{
    float randAngle;
    float magnitude;
    Vector2 direction;
    Rigidbody2D myRigidbody2D;
    // [SerializeField] GameObject prefab; // (?)
    //[SerializeField] TimerComponent[] myTimer;
    //TimerComponent[] myTimer; // TimerComponent // TimerClass
    TimerComponent myTimer;
    //Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        //if (!Application.isPlaying)
        randAngle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
        magnitude = UnityEngine.Random.Range(100, 100);

        direction = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
        // Vector2 direction = Vector2(magnitude * Mathf.Cos(randAngle), magnitude * Mathf.Sin(randAngle));// 

        myRigidbody2D = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        myRigidbody2D.AddForce(magnitude * direction);
        // myTimer = this.gameObject.AddComponent<TimerComponent>();
        myTimer = new(); // new TimerComponent[10];
        myTimer.boot();
        myTimer.set_threshold(1000);
        myTimer.start_timer();

    }

    // Update is called once per frame
    void Update()
    {
        bool trigger = myTimer.Tick(); //direction += new Vector2(0, -1);

        //direction = new Vector2(1, 1);
        direction = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
        myRigidbody2D.AddForce(magnitude * direction);

        if (trigger == true)
        {
            Debug.Log("[V]");
            this.transform.position = new Vector2(0, 0);
            myRigidbody2D.totalForce = new Vector2(0, 0);
            myTimer.reset_timer();
            //trigger = false;
        }
            
        //this.transform.position = new Vector2(0, 0);
        //Destroy(this);
        
    }
}
