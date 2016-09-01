using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Test
{
    class Program
    {
        // 아래 solve 함수를 작성하세요.
        // 결과 값이 0이 되도록 고친 계산식을 문자열로 리턴하세요.

        // N은 입력의 개수, numbers에 숫자들이 들어있습니다.

        public string solve(int N, int[] numbers)
        {
            // 여기에 코드를 작성하세요.

            return "1 - 1";
        }
    }

    class Solver                                                                             // stub
    {                                                                                        // stub
        public static void Main(string[] args)                                               // stub
        {                                                                                    // stub
            int N = int.Parse(Console.ReadLine());                                           // stub
            int[] m = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToArray();     // stub
            string ret = new Program().solve(N, m);                                     // stub
            Console.WriteLine(ret);                                                          // stub
        }                                                                                    // stub
    }                                                                                        // stub

}
