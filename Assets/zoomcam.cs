using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class zoomcam : MonoBehaviour
{
    public bool zoomedin = true;
    public bool paused = false;
    public bool inmainmenu = false;
    public CinemachineVirtualCamera vcam;
    public AudioSource audioSource;
    public GameObject cam1;
    public GameObject screen;
    public GameObject text;
    public GameObject cam2;
    public GameObject text2;
    public GameObject terrain;
    public GameObject pausetext1;
    public GameObject pausetext2;
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (inmainmenu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && zoomedin)
        {
            vcam.m_Priority = 9;
            //Debug.Log("zoomed out");
            zoomedin = false;
        }
        else if (Input.GetMouseButtonDown(1) && zoomedin == false)
        {
            vcam.m_Priority = 10;
            //Debug.Log("zoomed in");
            zoomedin = true;
        }
        if (Input.GetKeyDown("1") && zoomedin)
        {
            cam1.SetActive(true);
            text.SetActive(true);
            screen.SetActive(false);
            cam2.SetActive(false);
            text2.SetActive(false);
            terrain.SetActive(true);
        }
        if (Input.GetKeyDown("2") && zoomedin)
        {
            cam1.SetActive(false);
            text.SetActive(false);
            screen.SetActive(false);
            cam2.SetActive(true);
            text2.SetActive(true);
            terrain.SetActive(true);
        }
        if (Input.GetKeyDown("b") && zoomedin)
        {
            cam1.SetActive(false);
            text.SetActive(false);
            screen.SetActive(true);
            cam2.SetActive(false);
            text2.SetActive(false);
            terrain.SetActive(false);
        }
        if (Input.GetKeyDown("escape") && paused == false)
        {
            //Debug.Log("paused");
            Time.timeScale = 0;
            pausetext1.SetActive(true);
            pausetext2.SetActive(true);
            paused = true;
        }
        if (Input.GetMouseButtonDown(0) && paused == true)
        {
            //Debug.Log("unpaused");
            Time.timeScale = 1;
            pausetext1.SetActive(false);
            pausetext2.SetActive(false);
            paused = false;
        }
        if (Input.GetKeyDown("q") && paused == true)
        {
            //Debug.Log("main menu");
            pausetext1.SetActive(false);
            pausetext2.SetActive(false);
            paused = false;            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            inmainmenu = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
