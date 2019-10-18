using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speedMove = 30.0f;
    private float scrollSpeed = 5.0f;
    private float minY = 10.0f;
    private float maxY = 40.0f;
    public static float minX;
    public static float maxX;
    public static float minZ;
    public static float maxZ;

    
    void Update()
    {
        if (GameMenu.isPaused)
            return;

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;

        pos.x += inputX * speedMove * Time.deltaTime;
        pos.z += inputZ * speedMove * Time.deltaTime;

        //Vector3 movement = new Vector3(1 * inputX, 0, 1 * inputZ);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        //transform.Translate(movement * Time.deltaTime * speedMove, Space.World);

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scrollWheel * scrollSpeed * Time.deltaTime * 25;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
