using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class FishCollector : MonoBehaviour
{
    [SerializeReference]
    public GameObject Fishie;
    
    LinkedList<GameObject> FishList;

    // Start is called before the first frame update
    private void Start()
    {
  
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
            
        }
        ReceiveMosuseInput();
    }


    void SpawnFish()
    {
        Vector3 Position = Input.mousePosition;
        GameObject newFishie = Fishie;
        FishList.AddLast(Instantiate(newFishie, Position, Quaternion.identity));
    }


    void ReceiveMosuseInput() //OnMouseDown.Event //OnMouseDown trigger
    {
        if (Input.GetButtonDown("Fire1")) // "SpawnFish")
        {
            Vector3 mousePos = Input.mousePosition;

            SpawnFish();
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);

        }

    }


    // Alternative
    public GameObject ProvideFishReference() //GameObject<FishPrefab>
    {
        return (FishList.First());
    }

    public void FishCaught()
    {
        if (FishList.First() == null)
            FishList.RemoveFirst();
    }

    //-----------|-----------\\--|--//-----------|-----------\\

}


