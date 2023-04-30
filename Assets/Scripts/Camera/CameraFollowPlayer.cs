using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]private GameObject Player;
    [SerializeField]private Camera CameraPlayer;

    private void Update()
    {
        Vector3 newCameraPosition;

        newCameraPosition.z = CameraPlayer.transform.position.z;

        newCameraPosition.y = Player.transform.position.y;
        newCameraPosition.x = Player.transform.position.x;

        CameraPlayer.transform.position = newCameraPosition;
    }
}
