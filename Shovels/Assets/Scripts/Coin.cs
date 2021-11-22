using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Destroy(gameObject);
            FindObjectOfType<Score>().AddCoin();
        }
    }
}
