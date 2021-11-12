using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemnet : MonoBehaviour
{
    public float speed = 1f;


    private void Update()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
}
