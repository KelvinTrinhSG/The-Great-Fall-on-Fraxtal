using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using GamePolygon;
using Thirdweb;

public class GameManager : MonoBehaviour
{
    int CurrentLevel;
    public static GameManager instance;
    public GameObject GameOverUI, Blast;
    public Text currentText, nextText;
    [HideInInspector]
    public bool GameEnd, GameEndWin;
    public GameObject ActiveBody, Deadbody, pole;
    public MMFeedbacks GameOverFeedBack;


    public GameObject[] Level;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        Instantiate(Level[CurrentLevel]);
    }

    private void Start()
    {
        GameEnd = false;
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Game);
        currentText.text = "" + (CurrentLevel);
        nextText.text = "" + (CurrentLevel + 1);


    }

    public void GameWin()
    {
        GameEndWin = true;
        StartCoroutine(ShowGameWin());

    }

    public void GameOver()
    {
       
        GameOverFeedBack.PlayFeedbacks();
        ActiveBody.SetActive(false);
        Deadbody.SetActive(true);
        pole.SetActive(false);
        GameEnd = true;
        StartCoroutine(ShowGameOver());


    }

    IEnumerator ShowGameWin()
    {
        Blast.SetActive(true);
        PlayerPrefs.SetInt("Level", CurrentLevel + 1);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameWin");
    }

    IEnumerator ShowGameOver()
    {
        SoundManager.Instance.StopMusic();

        SoundManager.Instance.PlaySound(SoundManager.Instance.GameOverFx);

        yield return new WaitForSeconds(2.0f);
        Debug.Log("GameOVer");
        GameOverUI.SetActive(true);

    }

    public Button ReloadBtn;
    public Text ReloadBtnText;

    public Button MainMenuBtn;
    public async void ClaimERC20TokenReplayLevel()
    {
        ReloadBtn.interactable = false;
        MainMenuBtn.interactable = false;
        ReloadBtnText.text = "Claiming...";
        Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x8CAb783204443046E456BECaF01c44B3a600bbe8");
        var data = await contract.ERC20.Claim("1");
        Debug.Log("Tokens were claimed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ReloadBtnText.text = "Retry";
        ReloadBtn.interactable = true;
        MainMenuBtn.interactable = true;
    }

    public void Reload()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ClaimERC20TokenReplayLevel();
    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
}
