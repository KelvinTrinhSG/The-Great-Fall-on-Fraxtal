using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePolygon;
using UnityEngine.UI;

public class CoinUpdate : MonoBehaviour
{
    public Text TotalCoins;
    // Start is called before the first frame update
    void Start()
    {
        TotalCoins.text = CoinManager.Instance.Coins.ToString();

    }
    private void Update()
    {
        TotalCoins.text = CoinManager.Instance.Coins.ToString();

    }


}
