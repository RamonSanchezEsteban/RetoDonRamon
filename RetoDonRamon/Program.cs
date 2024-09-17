namespace RetoDonRamon
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Programa creado por Ramon Sanchez Esteban, disfruta:\n");
            Random rand = new Random();
            int v;
            int a;
            int b;
            int[] criticos = new int[50];
            int suma = 0;
            bool modoFacil;
            Console.WriteLine(  "Dime si quieres elegir el numero de victoria o lo cojo yo al azar:\n" +
                                "0 -> escribirlo por pantalla (modo facil)\n" + 
                                "1 -> escogerlo al azar (modo dificil)");
            modoFacil = (Console.ReadLine().Equals("0"));
            if(modoFacil)
            {
                Console.WriteLine("Modo facil: introduce el numero de victoria");
                v = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Modo dificil, el número de victoria es: ");
                Random random = new Random();
                v = random.Next(50, 70);
                Console.WriteLine(v);
            }
            while (v < 50)
            {
                Console.WriteLine("Oh vamos puedes poner uno mas grande, escribe otro");
                v = Convert.ToInt32(Console.ReadLine());
            }
            PuntosCriticos(v, criticos);
            a = LeerTurno();
            suma += a;
            Console.WriteLine("suma actual: " + suma);
            while (!(suma >= v))
            {
                Console.Write("mi turno: ");
                b = CriticoProximo(suma, criticos) - suma;
                if (b == 11)
                {
                    b = rand.Next(1, 11);
                }
                Console.WriteLine(b);
                suma += b;
                Console.WriteLine("suma actual: " + suma);
                if (suma == v)
                {
                    Console.WriteLine("\nHAS PERDIDO, HE GANADO");
                    Console.ReadLine();
                    return;
                }
                a = LeerTurno();
                suma += a;
                Console.WriteLine("suma actual: " + suma);
                if (suma == v)
                {
                    Console.WriteLine("\nHAS GANADO");
                    Console.ReadLine();
                    return;
                }
            }

            Console.ReadLine();
        }

        static void PuntosCriticos(int n, int[] v)
        {
            v[0] = 0;
            int i = 1;
            while (n > 0)
            {
                v[i] = n;
                i++;
                n -= 11;
            }
            v[0] = i;
        }

        static int CriticoProximo(int n, int[] v)
        {
            int c;
            int i = 1;
            do
            {
                c = v[i];
                i++;
            } while ((v[i] > n) && (i != v[0]));
            return c;
        }

        static void EscribirVector(int[] v)
        {
            int i = 1;
            while (i < v[0])
            {
                Console.WriteLine(v[i]);
                i++;
            }
        }

        static int LeerTurno()
        {
            int n;
            Console.WriteLine("tu turno: ");
            n = Convert.ToInt32(Console.ReadLine());
            while (!(n < 11 && n > 0))
            {
                Console.WriteLine("introduce un numero del intervalo (1-10)");
                n = Convert.ToInt32(Console.ReadLine());
            }
            return n;
        }
    }
}
