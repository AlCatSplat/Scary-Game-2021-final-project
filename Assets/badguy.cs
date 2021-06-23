using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class badguy : MonoBehaviour
{
    public bool playstart = false;
    public GameObject text;
    public CinemachineVirtualCamera vcam6;
    public CinemachineVirtualCamera vcam7;
    public PlayableDirector timeline2;
    // Start is called before the first frame update
    void Start()
    {
        var vcam6 = GetComponent<CinemachineVirtualCamera>();
        var vcam7 = GetComponent<CinemachineVirtualCamera>();
        timeline2 = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeline2.state == PlayState.Paused && playstart)
        {
            //Debug.Log("Timeline finished playing");
            playstart = false;
            vcam6.m_Priority = 3;
            vcam7.m_Priority = 17;
        }
    }

    void OnMouseOver()
    {
        if (timeline2.state != PlayState.Playing)
        {
            //Debug.Log("The player is looking at " + transform.name);
            text.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                vcam6.m_Priority = 17;
                timeline2.Play();
                playstart = true;
                text.SetActive(false);          
            }
        }
    }

    void OnMouseExit()
    {
        text.SetActive(false);
    }
}
