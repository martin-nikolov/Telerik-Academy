using System;

class Laser
{
    static void Main()
    {
        string[] tokens = Console.ReadLine().Split(' ');

        int w = int.Parse(tokens[0]);
        int h = int.Parse(tokens[1]);
        int d = int.Parse(tokens[2]);

        tokens = Console.ReadLine().Split(' ');

        int pW = int.Parse(tokens[0]);
        int pH = int.Parse(tokens[1]);
        int pD = int.Parse(tokens[2]);

        tokens = Console.ReadLine().Split(' ');

        int sW = int.Parse(tokens[0]);
        int sH = int.Parse(tokens[1]);
        int sD = int.Parse(tokens[2]);

        bool[, ,] visited = new bool[w + 1, h + 1, d + 1];

        for (int W = 1; W <= w; W++)
            for (int H = 1; H <= h; H++)
                for (int D = 1; D <= d; D++)
                    if ((W == 1 || W == w) && (H == 1 || H == h || D == 1 || D == d))
                        visited[W, H, D] = true;

        visited[pW, pH, pD] = true;

        while (true)
        {
            int nextW = pW + sW,
                nextH = pH + sH,
                nextD = pD + sD;

            if (nextW > w || nextW <= 0)
            {
                sW = -sW;
                nextW = pW + sW;
            }

            if (nextH > h || nextH <= 0)
            {
                sH = -sH;
                nextH = pH + sH;
            }

            if (nextD > d || nextD <= 0)
            {
                sD = -sD;
                nextD = pD + sD;
            }

            if (visited[nextW, nextH, nextD])
            {
                Console.WriteLine("{0} {1} {2}", pW, pH, pD);
                return;
            }
            else
            {
                visited[nextW, nextH, nextD] = true;

                pW = nextW;
                pH = nextH;
                pD = nextD;
            }
        }
    }
}