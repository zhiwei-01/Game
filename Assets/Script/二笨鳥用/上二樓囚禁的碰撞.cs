using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 上二樓囚禁的碰撞 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D A)
    {
        if (A.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("二樓-被困");
        }
    }
}
