using System.Runtime.CompilerServices;

namespace lab0903
{
    internal class LabSim
    {
        private List<string> adatsorok = [];
        private char[,] lab;
        public int SorokSzama => adatsorok.Count;
        public int OszlopokSzama => adatsorok[0].Length;
        public int KijaratOszlopIndex=> OszlopokSzama - 1;
        public int KijaratSorIndex => SorokSzama - 2;
        public void AdatsorokBeolvasasa(string forras)
        {
            using StreamReader sr = new(forras);

            while (!sr.EndOfStream)
            {
                adatsorok.Add(sr.ReadLine());
            }
        }

        //mátrix
        public void LabFeltoltese() 
        {
            for (int s = 0; s < adatsorok.Count; s++)
            {
                for (int o = 0; o < adatsorok[s].Length; o++)
                {
                    lab[s, o] = adatsorok[s][o];
                }
            }
        }

        public void LabKiir()
        {
            for (int s = 0; s < lab.GetLength(0); s++)
            {
                for(int o = 0;o < lab.GetLength(1); o++)
                {
                    if (lab[s, o] == '-') Console.ForegroundColor = ConsoleColor.Red;
                    if (lab[s, o] == 'O') Console.ForegroundColor = ConsoleColor.Yellow;
                    if (lab[s, o] == 'X') Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(lab[s, o]);
                }
                Console.Write("\n");
            }
        }
        public void Utkereses()
        {
            bool keresesKesz = false;
            bool nincsMegoldas = false;

            int r = 1;
            int c = 0;

            while (!keresesKesz && !nincsMegoldas)
            {
                Console.Clear();
                lab[r, c] = 'O';
                if (lab[r, c + 1] == ' ') c++;
                else if (lab[r + 1, c] == ' ') r++;
                else
                {
                    lab[r, c] = '-';
                    if (lab[r, c - 1] == 'O') c--;
                    else r--;
                }
                keresesKesz = r == KijaratSorIndex && c == KijaratOszlopIndex;
                if (keresesKesz) lab[r, c] = 'O';
                nincsMegoldas = r ==1 && c == 0;
                LabKiir();
                Thread.Sleep(100);
            }
            Console.WriteLine($"\n\n {(nincsMegoldas ? "nincs megoldás" : "van megoldás")}");
        }

        public LabSim(string fileName)
        {
            AdatsorokBeolvasasa (new(@$"..\..\..\src\{fileName}"));
            lab = new char[SorokSzama, OszlopokSzama];
            LabFeltoltese();
        }
        
    }
}
