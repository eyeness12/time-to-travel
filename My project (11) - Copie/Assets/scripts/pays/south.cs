
using UnityEngine;
using UnityEngine.SceneManagement;

public class south : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            SceneManager.LoadScene("sud");
        }
    }
}
