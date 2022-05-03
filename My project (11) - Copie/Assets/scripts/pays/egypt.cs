
using UnityEngine;
using UnityEngine.SceneManagement;

public class egypt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            SceneManager.LoadScene("egypt");
        }
    }
}
