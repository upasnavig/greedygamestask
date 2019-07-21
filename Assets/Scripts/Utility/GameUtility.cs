using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtility
{
    private static List<int> randomNumbersGenerated = new List<int>();

    public static int GetRandomNumber(int min,int max)
    {
        int randomNumber = default;
        while (randomNumbersGenerated.Contains(randomNumber))
        {
            randomNumber = UnityEngine.Random.Range(min, max);
        }
        randomNumbersGenerated.Add(randomNumber);
        return randomNumber;
    }

}
