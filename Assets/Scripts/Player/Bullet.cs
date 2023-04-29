using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]private Rigidbody2D MyRb;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MyRb.velocity = new Vector2(+Speed, 0);
        Destroy(gameObject, 5f);
    }
}
