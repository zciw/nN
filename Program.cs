using System;
using System.Collections.Generic;


namespace nN
{

	class Neuron
	{
		public double weight;
		public double input;

		public double Count()
		{
			return weight * input;
		}

		public int Result()
		{
			if (Count() >= 0.5)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		public List<Neuron> prev;

		public Neuron(double weight, double input)
		{
			this.weight = weight;
			this.input = input;
			prev = new List<Neuron>();
		}
	}	


    class Program
    {
        static void Main(string[] args)
        {
        	double[] weights = new double[] {1, 0.3, 0.9};
			double[] inputs1 = new double[] {1,0,1,0};
			double[] inputs2 = new double[] {0,1,1,0};
			double[] expectedResults = new double[] {1,1,1,0};


			for (double w1 = 0; w1 < 1; w1 += 0.1)
            {
                for (double w2 = 0; w2 < 1; w2 += 0.1)
                {
                    for (double w3 = 0; w3 < 1; w3 += 0.1)
                    {
                        for (int i = 0; i < inputs1.Length; i++)
                        {

                            Neuron one = new Neuron(w1, inputs1[i]);
                            Neuron two = new Neuron(w2, inputs2[i]);
                            Neuron three = new Neuron(w3, 0);

                            three.prev.Add(one);
                            three.prev.Add(two);
                            foreach (var item in three.prev)
                            {
                                three.input += item.Count();
                            }
                            if (three.Result() == expectedResults[i])
                            {
                                Console.WriteLine(w1 + " " + w2 + " " + w3);
                            }
                        }
                    }
                }
			}
		}
    }
}
