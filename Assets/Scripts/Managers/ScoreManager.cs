using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static UnityAction<int> OnUpdateScore;

    public static int Score { get { return score; } set { score = value; OnUpdateScore.Invoke(score); } }
    private static int score = 0;


    void Awake ()
    {
        score = 0;
    }
}
