using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] mysounds;


    private AudioSource powerup;
    private AudioSource sword;
    private AudioSource die;



    // Start is called before the first frame update
    void Start()
    {
        mysounds = GetComponents<AudioSource>();

        powerup = mysounds[0];
        sword = mysounds[1];
        die = mysounds[2];
    }


    public void PlayDie()
    {
        die.Play();
    }
    public void PlaySword()
    {
        sword.Play();
    }
    public void PlayPowerUp()
    {
        powerup.Play();
    }


}

