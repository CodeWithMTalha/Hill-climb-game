using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGM;

    [SerializeField] public GameObject restartBtn;
    [SerializeField] public GameObject bGPanel;
    [SerializeField] public TextMeshProUGUI coinsText;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip coinsClip;
    [SerializeField] public AudioClip fuelClip;

    [SerializeField] public Image musicOn;
    [SerializeField] public Image musicOff;
    [SerializeField] public Image soundOn;
    [SerializeField] public Image soundOff;

    public bool isMusic = true;
    public bool isSound = true;
    private void Awake()
    {
        if(instanceGM == null)
        {
            instanceGM = this;
        }
        Time.timeScale = 1f;

        musicOff.enabled = false;
        musicOn.enabled = true;

        soundOn.enabled = true;
        soundOff.enabled = false;
    }

    private void Start()
    {
        coinsText.text = "Coins " + PlayerPrefs.GetInt("coins");

        if (PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            LoadMusic();
        }
        else
        {
            LoadMusic();
        }
    }

    public void GameOver()
    {
        restartBtn.SetActive(true);
        bGPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void PlayAfterPauseGame()
    {
        Time.timeScale = 1f;
    }

    public void CountCoins()
    {
        int temp = 5;
        temp = temp + PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", temp);
        coinsText.text = "Coins "+ PlayerPrefs.GetInt("coins");
        audioSource.PlayOneShot(coinsClip);
    }

    public void MusicPlay()
    {
        if (isMusic)
        {
            musicOff.enabled = true;
            musicOn.enabled = false;
            audioSource.Stop();
            isMusic = false;
        }
        else
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
            audioSource.Play();
            isMusic = true;
        }
        SaveMusic();
    }
    public void SoundPlay()
    {
        if (isSound)
        {
            soundOff.enabled = true;
            soundOn.enabled = false;
           // audioSource.StopOneShot(coinsClip);
         
            isSound = false;
        }
        else
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
            audioSource.PlayOneShot(coinsClip);
            isSound = true;
        }
    }
    public void SaveMusic()
    {
        PlayerPrefs.SetInt("music", isMusic ? 1 : 0);
    }
    public void LoadMusic()
    {
         isMusic = PlayerPrefs.GetInt("music")==1;
    }
}
