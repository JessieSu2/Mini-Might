using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerManager
{
    public Transform m_SpawnPoint;
    [HideInInspector] public GameObject m_Instance; // Instance of the player

    private PlayerMovement m_Movement;
    private PlayerShooting m_Shooting;
    private GameObject m_CanvasGameObject; // controls when we enable/disable UI

    //Setup is called before the build process.
    public void Setup()
	{
        m_Movement = m_Instance.GetComponent<PlayerMovement>();
        m_Shooting = m_Instance.GetComponent<PlayerShooting>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject; // Gets Canvas object of instance, which is our UI
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
