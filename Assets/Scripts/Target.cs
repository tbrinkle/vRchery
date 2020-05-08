using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public  delegate void TargetHit(GameObject target);
    public static TargetHit OnTargetHit;
    
    public void Damage(int amount)
    {
        OnTargetHit.Invoke(gameObject);
        if (gameObject.tag == "Target")
        {
            TurnRed();
            Destroy(gameObject, 0.5f);
        }
    }

    private void TurnRed()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
