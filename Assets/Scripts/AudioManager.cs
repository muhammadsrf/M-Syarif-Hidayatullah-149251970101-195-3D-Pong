using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    public AudioClip ketuk;
    public AudioClip goal;
    public AudioClip nabrak;
    public AudioClip tek;
    AudioSource audioSource;
    
    void Awake()
    {
        if (!instance)
        {
          instance = this;
          DontDestroyOnLoad(gameObject);
        }
        else
        {
          Destroy(gameObject);
        }
        
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Ketuk()
    {
        audioSource.PlayOneShot(ketuk, 0.7F);
    }

    public void Nabrak()
    {
        audioSource.PlayOneShot(nabrak, 0.7F);
    }

    public void Goal()
    {
        audioSource.PlayOneShot(goal, 0.7F);
    }
   
    public void Tek()
    {
        audioSource.PlayOneShot(tek, 0.7F);
    }
 }
