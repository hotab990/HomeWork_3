using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void MoveTo(Vector3 position) => transform.position = position;

    private void Update()
    {
        CoinRotate();
    }

    private void CoinRotate()
    {
        transform.Rotate(Vector3.up * 4 * Time.deltaTime);
    }

}
