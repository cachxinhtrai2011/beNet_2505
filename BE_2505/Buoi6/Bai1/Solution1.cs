using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Buoi6.Bai1
{
    public class Solution1
    {
        /*
         Bài 1.Tạo một lớp generic MyStack<T> mô phỏng hành vi của cấu trúc dữ liệu stack với các phương thức:
         Push(T item): Thêm một phần tử vào đỉnh stack.
         Pop(): Lấy và xóa phần tử ở đỉnh stack.
         Peek(): Lấy phần tử ở đỉnh stack nhưng không xóa.
         IsEmpty(): Kiểm tra stack có rỗng không.
         Viết chương trình kiểm tra các phương thức này với các kiểu dữ liệu khác nhau.
         */
        public class MyStack<T>
        {
            public List<T> list;
            public MyStack()
            {
                list = new List<T>();
            }

            //Thêm phần tử
            public void Push(T item) 
            {
                list.Add(item);
            }

            //Lấy và xóa phần tử
            public T Pop()
            {
                if (IsEmpty())
                {
                    Environment.Exit(1);
                }
                T item = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                return item;
            }

            //Lấy phần tử ở đỉnh stack nhưng không xóa.
            public T Peek()
            {
                if (IsEmpty()) {
                    Environment.Exit(1);
                }
                T item = list[list.Count - 1];
                return item;
            }
            public bool IsEmpty()
            {
                if (list.Count == 0)
                {
                    Console.WriteLine("Stack bị trống!");
                    return true;
                }
                return false;
            }
        }
        public void GiaiBai1()
        {
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(123);
            myStack.Push(456);
            myStack.Push(789);

            Console.WriteLine($"Xóa phần tử ở đầu của Stack int: {myStack.Pop()}");
            Console.WriteLine($"Lấy phần tử ở đầu của Stack int: {myStack.Peek()}");

            MyStack<string> myStackString = new MyStack<string>();
            myStackString.Push("123");
            myStackString.Push("456");
            myStackString.Push("789");

            Console.WriteLine($"Xóa phần tử ở đầu của Stack string: {myStackString.Pop()}");
            Console.WriteLine($"Lấy phần tử ở đầu của Stack string: {myStackString.Peek()}");
        }
    }
}
