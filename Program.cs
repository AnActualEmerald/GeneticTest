using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTest
{
    class Program
    {


        static void Main(string[] args)
        {
        }


    }

    class Individual
    {
        static Random r = new Random();

        public string traits;
        public float fit;


        public Individual(int len)
        {
            byte[] t = new byte[len];
            r.NextBytes(t);
            traits = Encoding.ASCII.GetString(t);
        }

        public void mutate(double chance)
        {
            string res = "";
            foreach (char c in traits)
            {
                if (r.NextDouble() > chance)
                {
                    byte[] b = new byte[1];
                    r.NextBytes(b);
                    res += Encoding.ASCII.GetString(b);
                }
                else
                    res += c;
            }

            traits = res;
        }

        public void GetFit(string target)
        {
            float score = 0.0f;
            for(int i = 0; i < target.Length; i++)
            {
                if (target[i] == traits[i])
                    score += 1;
            }
            fit = score / (target.Length);

        }

        static Individual CreateChild(string t1, string t2)
        {
            Individual i = new Individual(1);
            i.traits = t1 + t2;
            return i;
        }


    }
}
