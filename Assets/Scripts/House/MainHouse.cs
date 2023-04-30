using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHouse : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P)) 
        {
            ActivateShop();
        }
    }

    private void ActivateShop()
    {
        canvas.SetActive(true);

        Time.timeScale = 0;
    }

    public void ExitShop()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
}
