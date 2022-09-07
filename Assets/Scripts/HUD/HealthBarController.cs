using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
  private Image m_HealthBar;
  private Text m_HealthText;

  private float m_MaxHealth = 100f;
  [SerializeField] public GameObject m_HealthValueObject;


  public void Start() {
    m_HealthBar = GetComponent<Image>();
    m_HealthText = m_HealthValueObject.GetComponent<Text>();
  }

  public void SetMaxHealth(float health) {
    m_HealthBar.fillAmount = m_MaxHealth;
  }

  public void UpdateHealth(float health) {
  
    m_HealthBar.fillAmount = health / m_MaxHealth;
    float healthRatio = m_HealthBar.fillAmount;
    m_HealthText.text = (healthRatio * 100).ToString() + "%";

    if (healthRatio >= 0.75f) {
      m_HealthBar.color = Color.green;
    } else if (healthRatio >= 0.50f && healthRatio < 0.75f) {
      m_HealthBar.color = Color.yellow;
    } else if (healthRatio >= 0.25f && healthRatio < 0.50f) {
      m_HealthBar.color = new Color(1.00f, 0.65f, 0.00f); // Orange
    } else if (healthRatio < 0.25f) {
      m_HealthBar.color = Color.red;
    }
  }
}