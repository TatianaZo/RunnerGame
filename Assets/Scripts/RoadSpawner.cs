using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public int roadLength;
    public GameObject[] roadPrefs;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRoad();
    }    
    // ���������� ������ �� ������
    private void SpawnRoad()
    {
        for(int i = 0; i < roadLength; i++)//�� ���-�� ������ ����������� ����
        {
            if (i % 2 == 0) //������ �����.����� ��� �������
            {
                Instantiate(roadPrefs[0], new Vector3(0, 0, i * 5), Quaternion.identity, transform);
            }
            else
            {
                Instantiate(roadPrefs[1], new Vector3(0, 0, i * 5), Quaternion.identity, transform);
            }
        }
    }
}
