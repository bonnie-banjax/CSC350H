using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public static class ScreenUnits
{

    static bool beenSetup = false;
    static int screenWidth;
    static int screenHeight;
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    public static float genScreenLeft { get { return screenLeft; } }
    public static float genScreenRight { get {  return screenRight; } }
    public static float genScreenTop { get {  return screenTop; } }
    public static float genScreenBottom { get {  return screenBottom; } }

    public static void initialize()
    {
        if (beenSetup)
            return;
        
        float screenZ = Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 upperRightCornerWorld = Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;

        beenSetup = true;

    }
}
