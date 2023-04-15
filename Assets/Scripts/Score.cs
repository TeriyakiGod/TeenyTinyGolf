using UnityEngine;

public class Score
{
    private int[] score = new int[18];

    public void Set(int hole, int value)
    {
        score[hole] = value;
    }
    public int Get(int hole)
    {
        return score[hole];
    }
}
