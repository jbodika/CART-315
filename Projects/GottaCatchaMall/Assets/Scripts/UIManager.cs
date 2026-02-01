using UnityEngine;

public class UIManager: MonoBehaviour
{
    public int score;

    public TMP_Text scoreText;

    public static UIManager S;


    void Awake()
    {
        S = this;
    }
        void Start()
    {
        scoreText.text = "ermmmm";
    }

    public void UpdateScore(int pointValue)
    {
        int _pointValue = pointValue;
        score += _pointValue;

        string scoreString = score.ToString();
        scoreText.text = scoreString;
    }
}
