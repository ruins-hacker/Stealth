using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    private GameObject[] sirens;
    public bool alertOn = false;
    public Vector3 lastPlayerPosition = Vector3.zero;
    public static GM shared;
    public AudioSource musicPanic;
    public AudioSource musicNormal;
    public GameObject panel;
    // Start is called before the first frame update

    private void Awake()
    {
        shared = this;
    }
    void Start()
    {
        musicNormal.volume = 0.4f;
        musicPanic.volume = 0;
        sirens = GameObject.FindGameObjectsWithTag(Tags.siren);
    }

    // Update is called once per frame
    void Update()
    {
        if(alertOn)
        {
            playAlert();
            AlertLight.shared.alertOn = true;
            musicNormal.volume = Mathf.Lerp(musicNormal.volume, 0, Time.deltaTime);
            musicPanic.volume = Mathf.Lerp(musicPanic.volume, 0.4f, Time.deltaTime);
        } else
        {
            stopAlert();
            AlertLight.shared.alertOn = false;
            musicNormal.volume = Mathf.Lerp(musicNormal.volume, 0.4f, Time.deltaTime);
            musicPanic.volume = Mathf.Lerp(musicPanic.volume, 0, Time.deltaTime);
        }
    }

    public void playAlert()
    {
        foreach(var siren in sirens)
        {
            var audio = siren.GetComponent<AudioSource>();
            if(!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }

    public void stopAlert()
    {
        foreach (var siren in sirens)
        {
            var audio = siren.GetComponent<AudioSource>();
            audio.Stop();
        }

    }

    public static void WinGame()
    {
        //Time.timeScale = 0;
        GM.shared.panel.SetActive(true);
    }

    public void startGame()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(0);
        //Time.timeScale = 1;
    }


}
