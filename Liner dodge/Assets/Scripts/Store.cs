using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public int current;
    public int[] prices;
    public Sprite[] skins;
    public int coins;
    public GameObject player;
    public GameObject BuyButton;
    public GameObject StartGameButton;
    public Text PriceText;
    public Text TotalCoins;
    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("i0", 1);
        BoughtChecker();
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<SpriteRenderer>().sprite = skins[current];
        if (PlayerPrefs.GetInt("i" + current) != 1)
        {
            StartGameButton.SetActive(false);
            PriceText.gameObject.SetActive(true);
        }
        else
        {
            StartGameButton.SetActive(true);
            PriceText.gameObject.SetActive(false);
        }
        PriceText.text = "Price: " + prices[current];
        TotalCoins.text = "" + PlayerPrefs.GetInt("coins");
    }

    public void Next()
    {
        if(current == 9)
        {
            current = 0;
        }
        else
        {
            current++;
        }
        BoughtChecker();
    }

    public void Prev()
    {
        if (current == 0)
        {
            current = 9;
        }
        else
        {
            current--;
        }
        BoughtChecker();
    }


    void BoughtChecker()
    {
        if(PlayerPrefs.GetInt("i" + current) == 1)
        {
            BuyButton.SetActive(false);
        }
        else
        {
            BuyButton.SetActive(true);
        }
    }

    public void BuyThis()
    {
        if (PlayerPrefs.GetInt("i" + current) == 0)
        {
            if(prices[current] <= coins)
            {
                coins = coins - prices[current];
                PlayerPrefs.SetInt("i" + current, 1);
                BuyButton.SetActive(false);
            }
        }
    }
}
