using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject m_TargetPrefab;
    public GameObject ourCameraRig;
    public GameObject gameModes;
    public GameObject scoreObject;

    public delegate void GameOver();
    public static GameOver OnGameOver;

    private int score = 0;
    private int targets;
    private float time;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI remaining;
    public TextMeshProUGUI scoreNum;


    private void Update()
    {
        if (time <= 0)
        {
            StartCoroutine(ClearGame());
            scoreObject.SetActive(true);
            scoreNum.SetText(score.ToString());
            gameModes.SetActive(true);
            OnGameOver.Invoke();
        }
        else
        {
            time -= Time.deltaTime;
            timer.SetText(((int)time).ToString());
        }        
    }

    private IEnumerator ClearGame()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject t in targets)
        {
            Destroy(t);
        }

        yield return null;
    }

    private Vector3 CheckLocation(Vector3 loc, int maxRange)
    {
        Vector3 newLoc = loc;
        while (newLoc.x < 10 && newLoc.x > -10 &&  newLoc.y < 10 && newLoc.y > -10)
        {
            newLoc = new Vector3(Random.Range(-maxRange, maxRange), Random.Range(-5, 20), Random.Range(-maxRange, maxRange));
        }

        return newLoc;
    }

    private IEnumerator SetupGame(int targets, float time, int maxRange)
    {
        gameModes.SetActive(false);
        scoreObject.SetActive(false);
        score = 0;

        for (int i = 0; i < targets; i++)
        {
            Vector3 loc = new Vector3(Random.Range(-maxRange,maxRange), Random.Range(-5, 20), Random.Range(-maxRange, maxRange));
            GameObject newTarget = Instantiate(m_TargetPrefab, CheckLocation(loc, maxRange), Quaternion.identity);
            newTarget.transform.LookAt(ourCameraRig.transform);
            newTarget.transform.Rotate(0, 47, 0);
        }

        remaining.SetText(targets.ToString());
        timer.SetText(time.ToString());

        yield return null;
    }

    public void Easy()
    {
        targets = 10;
        time = 31.0f;
        int maxR = 20;

        StartCoroutine(SetupGame(targets, time, maxR));
    }

    public void Medium()
    {
        targets = 20;
        time = 46.0f;
        int maxR = 35;

        StartCoroutine(SetupGame(targets, time, maxR));
    }

    public void Hard()
    {
        targets = 30;
        time = 61.0f;
        int maxR = 50;

        StartCoroutine(SetupGame(targets, time, maxR));
    }

    private void TargetHit(GameObject hit)
    {
        if (hit.tag == "Easy")
        {
            Easy();
        }
        else if (hit.tag == "Medium")
        {
            Medium();
        }
        else if (hit.tag == "Hard")
        {
            Hard();
        }
        else
        {
            int distance = (int)Vector3.Distance(Vector3.zero, hit.transform.position);

            score += distance / 10;
            targets -= 1;

            remaining.SetText(targets.ToString());
        }
    }

    private void OnEnable()
    {
        Target.OnTargetHit += TargetHit;
    }

    private void OnDisable()
    {
        Target.OnTargetHit -= TargetHit;
    }
}
