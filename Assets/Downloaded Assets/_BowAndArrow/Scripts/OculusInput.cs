using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using OVR;

public class OculusInput : MonoBehaviour
{
    public Bow m_Bow;
    public GameObject m_OppositeController;
    public OVRInput.Controller m_Controller = OVRInput.Controller.None;
    public GameObject leftController;
    public Transform canvas;
    public Transform UIHelpers;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
            m_Bow.Pull(m_OppositeController.transform);

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, m_Controller))
            m_Bow.Release();

        if (OVRInput.GetDown(OVRInput.Button.Start) || Input.GetKeyDown(KeyCode.Escape))
            displayPauseMenu();

    }

    public void displayPauseMenu()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            UIHelpers.gameObject.SetActive(true);
        } else
        {
            canvas.gameObject.SetActive(false);
            UIHelpers.gameObject.SetActive(false);
        }
    }
}
