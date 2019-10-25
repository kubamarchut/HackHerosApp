using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject finalScreen;

    public Transform target;
    public float transformSpeed = .3f;

    // Update is called once per frame
    void LateUpdate()
    {
        if(target.position.y > transform.position.y && transform.position.y < 75)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, transformSpeed);
        }
        if (transform.position.y >= 70)
        {
            finalScreen.SetActive(true);
        }
    }
}
