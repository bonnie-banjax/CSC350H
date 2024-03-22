
// Andrew Mobus
// Unity Lab 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is the first game");
        Vector3 position = transform.position;
        //Vector3 position = (0, 0, 0);
        position.x = 1;
        transform.position = position;

        Vector3 scaleChange = new Vector3(2, 2, 2);

        transform.localScale *= 2; // this should work, not sure the issue
        //this.transform.localScale += scaleChange;
        RigidBody2D rigibodi = GetComponent<RigidBody2D>();
        int a = Random.Range(-5, 5);
        int b = Random.Range(-5, 5);
        rigibodi.AddForce( new Vector2(a,b), ForceMode2D.Impulse);


    }

    // Update is called once per frame
    void Update()
    {
    

    }
}


// todo: scale to 2x sze
// move ballss