using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private TMP_Text textoPontuacao;

    void Start()
    {
        textoPontuacao = GetComponent<TMP_Text>();
        score = PlayerPrefs.GetInt("score", 0);
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        PlayerPrefs.SetInt("score", score);
        UpdateScoreText();
    }

    public int GetPoints()
    {
        return score;
    }

    public void Reset()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = score.ToString();
        }
    }
}
