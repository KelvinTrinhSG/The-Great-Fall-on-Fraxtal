using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GamePolygon;
using Thirdweb;

public class GameWinScene : MonoBehaviour
{

    public GameObject[] Players;
    GameObject SelectedPlayer;

    public Button saveLevel;
    public Text saveLevelText;

    public Button continueBtn;
    public Text continueBtnText;
    public Button shopBtn;


    public void Start()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(SoundManager.Instance.Menu);
        int PlayerPos = (PlayerPrefs.GetInt("CURRENT_CHARACTER", 0));
        Players[PlayerPos].SetActive(true);
        SelectedPlayer = Players[PlayerPos];
        saveLevel.interactable = true;
        saveLevelText.text = "Save Level";
        saveLevel.gameObject.SetActive(true);
        continueBtn.gameObject.SetActive(true);
        shopBtn.gameObject.SetActive(true);
    }

    public async void ClaimERC20TokenNextLevel()
    {
        continueBtn.interactable = false;
        saveLevel.interactable = false;
        shopBtn.interactable = false;
        continueBtnText.text = "Claiming...";
        Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x8CAb783204443046E456BECaF01c44B3a600bbe8");
        var data = await contract.ERC20.Claim("1");
        Debug.Log("Tokens were claimed");
        SceneManager.LoadScene("Game");
        continueBtnText.text = "Continue";
        continueBtn.interactable = true;
        saveLevel.interactable = true;
        shopBtn.interactable = true;
    }

    public void Next()
    {
        //SceneManager.LoadScene("Game");
        ClaimERC20TokenNextLevel();
    }

    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void Shop()
    {

        SceneManager.LoadScene("Shop");
    }

    public int ConvertFloatToInt(float input)
    {
        if (input < 2f)
        {
            return 1;
        }
        else if (input > 53f)
        {
            return 53;
        }
        else
        {
            return Mathf.RoundToInt(input);
        }
    }

    private int ConvertLevelToInt(float valueToConvert)
    {
        int result1 = ConvertFloatToInt(valueToConvert);
        return result1;
    }

    public async void SaveLevelForPlayer()
    {
        saveLevel.interactable = false;
        continueBtn.interactable = false;
        shopBtn.interactable = false;
        saveLevelText.text = "Saving...";
        string address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        Contract contract = ThirdwebManager.Instance.SDK.GetContract("0xF9AAdC693031246B3Cd8118eEfd16Dc82dF5906a");
        var data = await contract.ERC20.BalanceOf(address);
        int blockchainLevel = ConvertLevelToInt(float.Parse(data.displayValue));
        int CurrentLevel = PlayerPrefs.GetInt("Level", 1);
        if (blockchainLevel < CurrentLevel+1)
        {
            int levelAdded = CurrentLevel + 1 - blockchainLevel;
            var data1 = await contract.ERC20.Claim(levelAdded.ToString());
            Debug.Log("Tokens were claimed");
            saveLevelText.text = PlayerPrefs.GetInt("Level", 1).ToString();
            continueBtn.interactable = true;
            shopBtn.interactable = true;
        }
        else {
            saveLevelText.text = PlayerPrefs.GetInt("Level", 1).ToString();
            continueBtn.interactable = true;
            shopBtn.interactable = true;
        }

    }
}
