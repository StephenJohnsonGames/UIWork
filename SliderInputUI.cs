using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderInputUI : MonoBehaviour
{

    private GameObject myObject;
    private GameObject myParent;
    EventSystem UIevents;
    Navigation sliderNav;

    void Start()
    {
        UIevents = EventSystem.current;
        myObject = this.gameObject;
        myParent = myObject.transform.parent.gameObject;

    }

    void Update()
    {
        //script to handle manipulating sliders using a controller

        if (UIevents.currentSelectedGameObject == this.gameObject)
        {
            sliderNav.mode = Navigation.Mode.Horizontal;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            UIevents.SetSelectedGameObject(this.myParent);
            myParent.GetComponent<SliderButtons>().myCheck = false;
        }

    }


}
