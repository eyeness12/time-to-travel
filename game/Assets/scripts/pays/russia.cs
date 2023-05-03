
using UnityEngine;
using UnityEngine.SceneManagement;

public class russia : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            SceneManager.LoadScene("russia");
        }
    }
}
