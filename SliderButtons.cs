using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderButtons : MonoBehaviour
{
    private Button myButton;
    public bool myCheck = false;
    private GameObject myObject;
    private GameObject myChild;
    private GameObject myChild2;
    EventSystem SliderButtonEvent;

    void Start()
    {
        SliderButtonEvent = EventSystem.current;
        myObject = this.gameObject;
        myChild = myObject.transform.GetChild(0).gameObject;
        myChild.SetActive(false);
        myChild2 = myObject.transform.GetChild(1).gameObject;
        myChild2.SetActive(false);
        myButton = this.GetComponent<Button>();
    }

    //show and hide sliders for controllers

    // Update is called once per frame
    void Update()
    {
        if (SliderButtonEvent.currentSelectedGameObject == myObject && (Input.GetButtonDown("Submit") || (Input.GetMouseButtonUp(0))))
        {
            myCheck = !myCheck;
        }

        if(SliderButtonEvent.currentSelectedGameObject == myChild && (Input.GetButton("Submit"))) {
            SliderButtonEvent.SetSelectedGameObject(myObject);
            myCheck = false;
        }

        if(myCheck == true)
        {
            myChild.SetActive(true);
            myChild2.SetActive(true);
        }

        else
        {
            myChild.SetActive(false);
            myChild2.SetActive(false);
        }

    }
   
}
