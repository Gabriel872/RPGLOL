using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public int column;
    public int rows;
    public GameObject preFab;

    private void Start()
    {
        Grid();
    }

    public void Grid()
    {
        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                //Instantiate(preFab, new Vector3(transform.position.x + 0.5f + j, transform.position.y + 0.5f - i, transform.position.z +2f), Quaternion.identity, gameObject.transform);
            }
        }
    }
}
