using System;
using System.IO;
using System.Linq;

    void gerar()
    {
        int[] numbers = Enumerable.Range(1, 80).ToArray();
        int k = 5;

        var combinations = from n1 in numbers
                           from n2 in numbers
                           from n3 in numbers
                           from n4 in numbers
                           from n5 in numbers
                           where n1 < n2 && n2 < n3 && n3 < n4 && n4 < n5
                           select new { n1, n2, n3, n4, n5 };

        using (StreamWriter writer = new StreamWriter("combinations.txt"))
        {
            int count = 0;
            foreach (var combination in combinations)
            {
                string line = string.Join("-", new[] { combination.n1, combination.n2, combination.n3, combination.n4, combination.n5 }.Select(n => (n - 1).ToString("D2")));
                writer.WriteLine(line);
                count++;
                if (count == 24040016)
                {
                    break;
                }
            }
        }
}
gerar();
