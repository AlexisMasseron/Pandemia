using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDraging = false;
    private bool isOverDropZone = false;
    private Vector2 startPosition;
    private GameObject dropZone;
    private GameObject UI;
    public int value = 1;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("happinessCount");
    }

    void Update()
    {
        if(isDraging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDraging = true;
    }

    public void EndDrag() 
    {
        int hapinessUI;
        isDraging = false;
        if(isOverDropZone)
        {
            if(gameObject.tag == "goodCard")
            {
                hapinessUI = int.Parse(UI.GetComponent<Text>().text) + value;    
            } else 
            {
                hapinessUI = int.Parse(UI.GetComponent<Text>().text) - value; 
            }
            UI.GetComponent<Text>().text = hapinessUI + "";
            Destroy(gameObject);

        } else 
        {
            transform.position = startPosition;
        }
    }
}
