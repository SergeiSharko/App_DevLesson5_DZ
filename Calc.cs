namespace Lesson5_DZ
{
    internal class Calc : ICacl
    {
        public event EventHandler<EventArgs>? GotResult;
        public int Result { get; set; } = 0;
        private Stack<int> stack { get; set; } = new Stack<int>();

        public void Add(int num)
        {
            stack.Push(Result);
            Result += num;
            OnSomeEvent();
        }

        public void Divide(int num)
        {
            stack.Push(Result);
            Result /= num;
            OnSomeEvent();
        }

        public void Multiply(int num)
        {
            stack.Push(Result);
            Result *= num;
            OnSomeEvent();
        }

        public void Substruct(int num)
        {
            stack.Push(Result);
            Result -= num;
            OnSomeEvent();
        }

        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                Console.WriteLine("Отмена последней операции");
                Result = stack.Pop();
                OnSomeEvent();
            }
            else Console.WriteLine("Отмена последней операции неудалась!");
        }

        private void OnSomeEvent()
        {
            GotResult?.Invoke(this, new EventArgs());
        }


    }
}
