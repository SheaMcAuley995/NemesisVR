using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public float fadeDuration;
    public float waitToFade;

    private void Start()
    {
        SteamVR_Fade.Start(Color.black, 0f);
        Invoke("FadeFromBlack", waitToFade);
    }

    private void FadeFromBlack()
    {
        SteamVR_Fade.Start(Color.clear, fadeDuration);
    }

}
