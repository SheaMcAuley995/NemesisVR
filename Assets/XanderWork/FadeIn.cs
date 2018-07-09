using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public float fadeDuration;
    public float waitToFade;
    public AudioSource musicPlayer;

    private float musicStartVolume;
    private bool fading = true;



    private void Start()
    {
        musicStartVolume = musicPlayer.volume;
        musicPlayer.volume = 0;
        SteamVR_Fade.Start(Color.black, 0f);
        Invoke("FadeFromBlack", waitToFade);
    }

    private void FadeFromBlack()
    {
        SteamVR_Fade.Start(Color.clear, fadeDuration);
    }

    private void Update()
    {
        if(fading)
        {
            musicPlayer.volume += (musicStartVolume / (waitToFade + fadeDuration)) * Time.deltaTime;
            if(musicPlayer.volume >= musicStartVolume)
            {
                musicPlayer.volume = musicStartVolume;
                fading = false;
            }
        }
    }

}
