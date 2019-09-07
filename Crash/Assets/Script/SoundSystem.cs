using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public AudioSource audioSourceCoin;
    public AudioSource audioSourceFlap;
    public AudioSource audioSourceHit;
    // Start is called before the first frame update
    private void Awake()
    {
        if(SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }else if(SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

   public void PlayCoin()
    {
        audioSourceCoin.Play();
    }
    public void PlayFlap()
    {
        audioSourceFlap.Play();
    }
    public void PlayHit()
    {
        audioSourceHit.Play();
    }

    private void OnDestroy()
    {
       if(SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        } 
    }
}

