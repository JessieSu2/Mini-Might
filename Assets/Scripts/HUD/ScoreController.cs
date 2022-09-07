using System;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    private int m_ScoreValue = 0;
    private int m_ScoreIncrement = 0;

    private int m_HighScore = 0;
    private Boolean m_ScoreCanUpdate;
  
    // Start is called before the first frame update
    void Start() {
      m_ScoreValue = 0;
      m_ScoreIncrement = 1;
      m_HighScore = Int32.MinValue;
     
      m_ScoreCanUpdate = true;
    }

    // Update is called once per frame
    void Update(){}
    
    // Update Score and high score, then return updatedScore
    public int IncrementScore() {
      if (!m_ScoreCanUpdate) {
        return m_ScoreValue;
      }

      int newScore = m_ScoreValue + m_ScoreIncrement;
      m_ScoreValue = newScore > 0 ? newScore : 0;
  
      if (m_ScoreValue > m_HighScore) {
        m_HighScore = m_ScoreValue;
      }
      return m_ScoreValue;
    }

    public int GetHighScore() {
      return m_HighScore;
    }
    
    public void DisableScoreUpdate() {
      m_ScoreCanUpdate = false;
    }

    public Boolean ScoreIsUpdatable() {
      return m_ScoreCanUpdate;
    }
}
