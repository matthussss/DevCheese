using UnityEngine;
// Dont forget to import this to access UI API!
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    // Component that is responsible for our Score Text
    public Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Accessing the Text Component we made awhile ago, and initializing it here
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Context Menu allows us to call this function in Unity!
    [ContextMenu("Increase Score")]
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
