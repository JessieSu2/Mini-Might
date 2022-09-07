using UnityEngine;

public class GameManager : MonoBehaviour {
    // 'm_' stands for member variable; you can use these variables in any function in this class
    public PlayerManager m_Player;

    public HUDController m_GameHUD;

    public GameObject m_PlayerPrefab;
    public GameObject m_Enemy1Prefab;
    public GameObject m_Enemy2Prefab;

/*    public GameOver m_GameOver;
    public EnemyManager[] m_Enemies;*/

    [SerializeField] bool m_GameHasEnded = false;

   void Start() {
      m_GameHasEnded = false;
     /* m_GameOver.ShowGameOver(m_GameHasEnded);*/
      LoadUI();
      StartGame();
    }

    private void StartGame() {
      SpawnPlayer();
      SpawnEnemies();
    }

    public void EndGame() {
      if (!m_GameHasEnded) {
        m_GameHasEnded = true;
        Debug.Log("GAME OVER - TRIGGERED");
/*        m_GameOver.ShowGameOver(m_GameHasEnded);*/
      }
    }
    private void SpawnPlayer(){
        m_Player.m_Instance = Instantiate(m_PlayerPrefab, m_Player.m_SpawnPoint.position, m_Player.m_SpawnPoint.rotation) as GameObject;
        m_Player.Setup();
    }
    void Update(){}
    private void SpawnEnemies()
    {
       /* for (int i = 0; i < m_Enemies.Length; i++)
        {
            switch (m_Enemies[i].m_EnemyType)
			{
                case 1:
                    m_Enemies[i].m_Instance = Instantiate(m_Enemy1Prefab, m_Enemies[i].m_SpawnPoint.position, m_Enemies[i].m_SpawnPoint.rotation) as GameObject;
                    m_Enemies[i].Setup(m_Enemies[i].m_EnemyType);
                    break;

                case 2:
                    m_Enemies[i].m_Instance = Instantiate(m_Enemy2Prefab, m_Enemies[i].m_SpawnPoint.position, m_Enemies[i].m_SpawnPoint.rotation) as GameObject;
                    m_Enemies[i].Setup(m_Enemies[i].m_EnemyType);
                    break;

                default:
                    m_Enemies[i].m_Instance = Instantiate(m_Enemy1Prefab, m_Enemies[i].m_SpawnPoint.position, m_Enemies[i].m_SpawnPoint.rotation) as GameObject;
                    m_Enemies[i].Setup(m_Enemies[i].m_EnemyType);
                    break;

			}
        }*/
        
        //for (int i = 0; i < m_Enemy1.Length; i++){
        //    m_Enemy1[i].m_Instance = Instantiate(m_Enemy1Prefab, m_Enemy1[i].m_SpawnPoint.position, m_Enemy1[i].m_SpawnPoint.rotation) as GameObject;
        //    m_Enemy1[i].Setup(1);
        //}

    }

    private void LoadUI() {
      m_GameHUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDController>();
    }
}
