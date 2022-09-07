//using UnityEngine;
//using System;

//[Serializable]
//public class CameraManager {

//  [SerializeField] public GameObject m_Instance;
//  private CameraController m_CameraController;
//  public Transform m_SpawnPoint;

//  void Start() {}
//  void Update() {}

//  public void setCameraPositon(float x, float y) {
//    Vector3 newPosition = m_Instance.transform.position;
//    newPosition.x = x;
//    newPosition.y = y;
//    m_Instance.transform.position = newPosition;
//  }
//    public void Setup() {
//    m_CameraController = m_Instance.GetComponent<CameraController>();
//    if (m_CameraController) {
//    } else {
//      Debug.Log("COULD NOT LOAD CAMERA OBJECTS");
//    }
//    m_Instance.transform.position = m_SpawnPoint.position;
//  }
//}
