using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float[] input = new float[226];

    public float[,] input_first = new float[226, 229];
    public float[] firstHiddenLayer = new float[229];
    public float[,] first_second = new float[229, 120];
    public float[] secondHiddenLayer = new float[120];
    public float[,] second_output = new float[120, 5];
    public float[] output = new float[5];

    void Start()
    {
        OutputWeights();

        /*
        Rand(input_first, 226, 229);
        Rand(first_second, 229, 120);
        Rand(second_output, 120, 5);
        */

        //SavingWeights();
    }

    public void AI()
    {
        Payment(input, input_first, firstHiddenLayer, 226, 229);
        Payment(firstHiddenLayer, first_second, secondHiddenLayer, 229, 120);
        Payment(secondHiddenLayer, second_output, output, 120, 5);
    }

    /*
    public void Rand(float[,] mass, int x, int y)
    {
        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                mass[i, j] = Random.Range(-3.0f, 3.0f);
            }
        }
    }
    */

    public void Payment(float[] input_1, float[,] in_out, float[] output_1, int x, int y)
    {
        for(int j = 0; j < y; j++)
        {
            for(int i = 0; i < x; i++)
            {
                output_1[j] += (input_1[i] * in_out[i,j]); 
            }

            output_1[j] = 1 / (1 + Mathf.Exp(output_1[j]));
        }
    }

    public void MutantS()
    {
        Mutant(input_first, 226, 229);
        Mutant(first_second, 229, 120);
        Mutant(second_output, 120, 5);
    }

    public void Mutant(float[,] mass, int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                mass[i, j] += Random.Range(-1.0f, 1.0f);
            }
        }
    }

    public void SavingWeights()
    {
        for(int i = 0; i < 226; i++)
        {
            for(int j = 0; j < 229; j++)
            {
                PlayerPrefs.SetFloat("Input_first" + i + "." + j, input_first[i,j]);
            }
        }

        for (int i = 0; i < 229; i++)
        {
            for (int j = 0; j < 120; j++)
            {
                PlayerPrefs.SetFloat("First_second" + i + "." + j, first_second[i, j]);
            }
        }

        for (int i = 0; i < 120; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                PlayerPrefs.SetFloat("Second_output" + i + "." + j, second_output[i, j]);
            }
        }
    }

    public void OutputWeights()
    {
        for (int i = 0; i < 226; i++)
        {
            for (int j = 0; j < 229; j++)
            {
                input_first[i, j] = PlayerPrefs.GetFloat("Input_first" + i + "." + j);
            }
        }

        for (int i = 0; i < 229; i++)
        {
            for (int j = 0; j < 120; j++)
            {
                first_second[i, j] = PlayerPrefs.GetFloat("First_second" + i + "." + j);
            }
        }

        for (int i = 0; i < 120; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                second_output[i, j] = PlayerPrefs.GetFloat("Second_output" + i + "." + j);
            }
        }
    }
}
