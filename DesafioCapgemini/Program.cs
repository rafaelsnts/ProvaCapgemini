// See https://aka.ms/new-console-template for more information
internal class Program
{
    private static void Main(string[] args)
    {
        Questao01(6);
    }
    public static void Questao01(int _entrada)
    {
        int contador = _entrada - 1;
        for (int i = 0; i < _entrada; i++)
        {
            for (int j = 0; j < _entrada; j++)
            {
                if(j < contador)
                {
                    Console.WriteLine(" ");
                } else
                {
                    Console.WriteLine("*");
                }
            }
            Console.WriteLine();
            contador--;
        }
    }
}