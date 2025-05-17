using UnityEngine;
using TMPro;

public class BallBewegen : MonoBehaviour
{
    readonly float eingabeFaktor = 10;
    readonly float grenzWinkel = 7.5f;

    public TextMeshProUGUI xWinkelAnzeige;
    public TextMeshProUGUI zWinkelAnzeige;

    void Update()
    {
        float zEingabe = Input.GetAxis("Horizontal");
        float xEingabe = -Input.GetAxis("Vertical");

        float zWinkelNeu = transform.eulerAngles.z - zEingabe * eingabeFaktor * Time.deltaTime;
        if (zWinkelNeu >= 0 && zWinkelNeu < 180 && zWinkelNeu > grenzWinkel)
        {
            zWinkelNeu = grenzWinkel;
        }

        if (zWinkelNeu >= 180 && zWinkelNeu < 360 && zWinkelNeu < 360 - grenzWinkel)
        {
            zWinkelNeu = 360 - grenzWinkel;
        }

        float xWinkelNeu = transform.eulerAngles.x - xEingabe * eingabeFaktor * Time.deltaTime;
        if (xWinkelNeu >= 0 && xWinkelNeu < 180 && xWinkelNeu > grenzWinkel)
        {
            xWinkelNeu = grenzWinkel;
        }

        if (xWinkelNeu >= 180 && xWinkelNeu < 360 && xWinkelNeu < 360 - grenzWinkel)
        {
            xWinkelNeu = 360 - grenzWinkel;
        }

        transform.eulerAngles = new Vector3(xWinkelNeu, 0, zWinkelNeu);

        xWinkelAnzeige.text = string.Format("xWinkel: {0, 6:0.0}", xWinkelNeu);
        zWinkelAnzeige.text = string.Format("zWinkel: {0, 6:0.0}", zWinkelNeu);
    }
}
