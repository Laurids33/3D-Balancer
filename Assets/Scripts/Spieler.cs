using TMPro;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    public GameObject kamera;

    public GameObject gewinn;
    int punkte = 0;
    public TextMeshProUGUI punkteAnzeige;

    void Update()
    {
        kamera.transform.position = new Vector3(0, 4, transform.position.z - 10);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Gewinn"))
        {
            punkte++;
            punkteAnzeige.text = "Punkte: " + punkte;
            gewinn.SetActive(false);
            Invoke(nameof(NaechsterGewinn), 1);
        }
    }

    void NaechsterGewinn()
    {
        gewinn.SetActive(true);
        gewinn.transform.localPosition = new Vector3(Random.Range(-0.3f, 0.3f), 1.55f, Random.Range(-0.3f, 0.3f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rand"))
        {
            punkte--;
            punkteAnzeige.text = "Punkte: " + punkte;
        }
    }

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.CompareTag("Platte"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
        }
    }

}