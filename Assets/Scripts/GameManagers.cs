using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public GameObject containerGameOver;
    public BallManager manajerBola;
    public PaddleController PaddlePlayer1;
    public PaddleController PaddlePlayer2;
    public PaddleController PaddlePlayer3;
    public PaddleController PaddlePlayer4;
    public string Pemenang;
    public int jumlahPemain = 4;
    private bool P1 = true;
    private bool P2 = true;
    private bool P3 = true;
    private bool P4 = true;

    private void Start() {
        GameStart();
    }

    public void GameStart()
    {
        manajerBola.MulaiSpawnBall();
    }

    public void GameRestart()
    {
        containerGameOver.SetActive(false);
        GameStart();
    }

    public void GameOver()
    {
        manajerBola.StopSpawnBall();
        containerGameOver.SetActive(true);
    }

    public void EliminasiPlayer(int player)
    {
        switch (player)
        {
            case 1:
            PaddlePlayer1.BecomeWall();
            P1 = false;
            WinnerCheck();
            break;

            case 2:
            PaddlePlayer2.BecomeWall();
            P2 = false;
            WinnerCheck();
            break;

            case 3:
            PaddlePlayer3.BecomeWall();
            P3 = false;
            WinnerCheck();
            break;

            case 4:
            PaddlePlayer4.BecomeWall();
            P4 = false;
            WinnerCheck();
            break;
        }
    }

    private void WinnerCheck()
    {
        if (jumlahPemain > 1) return;
        if (P1)
        {
            Pemenang = "Player 1";
            GameOver();
        } else if (P2)
        {
            Pemenang = "Player 2";
            GameOver();
        } else if (P3)
        {
            Pemenang = "Player 3";
            GameOver();
        } else if (P4)
        {
            Pemenang = "Player 4";
            GameOver();
        }
    }
}
