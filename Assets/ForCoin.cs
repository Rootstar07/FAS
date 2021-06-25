using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForCoin : MonoBehaviour
{
    public int gold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CoinChecker")
            gameObject.SetActive(false);
    }
}
