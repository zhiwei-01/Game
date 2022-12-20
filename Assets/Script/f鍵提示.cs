using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f鍵提示 : MonoBehaviour
{
    public GameObject Button;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }
}
