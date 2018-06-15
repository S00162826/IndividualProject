using UnityEngine;
using System.Collections;

public class Crawl : MonoBehaviour
{
    public GameObject[] modelArray;
    private int modelNumber;

    void Start()
    {
        modelNumber = 0;
        ModelSwitch();
    }

    void ModelSwitch()
    {
        for (int x = 0; x < modelArray.Length; x++)
        {
            if (x == modelNumber)
            {
                modelArray[x].SetActive(true);
            }
            else
            {
                modelArray[x].SetActive(false);
            }
        }
        modelNumber += 1;
        if (modelNumber > modelArray.Length - 1)
        {
            modelNumber = 0;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ModelSwitch();
        }
    }
}