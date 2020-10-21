using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    // Know waht objects are clickable
    public LayerMask clickableLayer;

    // Swap cursors per object
    public Texture2D pointer; // normal pointer
    public Texture2D target; // cursor for clickable objects like the world
    public Texture2D doorway; // cursor for doorways
    public Texture2D combat; // cursor for combat actions

    public EventVector3 onClickEnvvironment;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(combat, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                door = false;
                item = false;
            }

            if (Input.GetMouseButtonDown(0)) // left mouse click is index of 0
            {
                if (door)
                {
                    Transform doorWay = hit.collider.gameObject.transform;

                    onClickEnvvironment.Invoke(doorWay.position);
                    Debug.Log("Door");
                }
                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;

                    onClickEnvvironment.Invoke(itemPos.position);
                    Debug.Log("Item");
                }
                else
                {
                    onClickEnvvironment.Invoke(hit.point);
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }