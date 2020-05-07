using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVRKB : MonoBehaviour
{
    public GameObject VRKB;

    void Start(){
         VRKB.SetActive(false);
    }

    public void toggleVisibility() {
        VRKB.SetActive(!VRKB.activeSelf);
    }

}
