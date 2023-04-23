using System;

namespace LinkedListLibrary
{
    public class LinkedList
    {
        private Node _root;

        private Node _tail;
       
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = GetNodeByIndex(index); 

                return current.Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = GetNodeByIndex(index);

                current.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public int Length { get; private set; }

        // 1. Adding a value to the end
        public void Add(int value)
        {
            if (Length != 0)
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                Length = 1;
                _root = new Node(value);
                _tail = _root;
            }
        }

        // 2. Adding an array of values to the end
        public void Add(int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            if (values.Length != 0)
            {
                if (Length != 0)
                {
                    _tail.Next = new Node(values[0]);
                    _tail = _tail.Next;
                    AddValuesArrayFromFirstElement(values);
                }
                else
                {
                    _root = new Node(values[0]);
                    _tail = _root;
                    AddValuesArrayFromFirstElement(values);
                }
            }

            Length += values.Length;
        }

        // 3. Inserting a value by index (to the beginning - by index 0)
        public void InsertAt(int index, int value)
        {
            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                Node newNode = new Node(value);
                Length++;

                if (index > 0)
                {
                    Node previous = GetNodeByIndex(index - 1);
                    newNode.Next = previous.Next;
                    previous.Next = newNode;
                }
                else
                {
                    newNode.Next = _root;
                    _root = newNode;
                }                             
            }
            else
            {
                Length = 1;

                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException("index");
                }

                _root = new Node(value);
                _tail = _root;
            }
        }

        // 4. Inserting an array of values by index (to the beginning - by index 0)
        public void InsertAt(int index, int[] values)
        {
            if (values is null)
            {
                throw new NullReferenceException("values is null");
            }

            if (Length != 0)
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                InsertValuesArrayToNotEmptyListAtIndex(index, values);
            }
            else
            {
                if (index != 0)
                {
                    throw new IndexOutOfRangeException("index");
                }

                Add(values);
            }
        }

        // 5. Removing one element from the end
        public bool Remove()
        {
            if (Length == 0)
            {
                return false;
            }

            if (Length > 1)
            {
                _tail = GetNodeByIndex(Length - 2);
                _tail.Next = null;
            }
            else
            {                
                _root = null;
                _tail = null;
            }

            Length--;

            return true;
        }

        // 6. Removing N elements from the end
        public bool Remove(int number)
        {
            if (number < 0 || number > Length)
            {
                return false;
            }

            if (Length == 0)
            {
                return false;
            }

            if (number == Length - 1)
            {
                _tail = _root;
            }
            else if (number != Length)
            {
                _tail = GetNodeByIndex(Length - number - 1);
                _tail.Next = null;
            }
            else
            {
                _root = null;
                _tail = null;
            }

            Length -= number;

            return true;
        }

        // 7. Removing one element by index (in the beginning - by index 0)
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            if (index > 0 && index != Length - 1)
            {
                Node previous = GetNodeByIndex(index - 1);
                previous.Next = GetNodeByIndex(index + 1);
                Length--;
            }
            else if (index == Length - 1)
            {
                Remove();
            }
            else
            {
                _root = GetNodeByIndex(index + 1);
                Length--;
            }

            return true;
        }

        // 8. Removing N elements by index (in the beginning - by index 0)
        public bool RemoveAt(int index, int number)
        {
            if (index < 0 || index >= Length)
            {
                return false;
            }

            if (number > Length - index || number <= 0)
            {
                return false;
            }

            if (index + number < Length)
            {
                if (index > 0)
                {
                    Node prevoius = GetNodeByIndex(index - 1);
                    prevoius.Next = GetNodeByIndex(index + number);
                }
                else
                {
                    _root = GetNodeByIndex(index + number);
                }
            }
            else
            {
                if (index > 0)
                {
                    _tail = GetNodeByIndex(index - 1);
                    _tail.Next = null;
                }
                else
                {
                    _root = null;
                    _tail = null;
                }
            }

            Length -= number;

            return true;
        }

        // 9. The first index by a value
        public int GetIndexByValue(int value)
        {
            int index = -1;
            Node node = _root;
            int i = 0;

            while (i < Length)
            {
                if (node.Value == value)
                {
                    index = i;
                    break;
                }

                node = node.Next;
                i++;
            }

            return index;
        }

        // 10. Reverse
        public void Reverse()
        {
            if (Length != 0)
            {
                _tail = _root;
                Node tmp = _tail.Next;

                while (_tail.Next != null)
                {
                    _tail.Next = tmp.Next;
                    tmp.Next = _root;
                    _root = tmp;
                    tmp = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        // 11. Search for the maximum value
        public int FindMaxValue()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int maxValue = node.Value;

            while (node.Next != null) 
            {
                node = node.Next;

                if (node.Value > maxValue)
                {
                    maxValue = node.Value;
                }
            }
            
            return maxValue;
        }

        // 12. Search for the minimum value
        public int FindMinValue()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int minValue = node.Value;

            while (node.Next != null)
            {
                node = node.Next;

                if (node.Value < minValue)
                {
                    minValue = node.Value;
                }
            }

            return minValue;
        }

        // 13. Search for the index of the maximum value
        public int FindMaxValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int maxValue = node.Value;
            int maxIndex = 0;
            int index = 0;

            while (node.Next != null)
            {
                node = node.Next;
                index++;

                if (node.Value > maxValue)
                {
                    maxValue = node.Value;
                    maxIndex = index;
                }
            }

            return maxIndex;
        }

        // 14. Search for the index of the minimum value
        public int FindMinValueIndex()
        {
            if (Length == 0)
            {
                throw new Exception("LinkedList object is empty");
            }

            Node node = _root;
            int minValue = node.Value;
            int minIndex = 0;
            int index = 0;

            while (node.Next != null)
            {
                node = node.Next;
                index++;

                if (node.Value < minValue)
                {
                    minValue = node.Value;
                    minIndex = index;
                }
            }

            return minIndex;
        }

        // 15. Up Sort
        // up sort bubble
        public void UpSortBubble()
        {
            int tmpValue;
            int i = 0;

            while (i < Length)
            {
                Node currentNode = _root;

                while (currentNode.Next != null)
                {
                    if (currentNode.Value > currentNode.Next.Value)
                    {
                        tmpValue = currentNode.Value;
                        currentNode.Value = currentNode.Next.Value;
                        currentNode.Next.Value = tmpValue;
                    }

                    currentNode = currentNode.Next;
                }

                i++;
            }
        }

        // up sort insertions
        public void UpSortInsertions()
        {
            if (Length > 1)
            {
                Node previous = _root;
                Node current = _root.Next;

                for (int i = 1; i < Length; i++)
                {
                    Node currentSorted = _root;

                    if (current.Value < currentSorted.Value)
                    {
                        previous.Next = current.Next;
                        current.Next = currentSorted;
                        _root = current;
                        current = previous.Next;
                        continue;
                    }

                    if (current.Value >= previous.Value)
                    {
                        current = current.Next;
                        previous = previous.Next;
                        continue;
                    }
                
                    while (currentSorted.Next != current) //
                    {
                        if (current.Value < currentSorted.Next.Value)
                        {
                            previous.Next = current.Next;
                            current.Next = currentSorted.Next;
                            currentSorted.Next = current;
                            break;
                        }

                        currentSorted = currentSorted.Next;
                    }

                    current = previous.Next;
                }
            }
        }

        // 16. Down Sort
        // down sort insertions
        public void DownSortInsertions()
        {
            if (Length > 1)
            { 
                Node previous = _root;
                Node current = _root.Next;

                for (int i = 1; i < Length; i++)
                {
                    Node currentSorted = _root;

                    if (current.Value > currentSorted.Value)
                    {
                        previous.Next = current.Next;
                        current.Next = currentSorted;
                        _root = current;
                        current = previous.Next;
                        continue;
                    }

                    if (current.Value <= previous.Value)
                    {
                        current = current.Next;
                        previous = previous.Next;
                        continue;
                    }

                    while (currentSorted.Next != current) 
                    {
                        if (current.Value > currentSorted.Next.Value)
                        {
                            previous.Next = current.Next;
                            current.Next = currentSorted.Next;
                            currentSorted.Next = current;
                            break;
                        }

                        currentSorted = currentSorted.Next;
                    }

                    current = previous.Next;
                }
            }
        }

        // 21. Removing the first with a value
        public int RemoveFirstWithValue(int value)
        {
            int index = 0;

            if (Length == 0)
            {
                return -1;
            }
            else if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                Node previous = _root;
                Node current = previous.Next;

                if (previous.Value == value)
                {
                    _root = current;
                }
                else
                {
                    index = 1;

                    while (current != null)
                    {
                        if (current.Value == value)
                        {
                            if (index != Length - 1)
                            {
                                previous.Next = current.Next;
                            }
                            else
                            {
                                _tail = previous;
                            }

                            Length--;
                            return index;
                        }

                        previous = current;
                        current = current.Next;
                        index++;
                    }

                    return -1;
                }
            }

            Length--;
            
            return index;
        }

        // 22. Removing each with a value
        // nice, but not efficient
        public int RemoveAllWithValue_tmp(int value)
        {
            int count = 0;
            Node current = _root;

            while (current != null)
            {
                if (current.Value == value)
                {
                    count++;
                }

                current = current.Next;
            }

            if (count != 0)
            {
                int i = 0;

                while (i < count)
                {
                    RemoveFirstWithValue(value);
                    i++;
                }
            }
            else
            {
                return 0;
            }

            return count;
        }

        // seems better
        public int RemoveAllWithValue(int value)
        {
            if (Length == 0)
            {
                return 0;
            }
            
            int count = 0;

            if (Length == 1)
            {
                if (_root.Value == value)
                {
                    _root = null;
                    _tail = null;
                    Length = 0;

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                // removing all first significant elements
                Node tmp = _root;

                while (tmp.Value == value)
                {   
                    count++;

                    if (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                    }
                    else
                    {
                        _root = null;
                        _tail = null;
                        Length = 0;

                        return count;
                    }
                }

                // removing significant elements from the first unequal value to the last
                Node previous = _root;
                Node current = _root.Next;

                while (current != null)
                {
                    if (current.Value == value)
                    {
                        count++;
                        previous.Next = current.Next;
                        current = current.Next;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            }

            if (count != 0)
            {
                Length -= count;
                _tail = GetNodeByIndex(Length - 1);

                return count;
            }
            else
            {
                return 0;
            }
        }

        // Overriding standard methods
        public override bool Equals(object? obj)
        {
            LinkedList list = (LinkedList)obj;

            if (Length != list.Length)
            {
                return false;
            }

            if (Length == 0)
            {
                return true;
            }

            Node current = _root;
            Node currentList = list._root;

            if (Length != 1)
            {
                do
                {
                    if (current.Value != currentList.Value)
                    {
                        return false;
                    }

                    current = current.Next;
                    currentList = currentList.Next;
                }
                while (current.Next is not null);
            }
            else
            {
                if (current.Value != currentList.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string s = string.Empty;

            if (Length != 0)
            {
                Node current = _root;
                s = string.Concat(current.Value.ToString(), " ");

                while (current.Next is not null)
                {
                    current = current.Next;
                    s += string.Concat(current.Value.ToString(), " ");
                }
            }

            return s;
        }

        // Privates
        private Node GetNodeByIndex(int index)
        {
            Node node = _root;
            int i = 1;

            while (i <= index)
            {
                node = node.Next;
                i++;
            }

            return node;
        }

        private void AddValuesArrayFromFirstElement(int[] values)
        {
            int i = 1;

            while (i < values.Length)
            {
                _tail.Next = new Node(values[i]);
                _tail = _tail.Next;
                i++;
            }
        }

        private Node InsertValuesArrayFromFirstElement(Node tmp, int[] values)
        {
            int i = 1;

            while (i < values.Length)
            {
                tmp.Next = new Node(values[i]);
                tmp = tmp.Next;
                i++;
            }

            return tmp;
        }

        private void InsertValuesArrayToNotEmptyListAtIndex(int index, int[] values)
        {
            if (index > 0)
            {
                Node tmp = new Node(values[0]);
                Node previous = GetNodeByIndex(index - 1);
                Node previousNext = previous.Next;
                previous.Next = tmp;
                tmp = InsertValuesArrayFromFirstElement(tmp, values);
                tmp.Next = previousNext;
            }
            else
            {
                Node previousNext = _root;
                Node tmp = new Node(values[0]);
                _root = tmp;
                tmp = InsertValuesArrayFromFirstElement(tmp, values);
                tmp.Next = previousNext;
            }

            Length += values.Length;
        }
    }
}
