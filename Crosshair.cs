using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private RectTransform crosshair;

    public float stillSize;
    public float maxSize;
    public float speed;
    private float currentSize;

    bool playerMovement
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0 || 
                Input.GetAxis("Vertical") != 0 || 
                Input.GetAxis("Mouse X") != 0 || 
                Input.GetAxis("Mouse Y") != 0)
                return true;
            else
                return false;
        }
    }

    void Start()
    {
        crosshair = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(playerMovement)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, stillSize, Time.deltaTime * speed);
        }

        crosshair.sizeDelta = new Vector2(currentSize, currentSize);
    }
}
