using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameManagers manager;
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;
    public int maxScore = 15;

    public void AddPlayer1Score(int increment)
    {
        player1Score += increment;
        if (player1Score == 15)
        {
            manager.jumlahPemain -= 1;
            manager.EliminasiPlayer(1);
        }
    }

    public void AddPlayer2Score(int increment)
    {
        player2Score += increment;
        if (player2Score == 15)
        {
            manager.jumlahPemain -= 1;
            manager.EliminasiPlayer(2);
        }
    }

    public void AddPlayer3Score(int increment)
    {
        player3Score += increment;
        if (player3Score == 15)
        {
            manager.jumlahPemain -= 1;
            manager.EliminasiPlayer(3);
        }
    }

    public void AddPlayer4Score(int increment)
    {
        player4Score += increment;
        if (player4Score == 15)
        {
            manager.jumlahPemain -= 1;
            manager.EliminasiPlayer(4);
        }
    }
}
