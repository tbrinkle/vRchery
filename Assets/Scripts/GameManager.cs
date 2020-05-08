using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject m_TargetPrefab;
    public GameObject ourCameraRig;
    public GameObject gameModes;

    public delegate void GameOver();
    public static GameOver OnGameOver;

    private int score = 0;
    private int targets;
    private float time;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI remaining;


    private void Update()
    {
        time -= Time.deltaTime;
        timer.SetText(time.ToString());
        if (time <= 0)
        {
            timer.SetText(score.ToString());
            OnGameOver.Invoke();
        }
    }

    private IEnumerator SetupGame(int targets, float time, int maxRange)
    {
        for (int i = 0; i < targets; i++)
        {
            Vector3 loc = new Vector3(Random.Range(-maxRange, maxRange), Random.Range(-5, 10), Random.Range(-maxRange, maxRange));
            GameObject newTarget = Instantiate(m_TargetPrefab, loc, Quaternion.identity);
            newTarget.transform.LookAt(ourCameraRig.transform);
        }

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
            gameModes.SetActive(false);
            Easy();
        }
        else if (hit.tag == "Medium")
        {
            gameModes.SetActive(false);
            Medium();
        }
        else if (hit.tag == "Hard")
        {
            gameModes.SetActive(false);
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
