﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class MenuSceneController : MonoBehaviour {
   
    public static int questionSelected;
  //  private AudioManager audio;
    PlayerProgress playerProgress;
    public Sprite forMusicButtonOn;
    public Sprite forMusicButtonOff;
   public  Button musicButton;

    private static int checkIfOneCLicked = 0;
    private static int isOn = 1;
    private void Start()
    {
  
      //  audio = GameObject.FindObjectOfType<AudioManager>();
        if (PlayerPrefs.HasKey("Music"))
        {
            if (musicButton)
            {
                if (PlayerPrefs.GetInt("Music") == 0)
                {
                    musicButton.image.sprite = forMusicButtonOff;
                }
                else
                {
                    musicButton.image.sprite = forMusicButtonOn;
                }
            }
        }
        
      
    }
    public void Leaderboard()
    {
       
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ElkhanResources.leaderboard_rekordlar);
        }
        else
        {
                Social.localUser.Authenticate((bool success) =>
                {

                });
        }
       


    }
    public void StartGame(int index)
    {

            AdManager.Instance.RequestInterstitial();

            questionSelected = index;
            SceneManager.LoadScene("Game");
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("QuestionSelection");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public  void TurnOffOnMusic()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
             //   audio.GetComponent<AudioSource>().UnPause();
                musicButton.image.sprite = forMusicButtonOn; 
                PlayerPrefs.SetInt("Music", 1);
            }
            else
            {
                musicButton.image.sprite = forMusicButtonOff;
             //   audio.GetComponent<AudioSource>().Pause();
                PlayerPrefs.SetInt("Music", 0);
            }
        }
        else
        {
           
            
                isOn = 0;
                PlayerPrefs.SetInt("Music", isOn);
                musicButton.image.sprite = forMusicButtonOff;
            //    audio.GetComponent<AudioSource>().Pause();
            
          
        }
    }
    public void GoToPlayStore()
    {
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Megame");
    }
    public void RateUs(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.elkhan.paytaxt");

    }
    private void Update(){
    	if(Input.GetKeyDown(KeyCode.Escape)){
    		if(SceneManager.GetActiveScene().name == "QuestionSelection"){
    			SceneManager.LoadScene("MenuScene");
    		}else{
    			Quit();
    		}

    	}

    }

}
