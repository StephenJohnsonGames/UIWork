using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NaturalRendering;

public class MenuScript : MonoBehaviour
{
    Manager manager;   
    public Button Menubutton;
    public bool ShowUI;
    public GameObject UI;
    public GameObject Buttons;
    public GameObject FPSPlayer;
    public GameObject FPSCamera;
    EventSystem UIevent;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<NaturalRendering.Manager>();
        UIevent = EventSystem.current;
        FPSPlayer = GameObject.Find("FPSPlayer");
        FPSCamera = GameObject.Find("NR_MainCam_LookAt");
        Button btn = Menubutton.GetComponent<Button>();
        UI.SetActive(false);
        Buttons.SetActive(false);
        btn.onClick.AddListener(delegate { ButtonClick(); });
        
    }

    // Update is called once per frame
    void Update()
    {

        //shortcut for getting up Menu on controller
        if (Input.GetKey(KeyCode.JoystickButton6) && Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            ShowUI = !ShowUI;
            UIevent.SetSelectedGameObject(this.gameObject);
        }

        if (ShowUI == true)
        {
            //UIevent.SetSelectedGameObject(this.gameObject);
            UI.SetActive(true);
            Buttons.SetActive(true);
            //Time.timeScale = 0;
            Cursor.visible = true;

            FPSCamera.GetComponent<FPSCamera>().enabled = false;
            //only on projects with FPSPlayer inside
            if (FPSPlayer)
            {
                //FPSPlayer.GetComponent<PlayerMovement>().enabled = false;
                FPSPlayer.GetComponent<PlayerMovement>().Acceleration = 0.0f;
            }


        }
        else
        {
            UI.SetActive(false);
            Buttons.SetActive(false);
            //Time.timeScale = 1;
            FPSCamera.GetComponent<FPSCamera>().enabled = true;


            //only on projects with FPSPlayer inside
            if (FPSPlayer)
            {
                //FPSPlayer.GetComponent<PlayerMovement>().enabled = true;
                FPSPlayer.GetComponent<PlayerMovement>().Acceleration = 0.2f;
            }

        }           
    }

    public void ButtonClick()
    {
        ShowUI = !ShowUI;
    }
}
