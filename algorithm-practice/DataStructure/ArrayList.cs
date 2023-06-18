

namespace algorithm_practice.DataStructure
{
	public class ArrayList<T> : IEnumerable<T>
	{
		bool DefaultMaxCapacityIsX64 = true;
		bool IsMaximumCapacityReached = false;

		// 실제 데이터를 저장할 배열
		private T[] _array;

		// ArrayList에 데이터가 몇 칸 채워져 있는지 표시하는 정수
		private int _size { get; set; }

		// 칸 수 지정하지 않았을 때의 기본값
		private const int _defaultCapacity = 10;

		public ArrayList() : this(capacity: 0) { }

		// 배열 칸 수 받아서 초기화
		public ArrayList(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			else
			{
				_array = new T[capacity];
			}
			_size = 0;
		}

		private void _resizeCapacity(int newCapacity)
		{
			if (newCapacity != _array.Length && newCapacity > _size)
			{
				try
				{
					Array.Resize<T>(ref _array, newCapacity);
				}
				catch (OutOfMemoryException e)
				{
					throw e;
				}
			}
		}

		// _size 출력 기능
		public int Count
		{
			get { return _size; }
		}

		// 배열의 칸 수 출력 기능
		public int Capacity
		{
			get { return _array.Length; }
		}

		// 원소에 인덱스로 접근
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= _size)
				{
					throw new IndexOutOfRangeException();
				}
				return _array[index];
			}
			set
			{
				if (index < 0 || index >= _size)
				{
					throw new IndexOutOfRangeException();
				}
				_array[index] = value;
			}
		}

		// 맨 뒤에 추가 기능
		public void Add(T dataItem)
		{
			if (_size == _array.Length)
			{
				_resizeCapacity(_size + 1);
			}
			_array[_size++] = dataItem;
		}

		// 삽입 기능
		public void InsertAt(T dataItem, int index)
		{
			if (index < 0 || index > _size)
			{
				throw new IndexOutOfRangeException("Please provide a valid index.");
			}

			if (_size == _array.Length)
			{
				_resizeCapacity(_size + 1);
			}
			// 삽입할 칸부터 배열 끝까지의 기존 원소들을 한 칸씩 뒤로 이동
			if (index < _size)
			{
				Array.Copy(_array, index, _array, index + 1, (_size - index));
			}
			_array[index] = dataItem;
			_size++;
		}

		// 삭제 기능
		public bool Remove(T dataItem)
		{
			int index = IndexOf(dataItem);
			if (index >= 0)
			{
				RemoveAt(index);
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Please pass a valid index.");
            }

			_size--;
			if (index < _size)
			{
				Array.Copy(_array, index + 1, _array, index, (_size - index));
			}
			_array[_size] = default;
        }

		// 인덱스 출력
		public int IndexOf(T dataItem)
		{
			return Array.IndexOf(_array, dataItem);
        }


		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i< Count; i++)
			{
				yield return _array[i];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
