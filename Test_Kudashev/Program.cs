using Test_Kudashev;


ListRandom list = new ListRandom();

for (int i = 0; i<10; i++ ) // создаем список,  заполяем Data 
{   
    list.Add($"Test{i.ToString()}");
}

list.GetRandomLinks(); // заполняем Random



using (var stream = File.Create("Test.dat"))
{
  list.Serialize(stream);
}
Console.WriteLine("Сериализация завершена");
Console.WriteLine(list.SResult);

if (File.Exists("Test.dat"))
{
    using (var stream = File.Open("Test.dat", FileMode.Open))
    {
        list.Deserialize(stream);
    }
}
Console.WriteLine("Десериализация завершена"); 
Console.WriteLine(list.DResult);
Console.ReadLine();