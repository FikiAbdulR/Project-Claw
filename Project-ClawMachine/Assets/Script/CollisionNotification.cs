using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollisionNotification : MonoBehaviour
{
    public GameObject notificationPanel;

    private void Start()
    {
        notificationPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PrizeObject"))
        {
            StartCoroutine(ShowNotification());
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator ShowNotification()
    {
        notificationPanel.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        notificationPanel.SetActive(false);
    }
}
