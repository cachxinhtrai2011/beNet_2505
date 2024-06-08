using BE_2505.Buoi4.Bai23;
using BE_2505.Buoi4.Bai24;
using BE_2505.Buoi5.Bai25;
using System.Text;
// See https://aka.ms/new-console-template for more information
Console.OutputEncoding = Encoding.UTF8;

Solution23 solution23 = new Solution23();
Solution24 solution24 = new Solution24();
Solution25 solution25 = new Solution25();
//solution23.GiaiBai23();
//solution24.GiaiBai24();
solution25.GiaiBai25();


DateTime birthDate = new DateTime(2000, 8, 4);
DateTime currentDate = DateTime.Now;

TimeSpan ageSpan = currentDate - birthDate;
int totalDays = (int)ageSpan.TotalDays;

Console.WriteLine($"Số ngày từ lúc sinh ra đến hôm nay là: {totalDays} ngày.");

//int x = 5;
//int y = x++; //y = 5

//int x1 = 5;
//int y1 = ++x1; //y = 6

//Console.WriteLine(y);
//Console.WriteLine(y1);

//int a = 5;
//int b = a;
//a = 10;
//Console.WriteLine(b);

//b = 15;
//Console.WriteLine(a);

//void ThamChieu(out int x)
//{
//    x = 100;
//}
