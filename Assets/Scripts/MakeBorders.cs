using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBorders : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TopBorder;
    public GameObject BottomBorder;
    public GameObject RightBorder;
    public GameObject LeftBorder;
    public Camera cam;
    void Start()
    {
        SetBorders();
    }
    
    void SetBorders()
    {
        Vector3 point = new Vector3();

        point = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane));
        point.y += 0.33f;
        point.x -= 0;
        TopBorder.transform.position = point;
        
        point = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        point.y -= 0.33f;
        point.x -= 0;
        BottomBorder.transform.position = point;
        
        point = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        point.x -= 0.33f;
        point.y -= 0;
        LeftBorder.transform.position = point;
        
        point = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane));
        point.x += 0.33f;
        point.y -= 0;
        RightBorder.transform.position = point;
    }
}
