using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public GameObject retryScreen;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.name == "player")
        {
            retryScreen.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
