

namespace algorithm_practice.DataStructure
{
    public class Queue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private int _size { get; set; }
        private int _headPointer { get; set; }
        private int _tailPointer { get; set; }

        // 실제 데이터가 저장될 배열
        private T[] _collection { get; set; }
        private const int _defaultCapacity = 10;

        public Queue()
        {
            _size = 0;
            _headPointer = 0; // 가장 먼저 들어온 아이템
            _tailPointer = 0; // 가장 나중에 들어온 아이템
            _collection = new T[_defaultCapacity];
        }

        private void _resize(int newSize)
        {
            try
            {
                var tempCollection = new T[newSize];
                Array.Copy(_collection, _headPointer, tempCollection, 0, _size);
                _collection = tempCollection;
            }
            catch (OutOfMemoryException e)
            {
                throw e;
            }
        }

        public int Count
        {
            get { return _size; }
        }

        public bool IsEmpty 
        { 
            get { return _size == 0; }
        }


        public void Enqueue(T dataItem)
        {
            if (_size == _collection.Length)
            {
                try
                {
                    _resize(_collection.Length * 2);
                }
                catch (OutOfMemoryException e)
                {
                    throw e;
                }
            }
            // 꼬리에 새 아이템 삽입
            _collection[_tailPointer++] = dataItem;
            if (_tailPointer == _collection.Length)
            {
                _tailPointer = 0;
            }
            _size++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exception("Queue is empty.");
            }
            var topItem = _collection[_headPointer];
            _collection[_headPointer] = default;

            _size--;
            _headPointer++;

            if (_headPointer == _collection.Length)
            {
                _headPointer = 0;
            }
            if (_size > 0 &&
                _collection.Length > _defaultCapacity &&
                _size <= _collection.Length / 4)
            {
                var head = _collection[_headPointer];
                var tail = _collection[_tailPointer];

                _resize(_collection.Length / 3 * 2);

                _headPointer = Array.IndexOf(_collection, head);
                _tailPointer = Array.IndexOf(_collection, tail);
            }
            return topItem;
        }

        public IEnumerator<T>? GetEnumerator()
        {
            return _collection?.GetEnumerator() as IEnumerator<T>;
        }

        System.Collections.IEnumerator? System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
