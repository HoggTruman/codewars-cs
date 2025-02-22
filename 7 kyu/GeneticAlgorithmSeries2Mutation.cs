// https://www.codewars.com/kata/567b39b27d0a4606a5000057

using System.Text;
using System;

class GeneticAlgorithmSeries2Mutation
{
    public string Mutate(string chromosome, double probability)
    {
        Random rnd = new();
        StringBuilder sb = new(chromosome);

        for (int i = 0; i < chromosome.Length; ++i)
        {
            if (rnd.NextDouble() <= probability)
            {
                sb[i] = sb[i] == '0' ? '1' : '0';
            }
        }

        return sb.ToString();
    }
}
