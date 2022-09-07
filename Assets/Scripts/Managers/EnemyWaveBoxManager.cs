//using UnityEngine;
//using System;
//using System.Collections.Generic;

//[Serializable]
//public class EnemyWaveBoxManager {
//  public Transform[] m_SpawnPoints;
//  [HideInInspector] public GameObject[] m_Instances;
//  private EnemyWaveBoxController[] m_EnemyWaveBoxControllers;

//  void Start() {}
//  void Update() {}

//  public void Setup(GameObject[] instances) {
//   // assignManagerInstances(instances);
//   // loadControllerAssets();
//    // Debug.Log("EnemyWaveBoxManager Setup : Complete");
//  }

//  private void assignManagerInstances(GameObject[] instances) {
//    m_Instances = instances;

//    int index = 0;
//    int instanceCount = m_Instances.Length;
 
//    List<EnemyWaveBoxController> newControllers = new List<EnemyWaveBoxController>();
//    EnemyWaveBoxController controllerCreated = null;

//    while (index < instanceCount) {
//      controllerCreated = m_Instances[index++].GetComponent<EnemyWaveBoxController>() as EnemyWaveBoxController;
//      newControllers.Add(controllerCreated);
//    }
//    m_EnemyWaveBoxControllers = newControllers.ToArray();
//   // Debug.Log("EnemyWaveBoxManager: Assigned Manager Instances");
//  }
  
//  private void loadControllerAssets() {
//    //int index = 0;
//    //int controllerCount = m_EnemyWaveBoxControllers.Length;
//    //EnemyWaveBoxController currentController = null;
//    //while (index < controllerCount) {
//    //  currentController = m_EnemyWaveBoxControllers[index++];
//    //  currentController.LoadObjects();
//    //}
//  //  Debug.Log("EnemyWaveBoxManager: Loaded Controller Assets");
//  }
  
//}
