using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class EnemyFrustrum : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer meshRenderer;
    [SerializeField] private Plane[] cameraFrustrum;
    [SerializeField] private Bounds bounds;


    private void Start()
    {
        mainCamera = Camera.main;
        meshRenderer = GetComponent<SpriteRenderer>();
        bounds = GetComponent<Collider2D>().bounds;
    }

    private void Update()
    {
        cameraFrustrum = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustrum, bounds))
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
