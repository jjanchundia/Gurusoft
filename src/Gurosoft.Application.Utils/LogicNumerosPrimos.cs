namespace Gurosoft.Application.Utils
{
    public static class LogicNumerosPrimos
    {
        public static int[] CalcularNumerosPrimos(int start, int count)
        {
            int[] primes = new int[count];
            int foundPrimes = 0;
            int number = start;

            while (foundPrimes < count)
            {
                if (EsPrimo(number))
                {
                    primes[foundPrimes] = number;
                    foundPrimes++;
                }
                number++;
            }

            return primes;
        }

        public static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;
            if (numero % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(numero); i += 2)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }

    }
}