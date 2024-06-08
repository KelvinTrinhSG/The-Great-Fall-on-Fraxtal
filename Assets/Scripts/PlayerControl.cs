using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeautifulTransitions.Scripts.Transitions;
using MoreMountains.Feedbacks;


public class PlayerControl : MonoBehaviour
{
    new Rigidbody rigidbody;
    Transform Spawn;
    public GameObject LeftStick, RightStick, stickMan;
    public MMFeedbacks text;
     Animator anim;
    public GameObject[] Players;
    public GameObject SelectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        int PlayerPos = (PlayerPrefs.GetInt("CURRENT_CHARACTER", 0));
        Players[PlayerPos].SetActive(true);
        SelectedPlayer = Players[PlayerPos];
        anim = SelectedPlayer.GetComponent<Animator>();
        Spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        gameObject.transform.position = Spawn.position;
        string spawnPointName = Spawn.name;
        TransitionHelper.TransitionIn(LeftStick);
        TransitionHelper.TransitionIn(RightStick);
        TransitionHelper.TransitionIn(stickMan);
        anim.SetBool("Down", true);
        rigidbody.drag = 50;
        rigidbody.sleepThreshold = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.GameEnd && !GameManager.instance.GameEndWin)
        {
            rigidbody.WakeUp();

            if (Input.GetMouseButtonDown(0))
            {
                TransitionHelper.TransitionIn(LeftStick);
                TransitionHelper.TransitionIn(RightStick);
                TransitionHelper.TransitionIn(stickMan);
                text?.PlayFeedbacks();

                anim.SetBool("Down", true);

                rigidbody.drag = 50;
                rigidbody.WakeUp();

            }
            if (Input.GetMouseButtonUp(0))
            {
                rigidbody.drag = 0f;

                TransitionHelper.TransitionOut(LeftStick);
                TransitionHelper.TransitionOut(RightStick);
                TransitionHelper.TransitionOut(stickMan);
                anim.SetBool("Down", false);
                rigidbody.WakeUp();


            }

        }
        else if (GameManager.instance.GameEndWin)
        {
            rigidbody.drag = 50f;
            rigidbody.WakeUp();
        }
        else {
            rigidbody.drag = 0f;
            rigidbody.WakeUp();
        }

    }

    IEnumerator waitforstart() {
        yield return new WaitForSeconds(2f);
        rigidbody.drag = 0f;
        TransitionHelper.TransitionOut(LeftStick);
        TransitionHelper.TransitionOut(RightStick);
        TransitionHelper.TransitionOut(stickMan);
        anim.SetBool("Down", false);
        rigidbody.WakeUp();
    }
}
