
using UnityEngine;
using UnityEngine.SceneManagement;

public class brazil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plane"))
        {
            SceneManager.LoadScene("brazil");
        }
    }
}
