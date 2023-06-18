

namespace algorithm_practice.DataStructure
{
    public class Stack<T> : IEnumerable<T> where T : IComparable<T>
    {
        // 실제로 데이터를 담을 배열
        private ArrayList<T> _collection { get; set; }
        public int Count { get { return _collection.Count; } }

        public Stack()
        {
            _collection = new ArrayList<T>();
        }

        public T Top
        {
            get
            {
                try
                {
                    return _collection[_collection.Count - 1];
                }
                catch (Exception)
                {
                    throw new Exception("Stack is empty");
                }
            }
        }

        public void Push(T dataItem)
        {
            _collection.Add(dataItem);
        }

        public T Pop()
        {
            if (Count > 0)
            {
                var top = Top;
                _collection.RemoveAt(_collection.Count - 1);
                return top;
            }
            throw new Exception("Stack is empty.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _collection.Count - 1; i >= 0; --i)
                yield return _collection[i];
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
