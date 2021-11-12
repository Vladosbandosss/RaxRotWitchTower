using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BG" || collision.tag == "Platform" || collision.tag == "Goast")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
