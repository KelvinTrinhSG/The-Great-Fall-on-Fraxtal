using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GamePolygon;
using Thirdweb;
public class MenuManager : MonoBehaviour {


	public Text CurrentLevelText;
   

    int CurrentLevel;
	

	// Use this for initialization
	void Start () {
        // SoundManager.Instance.StopMusic();

        // SoundManager.Instance.PlayMusic(SoundManager.Instance.Menu);
        CurrentLevel = PlayerPrefs.GetInt("Level", 1);
        CurrentLevelText.text = "LEVEL " + CurrentLevel;        
	}

	public void LoadLevel(){
		SceneManager.LoadScene ("Game");
	}

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

   



}
