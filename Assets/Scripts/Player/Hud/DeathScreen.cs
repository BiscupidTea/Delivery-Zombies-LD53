using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private GameObject HUDplayer;
    [SerializeField] private GameObject DeathScreenView;

    private void Start()
    {
        DeathScreenView.SetActive(false);
    }
    private void Update()
    {
        if (player.dead)
        {
            HUDplayer.SetActive(false);
            DeathScreenView.SetActive(true);
        }
    }
}
