using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject[] przeszkody;
    public GameObject placeToSpawn;

    public Text Score;
    public Text ScoreOnScreen;
    public Text BestScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        if(PlayGame == true)
        {
        Instantiate(przeszkody[Random.Range(0, 7)], placeToSpawn.transform);
        }


        yield return new WaitForSeconds(6);
        StartCoroutine(Spawning());
    }


    public int ScoreInt;
    public float ScoreSpeed;
    private void Update()
    {
        ScoreOnScreen.text = ScoreInt + "";

        foreach(GameObject gm in GameObject.FindGameObjectsWithTag("prz"))
        {
            gm.transform.parent = null;
        }

        if(GameObject.FindGameObjectWithTag("go").transform.position == GameObject.FindGameObjectWithTag("zz").transform.position)
        {
            PlayGame = false;
            Score.text = "Your score: " + ScoreInt;
            if(ScoreInt >= PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", ScoreInt);
            }
            BestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore");
        }

        
    }


    public GameObject Menu;
    public bool PlayGame = false;

    public void PlayAgain()
    {
        Application.LoadLevel(0);
    }

    public void Play()
    {
        Menu.SetActive(false);
        PlayGame = true;
        StartCoroutine(ScoreGaining());
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator ScoreGaining()
    {
        yield return new WaitForSeconds(1);
        if (PlayGame == true)
        {
            ScoreInt ++;
        }
        StartCoroutine(ScoreGaining());
    }
}
