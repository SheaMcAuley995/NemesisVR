using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GoalTrigger : MonoBehaviour {

    public int scorePerGoal = 1;
    public float postMoveSpeed;

    public Transform sunPost;
    public Transform moonPost;
    public Transform sunPostEnd;
    public Transform moonPostEnd;

    [Header("Audio")]
    public AudioSource sunPostAudio;
    public AudioSource moonPostAudio;
    public AudioSource goalAudio;
    public AudioClip scoreClip;
    public float scoreClipVolume;
    public AudioClip postStopClip;
    public float postStopClipVolume;

    private Vector3 sunPostMoveTo;
    private Vector3 moonPostMoveTo;
    private Vector3 sunPostMoveIncrement;
    private Vector3 moonPostMoveIncrement;



    private void Awake()
    {
        sunPostMoveTo = sunPost.position;
        moonPostMoveTo = moonPost.position;
    }

    private void Start()
    {
        sunPostMoveIncrement = (sunPostEnd.position - sunPost.position).normalized *
                                  (Vector3.Distance(sunPost.position, sunPostEnd.position)
                                   / ScoreManager.Instance.scoreToWin);
        moonPostMoveIncrement = (moonPostEnd.position - moonPost.position).normalized *
                                  (Vector3.Distance(moonPost.position, moonPostEnd.position)
                                   / ScoreManager.Instance.scoreToWin);
    }

    private void Update()
    {
        if (Vector3.Distance(sunPost.position, sunPostMoveTo) > postMoveSpeed)
        {
            sunPost.position += (sunPostMoveTo - sunPost.position).normalized * postMoveSpeed * Time.deltaTime;
            if(!(Vector3.Distance(sunPost.position, sunPostMoveTo) > postMoveSpeed))
            {
                sunPostAudio.Stop();
                goalAudio.PlayOneShot(postStopClip, postStopClipVolume);
            }
        }
        if (Vector3.Distance(moonPost.position, moonPostMoveTo) > postMoveSpeed)
        {
            moonPost.position += (moonPostMoveTo - moonPost.position).normalized * postMoveSpeed * Time.deltaTime;
            if(!(Vector3.Distance(moonPost.position, moonPostMoveTo) > postMoveSpeed))
            {
                moonPostAudio.Stop();
                goalAudio.PlayOneShot(postStopClip, postStopClipVolume);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TeamManager.ballStatus == TeamManager.TeamBall.Moon)
        {
            MoonGoalTrigger(other);
        }
        else if (TeamManager.ballStatus == TeamManager.TeamBall.Sun)
        {
            SunGoalTrigger(other);
        }
    }

    public void SunGoalTrigger(Collider other)
    {
        if (other.tag == "Ball")
        {
            HoverBall.Instance.ballReset();
            if (ScoreManager.Instance.ScoreSun < ScoreManager.Instance.scoreToWin)
            {
                sunPostMoveTo += sunPostMoveIncrement;
                sunPostAudio.Play();
                goalAudio.PlayOneShot(scoreClip, scoreClipVolume);
            }
            ScoreManager.Instance.AddScoreSun(scorePerGoal);
        }
    }

    public void MoonGoalTrigger(Collider other)
    {
        if (other.tag == "Ball")
        {
            HoverBall.Instance.ballReset();
            if (ScoreManager.Instance.ScoreMoon < ScoreManager.Instance.scoreToWin)
            {
                moonPostMoveTo += moonPostMoveIncrement;
                moonPostAudio.Play();
                goalAudio.PlayOneShot(scoreClip, scoreClipVolume);
            }
            ScoreManager.Instance.AddScoreMoon(scorePerGoal);
        }
    }

}
