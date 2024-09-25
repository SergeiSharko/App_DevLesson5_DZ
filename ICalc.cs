namespace Lesson5_DZ
{
    internal interface ICacl
    {
        void Add(int i);
        void Substruct(int i);
        void Divide(int i);
        void Multiply(int i);
        void CancelLast();
        event EventHandler<EventArgs> GotResult;
    }
}
