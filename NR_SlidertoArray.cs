using UnityEngine;
using UnityEngine.UI;

public class NR_SlidertoArray : MonoBehaviour
{
    private Text MyValue;

    public float SavedValue;

    // Start is called before the first frame update
    void Start()
    {

        MyValue = GameObject.Find("Value_" + name.ToString()).GetComponent<Text>();
        //we'll only want to send the value if it changes 
        GetComponent<Slider>().onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        //make sure the floats are full at the start
        ValueChangeCheck();

        SavedValue = GetComponent<Slider>().value;

    }



    public void ValueChangeCheck()
    {
        //set up a string, a float
        //send to the array and display result in the GUI
        string name = this.name.ToString();
        float value = GetComponent<Slider>().value;
        MyValue.text = value.ToString("F2");

    }

    public void Reset()
    {

        GetComponent<Slider>().value = SavedValue;


    }
}
