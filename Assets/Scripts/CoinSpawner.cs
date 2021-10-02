using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPref;
    public int chankCount;
    public int chankDistance;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChanks();
    }

    public void SpawnChanks() //монетки выстраиваются в линию
    {
        for (int i = 0; i < chankCount; i++)
        {
            SpawnCoinLine(i * chankDistance + 5);
        }
    }

    public int SpawnCoinLine(float z_position) // создание линий монеток
    {
        float horizontalPosition = Random.Range(-3.5f, 3.5f);
        int coinCount = Random.Range(3, 7);
        for(int i = 0; i < coinCount; i++)
        {
            var coin = Instantiate(coinPref, new Vector3( horizontalPosition, transform.position.y, z_position + i), Quaternion.identity);
            var coinAngle = coin.transform.GetChild(0).transform.eulerAngles; //смещает начальный угол поворота след. чанков монеток
            coin.transform.GetChild(0).transform.eulerAngles = new Vector3(coinAngle.x, 30, coinAngle.z);
        }
        return coinCount;
    }
}
