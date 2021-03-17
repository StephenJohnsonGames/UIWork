﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveScrollRectButtons : MonoBehaviour
{
    private float m_lerpTime;
    private ScrollRect m_scrollRect;
    private Button[] m_buttons;
    private int m_index;
    private float m_verticalPosition;
    private EventSystem events;
    private GameObject buttonArea;
    private GameObject selected;
    private float m_up;
    private bool Trigger;
    public GameObject sliders;

    public void Start()
    {
        m_scrollRect = GetComponent<ScrollRect>();
        m_buttons = GetComponentsInChildren<Button>();
        m_verticalPosition = 1f - ((float)m_index / (m_buttons.Length - 1));
        events = EventSystem.current;
    }

    public void Update()
    {
        selected = events.currentSelectedGameObject;

        m_up = Input.GetAxis("Vertical");

        if (m_up >= 1.0f)
        {
            m_index = Mathf.Clamp(m_index - 1, 0, m_buttons.Length - 1);
            m_verticalPosition = 1f - ((float)m_index / (m_buttons.Length - 1));
        }
        if (m_up <= -1.0f)
        {
            m_index = Mathf.Clamp(m_index + 1, 0, m_buttons.Length - 1);
            m_verticalPosition = 1f - ((float)m_index / (m_buttons.Length - 1));
        }
        
        m_scrollRect.verticalNormalizedPosition = Mathf.Lerp(m_scrollRect.verticalNormalizedPosition, m_verticalPosition, Time.deltaTime / 0.7f);

    }

}
