using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {
  private Text m_ScoreText = null;

  [SerializeField] public GameObject m_ScoreValueObject;
  private ScoreController m_ScoreTracker;

  void Start() {
    m_ScoreText = m_ScoreValueObject.GetComponent<Text>();
    m_ScoreTracker = gameObject.GetComponent<ScoreController>();
  }

  void updateScore() {
    m_ScoreText.text = m_ScoreTracker.IncrementScore().ToString();
  }

  void LateUpdate() {
    if (m_ScoreTracker.ScoreIsUpdatable() && m_ScoreText) {
      updateScore();
    }
  }

}
