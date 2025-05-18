using UnityEngine;

public class Spieler : MonoBehaviour
{
    public GameObject kamera;

    void Update()
    {
        kamera.transform.position = new Vector3(0, 4, transform.position.z - 10);
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.CompareTag("Platte"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
        }
    }

}