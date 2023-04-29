using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    public GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey("a")) 
        {

            gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {

            gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey("up") || Input.GetKey("w"))
        {

            gameObject.transform.Translate(0, speed * Time.deltaTime, 0);

        }

        if (Input.GetKey("down") || Input.GetKey("s"))
        {

            gameObject.transform.Translate(0, -speed * Time.deltaTime, 0);

        }


    }



}
