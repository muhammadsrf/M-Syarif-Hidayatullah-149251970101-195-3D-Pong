using UnityEngine;
using System.Collections;

public class BallControler : MonoBehaviour
{
    public Vector3 speed;
    public ScoreManager score;
    private Rigidbody rig;
    public GameObject Gawang1;
    public GameObject Gawang2;
    public GameObject Gawang3;
    public GameObject Gawang4;
    private Transform Bola;
    public ParticleSystem bomb;

    private void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        rig.velocity = speed;
        Bola = GetComponent<Transform>();
    }
    
    private void Update()
    {
        // Untuk mengunci bola agar tidak melayang atau tenggelam saat sedang berada dalam Arena
        if (Bola.position.y >= 0.05f)
        {
            Bola.position = new Vector3(Bola.position.x, Bola.position.y - (3f*Time.deltaTime), Bola.position.z);
        } else if (Bola.position.y <= -0.05f)
        {
            Bola.position = new Vector3(Bola.position.x, Bola.position.y + (3f*Time.deltaTime), Bola.position.z);
        }

        // Untuk mengatur posisi Efek Bola
        bomb.transform.position = gameObject.transform.position;
    }


    /// <summary>
    /// Fungsi ini digunakan untuk membuat event saat bola bertumbukan dengan lapangan, paddle, dan bola lain
    /// </summary>
    /// <param name="Collision bola terhadap lapangan, paddle, dan bola lain"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("lapangan"))
        {
            // Untuk meredam bola agar tidak memantul saat bergesekan dengan lapangan
            rig.velocity = new Vector3(rig.velocity.x, 0f, rig.velocity.z);
        } else if (other.gameObject.CompareTag("Paddle"))
        {
            AudioManager.instance.Tek();
        } else if (other.gameObject.CompareTag("Ball"))
        {
            AudioManager.instance.Nabrak();
        }
    }

    /// <summary>
    /// Fungsi ini digunakan untuk membuat event saat bola mengenai trigger dari Gawang (Garis Arena) Player.
    /// </summary>
    /// <param name="Trigger bola terhadap Garis Arena"></param>
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == Gawang1)
        {
            AudioManager.instance.Goal();
            score.AddPlayer1Score(1);
            bomb.Play();
            gameObject.SetActive(false);
        } else if(other.gameObject == Gawang2)
        {
            AudioManager.instance.Goal();
            score.AddPlayer2Score(1);
            bomb.Play();
            gameObject.SetActive(false);
        } else if(other.gameObject == Gawang3)
        {
            AudioManager.instance.Goal();
            score.AddPlayer3Score(1);
            bomb.Play();
            gameObject.SetActive(false);
        } else if(other.gameObject == Gawang4)
        {
            AudioManager.instance.Goal();
            score.AddPlayer4Score(1);
            bomb.Play();
            gameObject.SetActive(false);
        }
    }
}
