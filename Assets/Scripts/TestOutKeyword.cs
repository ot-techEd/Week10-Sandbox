using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOutKeyword : MonoBehaviour
{
    public bool specialNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomNumber valueToReturn = GetRandomNumber(5);
            specialNumber = valueToReturn.isSpecialNumber;
            Debug.Log(valueToReturn.randomValue);

        }
    }

    public RandomNumber GetRandomNumber(int maxValue)
    {
        int randomInt = Random.Range(0, maxValue);

        RandomNumber randomNumber;
        randomNumber.randomValue = randomInt;   
        if (randomInt == 2)
        {
            randomNumber.isSpecialNumber = true;
        }
        else
        {
            randomNumber.isSpecialNumber = false;
        }

        return randomNumber;
    }
}

