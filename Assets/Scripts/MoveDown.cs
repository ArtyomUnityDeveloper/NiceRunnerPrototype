using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 3.0f;

    private float zDestroy = -6;
    private float zDestroyTop = 20;
    private float xDestroy = 19;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > zDestroyTop)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > xDestroy)
        {
            Destroy(gameObject); 
        }
        else if (transform.position.x < -xDestroy)
        {
            Destroy(gameObject);
        }
    }
}
