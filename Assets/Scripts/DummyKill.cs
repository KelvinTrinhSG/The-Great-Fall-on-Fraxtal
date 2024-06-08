using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyKill : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillAfter());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator KillAfter() {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
