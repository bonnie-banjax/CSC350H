using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Mathematics;
using System;
using UnityEngine.UIElements;

[Serializable]
public class AgentShape : MonoBehaviour
{
    float randAngle;
    float magnitude;
    Vector2 direction;
    Vector2 pos;
    Rigidbody2D myRigidbody2D;
    float horizontalInput;
    float verticalInput;

    float screenLeft;
    float screenRight;
    float screenTop;
    float screenBottom;

    float lim_x = 10;
    float lim_y = 10;

    

    void Start()
    {
        myRigidbody2D = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        //myRigidbody2D.isKinematic = true;
        myRigidbody2D.gravityScale = 0.7f;
        magnitude = 1;
        //func_00();

        lim_x = ScreenUnits.genScreenRight;
        lim_y = ScreenUnits.genScreenTop;
        Debug.Log($"limx = {lim_x}, limy = {lim_y}");
    }

    // Update is called once per frame
    void Update()
    {

        func_01();
        func_02();
        func_03b();
    }

    void func_00()
    {

        float screenZ = Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        float screenLeft = lowerLeftCornerWorld.x;
        float screenRight = upperRightCornerWorld.x;
        float screenTop = upperRightCornerWorld.y;
        float screenBottom = lowerLeftCornerWorld.y;

        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        Vector3 circleColliderDim = collider.bounds.max - collider.bounds.min;

        lim_x = screenRight;
        lim_y = screenTop;
        Debug.Log($"limx = {lim_x}, limy = {lim_y}");

    }

    void func_01()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // -1, 0, 1
        verticalInput = Input.GetAxis("Vertical");

        direction += new Vector2(horizontalInput, verticalInput);
        //pos = new Vector2(transform.position.x, transform.position.y);
        //transform.position = pos + direction*(1/60);

        myRigidbody2D.AddForce(Vector2.ClampMagnitude(magnitude * direction, 1));
    }

    void func_02()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            myRigidbody2D.isKinematic ^= true;
            myRigidbody2D.MovePosition(new Vector2(0, 0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody2D.velocity = new Vector2((myRigidbody2D.velocity.x) * 0.9f, (myRigidbody2D.velocity.x) * 0.9f);
            myRigidbody2D.SetRotation(0);
            myRigidbody2D.MovePosition(new Vector2(transform.position.x * 0.9f, transform.position.y * 0.9f));
            Debug.Log($"{myRigidbody2D.totalForce}");
            //myRigidbody2D.MovePosition(new Vector2(0, 0)); 
        }
    }

    void func_03a()
    {
        if (transform.position.x > lim_x || transform.position.x < -lim_x)
        {
            //pos = new Vector2(transform.position.x, transform.position.y);
            transform.position = new Vector2(0, transform.position.y);
        }
        if (transform.position.y > lim_y || transform.position.y < -lim_y)
        {
            //pos = new Vector2(transform.position.x, transform.position.y);
            transform.position = new Vector2(transform.position.x, 0);
        }

    }

    void func_03b()
    {
        if (transform.position.x > lim_x || transform.position.x < -lim_x)
        {
            transform.position = new Vector2(Mathf.Clamp(-transform.position.x, -lim_x, lim_x), transform.position.y);
        }
        if (transform.position.y > lim_y || transform.position.y < -lim_y)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(-transform.position.y, -lim_y, lim_y));
        }

    }


    void func_04()
    {
        Vector3 position = transform.position;
    }

}

//direction = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
//myRigidbody2D.AddForce(magnitude * direction);
//this.transform.position = new Vector2(1, 0);
// myRigidbody2D.totalForce = new Vector2(0, 0);
//this.transform.position = transform.position //+ horizontalInput;
//direction =  (Vector2)(transform.position.x, transform.position.y);
//(magnitude * direction) * (1/Time.deltaTime)
//Mathf.Clamp(myRigidbody2D.totalForce, 0, 100);