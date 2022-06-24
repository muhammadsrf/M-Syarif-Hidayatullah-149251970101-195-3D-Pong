using UnityEngine;
using UnityEngine.UI;

public class winnerSet : MonoBehaviour
{
    public GameManagers manager;
    public Text teks;

    private void OnEnable()
    {
        teks.text = manager.Pemenang;
    }
}
