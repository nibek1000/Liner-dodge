using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public GameObject[] przeszkody;
    public GameObject placeToSpawn;
    public GameObject CameraM;
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
        Instantiate(przeszkody[Random.Range(0, 10)], placeToSpawn.transform);
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
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + ScoreInt);
        Time.timeScale = 1.0f;
        Application.LoadLevel(0);
    }

    public void Play()
    {
        Menu.SetActive(false);
        PlayGame = true;
        CameraM.GetComponent<Animator>().SetBool("bool", true);
        StartCoroutine(ScoreGaining());
        StartCoroutine(MakeHarder());
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

    IEnumerator MakeHarder()
    {
        yield return new WaitForSeconds(6);
        Time.timeScale = Time.timeScale + 0.02f;
        StartCoroutine(MakeHarder());
    }
}
