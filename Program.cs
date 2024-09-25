namespace Lesson5_DZ
{
    internal class Program
    {
        static void Calc_CalcGetResult(object? sender, EventArgs args)
        {
            Console.WriteLine($"Результат оперции = {((Calc)sender).Result}");
        }

        
        static void Main(string[] args)
        {
            ICacl calc = new Calc();

            calc.GotResult += Calc_CalcGetResult;

            while (true)
            {
                Console.WriteLine("Для выхода из программы введите 'exit'. Для отмены операции введите 'cancel'");
                Console.Write("Введите число => ");
                string? inputStr = Console.ReadLine();
                if (inputStr.ToLower().Equals("exit") || inputStr.Equals(""))
                {
                    Console.WriteLine("Завершение программы...");
                    break;
                }
                else if (inputStr.ToLower().Equals("cancel")) 
                {
                    calc.CancelLast();
                }
                else
                {
                    bool isCorrectNum = int.TryParse(inputStr, out int number);

                    while (!isCorrectNum)
                    {
                        Console.WriteLine("Введено неверное число!");
                        Console.Write("Введите чило => ");
                        inputStr = Console.ReadLine();
                        isCorrectNum = int.TryParse(inputStr, out int corrNumber);
                        number = corrNumber;
                    }

                    Console.Write("Введите одну из операций (| + |, | - |, | * |,  | / |) => ");
                    string? inputOp = Console.ReadLine();

                    while (!"+-*/".Contains(inputOp))
                    {
                        Console.WriteLine("Введена неверная операция!");
                        Console.Write("Введите одну из операций (| + |, | - |, | * |,  | / |) => ");
                        inputOp = Console.ReadLine();
                    }

                    switch (inputOp)
                    {
                        case "*": calc.Multiply(number); break;
                        case "-": calc.Substruct(number); break;
                        case "+": calc.Add(number); break;
                        case "/": calc.Divide(number); break;
                        default: break;
                    }
                }
            }
        }
    }
}
