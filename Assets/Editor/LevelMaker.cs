using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{

	public GameObject[] Tracks;
	public Transform StartLine;
	public GameObject EndTrack;

    // Start is called before the first frame update
    void Start()
    {
		
		int RandomLength = Random.Range (3, 9);

		for(int i =0; i<=RandomLength;i++){
			if (i < RandomLength) {
				int RandomBlock = Random.Range (0, Tracks.Length);
				GameObject Track = Instantiate (Tracks [RandomBlock], StartLine.position, transform.rotation);
				StartLine = Track.transform.GetChild (1).transform;
			} else {
				Instantiate (EndTrack, StartLine.position, transform.rotation);
			
			}
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
