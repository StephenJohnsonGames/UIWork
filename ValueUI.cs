using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ValueUI : MonoBehaviour
{
    private GameObject myObject;
    private GameObject myParent;
    EventSystem UIevents;

    void Start()
    {
        UIevents = EventSystem.current;
        myObject = this.gameObject;
        myParent = myObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            UIevents.SetSelectedGameObject(this.myParent);
            this.gameObject.SetActive(false);
        }

    }

}

