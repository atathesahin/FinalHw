using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOut : MonoBehaviour
{
    private float topBound = 55;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TopVector();
    }

    void TopVector()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -topBound)
        {
            Destroy(gameObject);
        }
    }
}
