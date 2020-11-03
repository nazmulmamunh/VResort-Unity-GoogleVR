using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBehaviorController : MonoBehaviour
{
    [SerializeField]
    RectTransform hotelContainer;
    [SerializeField]
    float easing = .5f;

    [SerializeField]
    GameObject mainSphere;

    [SerializeField]
    Renderer hotelsSpheres;

    [SerializeField]
    Material[] longBeach;
    [SerializeField]
    Material[] oceanParadise;

    [SerializeField]
    GameObject oceanParadiseUI;
    [SerializeField]
    GameObject longBeachUI;

    string name;

    [SerializeField]
    SphereChanger sphereChangerController;
    

    int matCounter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonLeft()
    {
        Vector3 newPos = new Vector3( hotelContainer.localPosition.x -20, 0, 0);
        StartCoroutine(SmoothTransaction(hotelContainer.localPosition, newPos, easing));
    }
    public void buttonRight()
    {
        Vector3 newPos = new Vector3(hotelContainer.localPosition.x +20, 0, 0);
        StartCoroutine(SmoothTransaction(hotelContainer.localPosition, newPos, easing));
    }

    IEnumerator SmoothTransaction(Vector3 prePos, Vector3 newPos, float seconds)
    {
        float t = 0f;

        while(t <= 1.0f)
        {
            t += Time.deltaTime / seconds;

            hotelContainer.localPosition = Vector3.Lerp(prePos,newPos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }

    public void HotelView(string hotelName)
    {
        matCounter = 0;
        if(hotelName == "i")
        {
            name = hotelName;
            longBeachUI.SetActive(true);
            hotelsSpheres.material = longBeach[matCounter];
        }

        if(hotelName == "o")
        {
            name = hotelName;
            oceanParadiseUI.SetActive(true);
            hotelsSpheres.material = oceanParadise[matCounter];
        }
        matCounter++;
    }

    public void Hotel()
    {
        if (matCounter > 2)
        {
            matCounter = 0;
        }
        if (name == "i")
        {
            sphereChangerController.ChangeRoom(longBeach[matCounter]);
            
           // hotelsSpheres.material = longBeach[matCounter];
        }
        if(name == "o")
        {
            sphereChangerController.ChangeRoom(oceanParadise[matCounter]);
            //hotelsSpheres.material = oceanParadise[matCounter];
        }
        matCounter++;
    }

    public void backToMainSphere()
    {
        longBeachUI.SetActive(false);
        oceanParadiseUI.SetActive(false);
        matCounter = 0;
    }
 
}
