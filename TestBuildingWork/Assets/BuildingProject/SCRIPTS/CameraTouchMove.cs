using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouchMove : MonoBehaviour
{
    public float speed;
    private Vector2 startPos;
    public Camera cam;

    public float minZ;
    public float maxZ;
    private float targetPos;
    float pos;
    void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position.z;
        Debug.Log(transform.position.z + " transform.position.zStaRT");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) startPos = cam.ScreenToViewportPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            pos = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;

            targetPos = Mathf.Clamp(transform.position.z - pos, minZ, maxZ);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, targetPos, speed * Time.deltaTime));
        //targetPos);      // Mathf.Lerp(transform.position.z, targetPos, speed * Time.deltaTime));
    }
}
