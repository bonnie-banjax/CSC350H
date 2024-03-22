using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class ShipClass : MonoBehaviour
{

    Vector3 ShipPosition;
    GameObject TargetFish; // GameObject<FishPrefab> TargetFish;
    public FishCollector FishDispenser_Reference; // GameObject<FishCollector> FishDispenser_Reference;

    float SailForceMagnitude;
    bool AvastFlag;

    Rigidbody2D ShipHull;
    
    // Start is called before the first frame update
    void Start()
    {

        //ShipHull = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (!AvastFlag)
        { return; }

        if (TargetFish == null)
        { TargetFish = AcquireFishReference(FishDispenser_Reference); }

        SailToPosition(FindTargetFish(TargetFish));
        
    }

    //-----------|-----------\\--|--//-----------|-----------\\

    private void OnMouseDown()
    {
        AvastToggle();
    }

    void AvastToggle() //OnMouseDownLeft event
    {
        AvastFlag ^= AvastFlag;
    }

    void SailToPosition(Vector3 TargetPosition)
    {
        ShipPosition = this.transform.position;
	
        Vector3 SailDirection = TargetPosition - ShipPosition;
        this.ShipHull.AddForce(SailDirection);
    }

     Vector3 FindTargetFish(GameObject TargetFish)
    {
	    return TargetFish.transform.position;
    }

    GameObject AcquireFishReference(FishCollector FishDispenser_Reference)
    {
        return FishDispenser_Reference.ProvideFishReference();
    }

    void CatchFish() // on collision event
    {
        AvastFlag = false;
        Destroy(TargetFish);

        FishDispenser_Reference.FishCaught();
        FishDispenser_Reference.ProvideFishReference();
    }

    void GetSetFishDispensor(string ObjectName)
    {
        FishDispenser_Reference = GameObject.Find("ObjectName").GetComponent<FishCollector>(); // note: literal quotes for readability
    }




//-----------|-----------\\--|--//-----------|-----------\\|//-----------|-----------\\--|--//-----------|-----------\\
}


