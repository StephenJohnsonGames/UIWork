using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Replace_Slider_Step : MonoBehaviour, IMoveHandler, IEndDragHandler
{
    private float step;            // the desired step
    private Slider slider;
    private float previousSliderValue;

    void Start()
    {
        slider = this.GetComponent<Slider>();
        previousSliderValue = slider.value;
        step = (slider.maxValue - slider.minValue) / 100.0f;
    }

    //Script to add custom steps on sliders for controllers, can be changed by dividing step by however many steps you want

    public void OnMove(AxisEventData eventData)
    {
        // override the slider value using our previousSliderValue and the desired step
        if (eventData.moveDir == MoveDirection.Left)
        {
            slider.value = (previousSliderValue - step);
        }

        if (eventData.moveDir == MoveDirection.Right)
        {
            slider.value = (previousSliderValue + step);
        }

        // keep the slider value for future use
        previousSliderValue = slider.value;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // keep the last slider value if the slider was dragged by mouse
        previousSliderValue = slider.value;
    }
}