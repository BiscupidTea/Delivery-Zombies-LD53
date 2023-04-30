using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseIndicator : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform target;

    [SerializeField] private float hideDistance;

    private bool HideArrow;

    [SerializeField] private float timerDelay;

    private float timerDelayInput;

    private void Start()
    {
        timerDelayInput = timerDelay;
    }

    void Update()
    {
        timerDelayInput += Time.deltaTime;
        var dir = target.position - transform.position;

        if (timerDelayInput >= timerDelay)
        {
            if (inputManager.CheckArrowInput())
            {
                HideArrow = !HideArrow;
                timerDelayInput = 0;
            }

            if (HideArrow)
            {
                SetChildrenActive(true);
            }
            else
            {
                SetChildrenActive(false);
            }
        }

        if (HideArrow)
        {
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

    }

    public void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
