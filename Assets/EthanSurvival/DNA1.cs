using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA1 {

    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValues = 0;

    public DNA1(int l, int v)
    {
        dnaLength = l;
        maxValues = v;
        SetRandom();
    }

    public void SetRandom()
    {
        genes.Clear();
        for(int i = 0; i<dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    public void SetInt(int pos, int value)
    {
        genes[pos] = value;
    }

    public void Combine(DNA1 d1, DNA1 d2)
    {
        for (int i =0; i<dnaLength; i++)
        {
            if(i < dnaLength / 2.0)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }

	public int GetGene(int pos)
    {
        return genes[pos];
    }
}
