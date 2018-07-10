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
        public TeamManager.TeamBall team;

        public AudioSource musicPlayer;
        private bool fading = false;
        private float musicStartVolume;

        private int handsIn = 0;
        private static bool startingGame = false;
        private List<Hand> handsInList = new List<Hand>();



        private void Awake()
        {
            musicStartVolume = musicPlayer.volume;
        }

        private void Start()
        {
            //renderer.material = normalMat;
            startingGame = false;
        }

        private void Update()
        {
            if(fading)
            {
                musicPlayer.volume -= (musicStartVolume / fadeToBlackDuration) * Time.deltaTime;
            }
        }

        private void OnHandHoverBegin(Hand hand)
        {
            //renderer.material = touchingMat;
            ++handsIn;
            handsInList.Add(hand);
        }

        private void OnHandHoverEnd(Hand hand)
        {
            --handsIn;
            handsInList.Remove(hand);
            if(handsIn == 0)
            {
                //renderer.material = normalMat;
            }
        }

        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() && !startingGame)
            {
                startingGame = true;
                //renderer.material = holdingMat;
                SceneBridge.Instance.playerTeam = team;
                fading = true;
                SteamVR_Fade.Start(Color.black, fadeToBlackDuration);
                Invoke("GoToMenu", fadeToBlackDuration);
            }
        }

        private void GoToMenu()
        {
            SceneManager.LoadSceneAsync(gameSceneName);
        }

        public bool IsHandIn(Hand hand)
        {
            return handsInList.Contains(hand);
        }

    }
}
