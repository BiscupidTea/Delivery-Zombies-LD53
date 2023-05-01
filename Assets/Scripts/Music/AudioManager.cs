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

    public void PlaySFX(AudioClip clip)
    {
        if (!SFXSource.isPlaying)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    #region WeaponsSounds
    int fireBuletShootgun = 0;
    public void PlayShootgunSFX()
    {
        fireBuletShootgun++;
        switch (fireBuletShootgun)
        {
            case 0:
                SFXSource.PlayOneShot(shootgunShoot1);
                break;
            case 1:
                SFXSource.PlayOneShot(shootgunShoot2);
                break;
            default:
                break;
        }

        if (fireBuletShootgun == 1)
        {
            fireBuletShootgun = 0;
        }
    }

    int fireBuletPistol = 0;
    public void PlayPistolSFX()
    {
        fireBuletPistol++;
        switch (fireBuletPistol)
        {
            case 0:
                SFXSource.PlayOneShot(gunShoot1);
                break;
            case 1:
                SFXSource.PlayOneShot(gunShoot2);
                break;
            case 2:
                SFXSource.PlayOneShot(gunShoot3);
                break;
            case 3:
                SFXSource.PlayOneShot(gunShoot4);
                break;
            default:
                break;
        }

        if (fireBuletPistol == 3)
        {
            fireBuletPistol = 0;
        }
    }

    int fireBuletRifle = 0;
    public void PlayRifleSoundSFX()
    {
        fireBuletRifle++;
        switch (fireBuletRifle)
        {
            case 0:
                SFXSource.PlayOneShot(rifleShoot1);
                break;
            case 1:
                SFXSource.PlayOneShot(rifleShoot2);
                break;
            case 2:
                SFXSource.PlayOneShot(rifleShoot3);
                break;
            case 3:
                SFXSource.PlayOneShot(rifleShoot4);
                break;
            case 4:
                SFXSource.PlayOneShot(rifleShoot5);
                break;
            case 5:
                SFXSource.PlayOneShot(rifleShoot6);
                break;
            case 6:
                SFXSource.PlayOneShot(rifleShoot7);
                break;
            default:
                break;
        }

        if (fireBuletRifle == 6)
        {
            fireBuletRifle = 0;
        }
    }
    #endregion

    #region PlayerSounds
    int walkSwitch = 0;
    public void PlayPlayerWalkSFX()
    {
        if (!SFXSource.isPlaying)
        {
            walkSwitch++;
            switch (walkSwitch)
            {
                case 0:
                    SFXSource.PlayOneShot(playerWalk1);
                    break;
                case 1:
                    SFXSource.PlayOneShot(playerWalk2);
                    break;
                case 2:
                    SFXSource.PlayOneShot(playerWalk3);
                    break;
                case 3:
                    SFXSource.PlayOneShot(playerWalk4);
                    break;
                default:
                    break;
            }

            if (walkSwitch == 3)
            {
                walkSwitch = 0;
            }
        }
    }

    int BuyPlayerSwitch = 0;
    public void PlayPlayerBuySFX()
    {
        BuyPlayerSwitch++;
        switch (BuyPlayerSwitch)
        {
            case 0:
                SFXSource.PlayOneShot(playerBuy1);
                break;
            case 1:
                SFXSource.PlayOneShot(playerBuy2);
                break;
            case 2:
                SFXSource.PlayOneShot(playerBuy3);
                break;
            default:
                break;
        }

        if (BuyPlayerSwitch == 2)
        {
            BuyPlayerSwitch = 0;
        }
    }

    #endregion

    #region ZombieSounds
    public void PlayZombieDamageSFX()
    {
        switch (Random.Range(0,4))
        {
            case 0:
                SFXSource.PlayOneShot(ZombieAttack1);
                break;
            case 1:
                SFXSource.PlayOneShot(ZombieAttack2);
                break;
            case 2:
                SFXSource.PlayOneShot(ZombieAttack3);
                break;
            case 3:
                SFXSource.PlayOneShot(ZombieAttack4);
                break;
            default:
                break;
        }
    }

    public void PlayZombieGetDamageSFX()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                SFXSource.PlayOneShot(Zombiedamage1);
                break;
            case 1:
                SFXSource.PlayOneShot(Zombiedamage2);
                break;
            case 2:
                SFXSource.PlayOneShot(Zombiedamage3);
                break;
            case 3:
                SFXSource.PlayOneShot(Zombiedamage4);
                break;
            default:
                break;
        }
    }

    public void PlayZombieDieSFX()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                SFXSource.PlayOneShot(ZombieDeath1);
                break;
            case 1:
                SFXSource.PlayOneShot(ZombieDeath2);
                break;
            case 2:
                SFXSource.PlayOneShot(ZombieDeath3);
                break;
            case 3:
                SFXSource.PlayOneShot(ZombieDeath4);
                break;
            default:
                break;
        }
    }
    #endregion
}
