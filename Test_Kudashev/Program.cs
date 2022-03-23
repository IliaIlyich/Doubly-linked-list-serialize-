using Test_Kudashev;
ListRandom list = new ListRandom();

for (int i = 0; i<10; i++ )
{   
    list.Add($"Test - {i.ToString()}");
}

using (var stream = File.Create("Test.dat"))
{
  list.Serialize(stream);
}


if (File.Exists("Test.dat"))
{
    using (var stream = File.Open("Test.dat", FileMode.Open))
    {
        list.Deserialize(stream);
    }
}
Console.WriteLine("Десериализация завершена");
Console.ReadLine();