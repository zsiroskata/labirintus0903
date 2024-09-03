using lab0903;
LabSim labsim = new("Lab1.txt");

Console.WriteLine("5.feladat");
Console.WriteLine($"oszlopok száma: {labsim.OszlopokSzama}");
Console.WriteLine($"sorok száma: {labsim.SorokSzama}");

Console.WriteLine($"Kijárat " + $"sor index: {labsim.KijaratSorIndex}" + $" oszlop index: {labsim.KijaratOszlopIndex}");

labsim.Utkereses();