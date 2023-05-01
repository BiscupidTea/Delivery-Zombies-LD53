using UnityEngine.Audio;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [Header("------------- Audio Source -------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------- Audio clips -------------")]
    //music
    public AudioClip background;
    
    //enemy
    public AudioClip ZombieAttack1;
    public AudioClip ZombieAttack2;
    public AudioClip ZombieAttack3;
    public AudioClip ZombieAttack4;

    public AudioClip Zombiedamage1;
    public AudioClip Zombiedamage2;
    public AudioClip Zombiedamage3;
    public AudioClip Zombiedamage4;

    public AudioClip ZombieDeath1;
    public AudioClip ZombieDeath2;
    public AudioClip ZombieDeath3;
    public AudioClip ZombieDeath4;

    //miselanius
    public AudioClip Ambiente;

    //player
    public AudioClip playerDamage;
    public AudioClip playerDelivery;

    public AudioClip playerBuy1;
    public AudioClip playerBuy2;
    public AudioClip playerBuy3;

    public AudioClip playerWalk1;
    public AudioClip playerWalk2;
    public AudioClip playerWalk3;
    public AudioClip playerWalk4;

    //weapons
    public AudioClip gunShoot1;
    public AudioClip gunShoot2;
    public AudioClip gunShoot3;
    public AudioClip gunShoot4;
    
    public AudioClip shootgunShoot1;
    public AudioClip shootgunShoot2;
    public AudioClip shootgunLoad;

    public AudioClip rifleShoot1;
    public AudioClip rifleShoot2;
    public AudioClip rifleShoot3;
    public AudioClip rifleShoot4;
    public AudioClip rifleShoot5;
    public AudioClip rifleShoot6;
    public AudioClip rifleShoot7;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

}
