using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class headback : MonoBehaviour
{
    public GameObject text;
    public CinemachineVirtualCamera vcam5;
    public PlayableDirector timeline1;
    public GameObject badguy;
    public bool playstart = false;
    // Start is called before the first frame update
    void Start()
    {
        var vcam5 = GetComponent<CinemachineVirtualCamera>();
        timeline1 = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeline1.state == PlayState.Paused && playstart)
        {
            playstart = false;
            SceneManager.LoadScene("gameover");
        }
    }

    void OnMouseOver()
    {
        if (timeline1.state != PlayState.Playing)
        {
            //Debug.Log("The player is looking at " + transform.name);
            text.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                vcam5.m_Priority = 18;
                timeline1.Play();
                text.SetActive(false);
                badguy.SetActive(true);
                playstart = true;
            }
        }
    }

    void OnMouseExit()
    {
        text.SetActive(false);
    }
}
