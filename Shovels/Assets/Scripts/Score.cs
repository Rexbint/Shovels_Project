using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    //conf params
    public TextMeshProUGUI shovelText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI findCoinText;

    //state 
    public double CurCoinCount = 10;
    public int CurShovCount = 30;
    public int CurBlockCount = 0;
    public double CoinFind = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Score>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        shovelText.text = CurShovCount.ToString();
        coinText.text = CurCoinCount.ToString();
    }

    public void SubShovels()
    {
        if (CurShovCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
            ResetGame();
        }
        CurShovCount--;
        shovelText.text = CurShovCount.ToString();
    }

    public void AddCoin()
    {
        CoinFind++;
        findCoinText.text = CoinFind.ToString();
        if(CoinFind == CurCoinCount)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
            ResetGame();
        }
    }    

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void CountBlocks()
    {
        CurBlockCount++;
    }

    public void SubCountBlocks()
    {
        if (CurShovCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
            ResetGame();
        }
        CurBlockCount--;
    }

    public double GetRandom()
    {
        double randomNumber =  (double)(1.0-(CoinFind / CurCoinCount));
        return randomNumber;
    }
}
