using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem
{

    [RequireComponent(typeof(Interactable))]
    public class GameStartObj : MonoBehaviour
    {

        public string gameSceneName;

        public Renderer renderer;
        public Material normalMat;
        public Material touchingMat;
        public Material holdingMat;

        public float fadeToBlackDuration;

        private int handsIn = 0;



        private void Start()
        {
            renderer.material = normalMat;
        }

        private void OnHandHoverBegin(Hand hand)
        {
            renderer.material = touchingMat;
            ++handsIn;
        }

        private void OnHandHoverEnd(Hand hand)
        {
            --handsIn;
            if(handsIn == 0)
            {
                renderer.material = normalMat;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown())
            {
                renderer.material = holdingMat;
                SteamVR_Fade.Start(Color.black, fadeToBlackDuration);
                Invoke("GoToMenu", fadeToBlackDuration);
            }
        }

        private void GoToMenu()
        {
            SceneManager.LoadSceneAsync(gameSceneName);
        }

    }
}
