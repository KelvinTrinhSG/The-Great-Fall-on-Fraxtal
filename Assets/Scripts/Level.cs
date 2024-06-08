using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level : MonoBehaviour
{
    
    Transform StartLine;
    public int LevelNumber;
    [Header("Road")]
    public GameObject _StartBlock;
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public GameObject Block4;
    public GameObject Block5;

    public GameObject EndBlock;
    GameObject Empty;
    // Update is called once per frame
    public void StartBlock()
    {

        GameObject Track = Instantiate(_StartBlock) as GameObject;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);


    }

    public void block1()
    {


        GameObject Track = Instantiate(Block1) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void block2()
    {
        GameObject Track = Instantiate(Block2) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }


    public void block3()
    {
        GameObject Track = Instantiate(Block3) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }


    public void block4()
    {

        GameObject Track = Instantiate(Block4) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void block5()
    {

        GameObject Track = Instantiate(Block5) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }





    public void endblock()
    {
        GameObject Track = Instantiate(EndBlock) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void CreateLevelEmpty()
    {
        Empty = new GameObject("Level_" + LevelNumber);

    }
}
