using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(StartMenu());
    }

    IEnumerator StartMenu() {
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("Menu");
    }
}
