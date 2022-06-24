using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject[] spawnBall;
    [SerializeField] private Vector3[] posSpawnBall;
    public GameObject[] Ball;
    public float spawnInterval; 
    private float timer;
    private bool spawnTime;
    private bool GameOver;

    public void MulaiSpawnBall()
    {
        for(int i = 0; i <= 4; i++)
        {
            posSpawnBall[i] = new Vector3(spawnBall[i].transform.position.x, spawnBall[i].transform.position.y, spawnBall[i].transform.position.z);
        }
        
        timer = 0;
        GameOver = false;
        ActivateNewBall();
    }

    public void StopSpawnBall()
    {
        GameOver = true;
        for(int i = 0; i <= 4; i++)
        {
            Ball[i].SetActive(false);
        }
    }

    private void Update() {
        if (GameOver) return;
        timer += Time.deltaTime; 

        if (timer > spawnInterval) 
        { 
            ActivateNewBall(); 
            timer -= spawnInterval;
        } 
    }

    private void ActivateNewBall()
    {
        spawnTime = true;
        for(int i = 0; i <= 4; i++)
        {
            ActivateNewBall(i);
            if(!spawnTime)
            {
                break;
            }
        }
    }

    public void ActivateNewBall(int index)
    {
        if(!Ball[index].activeSelf)
        {
            Ball[index].GetComponent<Transform>().position = posSpawnBall[index];
            Ball[index].SetActive(true);
            spawnTime = false;
        }

    }
}
