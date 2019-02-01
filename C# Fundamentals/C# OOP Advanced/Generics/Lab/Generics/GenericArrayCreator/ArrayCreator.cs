namespace GenericArrayCreator
{
    public  class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];

            if(item is double)
            {
                var itemAsDouble = double.Parse(item);
            }

            return array;
        }
    }
}
