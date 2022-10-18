using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BearAndBeesMultithread
{
    internal class Forest
    {
        private int jarCap, jar, turn = 0, counter = 0, threadExit = 0;
        private bool bearAwake;
        private int[] beesCap = new int[10];

        public Forest(int N)
        {
            jarCap = N;
            jar = 0;
            createBear();
            createBees();
        }

        private void createBees()
        {
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                beesCap[i] = r.Next(1, jarCap);
                Thread bee = new Thread(fillJar);
                bee.Start(i);
            }
        }
        
        private void createBear()
        {
            bearAwake = false;
            Thread bear = new Thread(takeJar);
            bear.Start();
        }
        
        private void fillJar(Object obj)
        {
            int tid = (int)obj;

            while(counter < 5)
            {
                if(bearAwake == false && turn == tid)
                {
                    Console.WriteLine("Bee {0} deposits {1} units of honey into the jar.", tid, beesCap[tid]);
                    jar += beesCap[tid];
                    Console.WriteLine("Jar has now {0} units of honey.\n", jar);
                    if(jar >= jarCap)
                    {
                        bearAwake = true;
                    }
                    turn = (turn + 1) % 10;
                }
            }
            threadExit++;
        }

        private void takeJar()
        {
            while(threadExit < 10)
            {
                if(bearAwake == true)
                {
                    Console.WriteLine("--Bear ate {0} units of honey\n", jar);
                    jar = 0;
                    counter++;
                    bearAwake = false;
                }
            }
            threadExit++;
        }

        public bool checkThreadExit()
        {
            return threadExit < 11;
        }
    }
}
