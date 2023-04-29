using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIndicator : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float hideDistance;

    void Update()
    {
        var dir = target.position - transform.position;

        if (dir.magnitude < hideDistance)
        {
            SetChildrenActive(false);
        }

        else
        {
            SetChildrenActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void SetChildrenActive(bool value) 
    {
        foreach (Transform child in transform) 
        {
            child.gameObject.SetActive(value);
        }
    }
}
