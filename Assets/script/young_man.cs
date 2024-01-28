using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class young_man : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        if (transform.position.x >= 12f)
        {
            Destroy(gameObject);
        }
    }
}
