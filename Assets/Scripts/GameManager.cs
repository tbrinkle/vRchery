using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject m_TargetPrefab;

    private int score = 0;
    public int targets;

    private void Awake()
    {
        StartCoroutine(SetupGame());
    }

    private IEnumerator SetupGame()
    {
        for (int i = 0; i < targets; i++)
        {
            Vector3 loc = new Vector3(Random.Range(-30, 30), Random.Range(-5, 10), Random.Range(-30, 30));
            Instantiate(m_TargetPrefab, loc, Quaternion.identity);
        }

        yield return null;
    }

    private void TargetHit()
    {
        score += 1;
        targets -= 1;
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
