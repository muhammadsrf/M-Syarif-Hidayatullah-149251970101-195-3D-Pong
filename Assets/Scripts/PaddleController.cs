using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Transform rig;
    public int speed;
    public bool atasBawahAtauKananKiri; 
    public KeyCode firstKey; 
    public KeyCode secondKey;
    private bool CanPlay;

    // saat player mati paddle diubah menjadi Wall dengan menggunakan parameter ini
    public Vector3 wallPosition;
    public Vector3 wallScale;

    private void Start() 
    { 
        CanPlay = true;
        rig = GetComponent<Transform>();
    } 
 
    private void Update() 
    { 
        // untuk menentukan player bisa main atau tidak
        if(!CanPlay) return;

        // get input 
        MoveObject(GetInput());
    }  

    private Vector3 GetInput() 
    { 
        if (atasBawahAtauKananKiri)
        {
            if (Input.GetKey(firstKey)) 
            { 
                return Vector3.back * speed;
            } 
            else if (Input.GetKey(secondKey)) 
            { 
                return Vector3.forward * speed;
            }
        } else if (!atasBawahAtauKananKiri)
        {
            if (Input.GetKey(firstKey)) 
            { 
                return Vector3.right * speed;
            } 
            else if (Input.GetKey(secondKey)) 
            { 
                return Vector3.left * speed;
            }
        } 
         
        return Vector3.zero; 
    } 
 
    private void MoveObject(Vector3 movement) 
    { 
        // Pergerakan Paddle dikali delta time
        rig.transform.position = new Vector3(transform.position.x + (movement.x * speed)*Time.deltaTime, transform.position.y + (movement.y * speed)*Time.deltaTime, transform.position.z + (movement.z*speed)*Time.deltaTime);
    } 

    public void BecomeWall()
    {
        CanPlay = false;
        gameObject.transform.position = wallPosition;
        gameObject.transform.localScale = wallScale;
    }
}
