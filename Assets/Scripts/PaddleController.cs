using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Transform pos;
    public int speed;
    public bool atasBawahAtauKananKiri; 
    public KeyCode firstKey; 
    public KeyCode secondKey;
    private bool CanPlay;

    // untuk mengaktifkan AI atau tidak
    public bool activationAI;
    public int[] speedAI;
    public Vector3 limitPos1;
    public Vector3 limitPos2;
    private Vector3 nowPos;
    private int turn;

    // saat player mati paddle diubah menjadi Wall dengan menggunakan parameter ini
    public Vector3 wallPosition;
    public Vector3 wallScale;

    private void Start() 
    { 
        CanPlay = true;
        pos = GetComponent<Transform>();
        turn = 0;
    } 
 
    private void Update() 
    { 
        // untuk menentukan player bisa main atau tidak
        if(!CanPlay) return;
        nowPos = transform.position; // cek posisi saat ini
        if(activationAI)
        {
            if(turn == 0)
            {
                Vector3 tempPos = (limitPos1-pos.position).normalized;
                pos.position = pos.position + new Vector3(tempPos.x * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime, tempPos.y * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime, tempPos.z * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime);
                if(Vector3.Distance(nowPos, limitPos1) <= 0.1f)
                {
                    turn = 1;
                }
            } else if (turn == 1)
            {
                Vector3 tempPos = (limitPos2-pos.position).normalized;
                pos.position = pos.position + new Vector3(tempPos.x * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime, tempPos.y * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime, tempPos.z * Random.Range(speedAI[0], speedAI[1]) * Time.deltaTime);
                if(Vector3.Distance(nowPos, limitPos2) <= 0.1f)
                {
                    turn = 0;
                }
             } 
        }
        else if(!activationAI)
        {
            // get input 
            MoveObject(GetInput());
        }
    }  

    private Vector3 GetInput() 
    { 
        if (atasBawahAtauKananKiri)
        {
            if (Input.GetKey(firstKey)) 
            { 
                return Vector3.back;
            } 
            else if (Input.GetKey(secondKey)) 
            { 
                return Vector3.forward;
            }
        } else if (!atasBawahAtauKananKiri)
        {
            if (Input.GetKey(firstKey)) 
            { 
                return Vector3.right;
            } 
            else if (Input.GetKey(secondKey)) 
            { 
                return Vector3.left;
            }
        } 
         
        return Vector3.zero; 
    } 
 
    private void MoveObject(Vector3 movement) 
    { 
        // Pergerakan Paddle dikali delta time
        pos.position = new Vector3(transform.position.x + (movement.x * speed)*Time.deltaTime, transform.position.y + (movement.y * speed)*Time.deltaTime, transform.position.z + (movement.z*speed)*Time.deltaTime);
    } 

    public void BecomeWall()
    {
        CanPlay = false;
        gameObject.transform.position = wallPosition;
        gameObject.transform.localScale = wallScale;
    }
}
