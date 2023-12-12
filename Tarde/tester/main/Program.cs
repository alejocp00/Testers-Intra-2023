
using MatCom.Utils;
using MatCom.Tester;
using System.Diagnostics;

Directory.CreateDirectory(".output");
File.Delete(Path.Combine(".output", "result.md"));
File.WriteAllLines(Path.Combine(".output", "result.md"), new[]
{
    "# Results of MatCom Programming Contest #1",
    "",
    "| Estudiante | Aprobado | Crear Calculadora | Suma | Resta | Multiplicación | División | División por cero | Undo | Múltiples Undo | Redo | Múltiples Redo | Todas las operaciones | Operaciones efectivas |",
    "| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: |  :---: | :---: | :---: | :---: | :---: | :---: |",
});

foreach (var solution in Directory.GetFiles("solutions", "*.cs"))
{
    var oldFiles = Directory
        .EnumerateFiles("tester", "*.*", SearchOption.AllDirectories)
        .Where(f => Path.GetFileName(f) != "tester.csproj")
        .Where(f => Path.GetFileName(f) != "Base.cs")
        .Where(f => Path.GetFileName(f) != "UnitTest.cs")
        .Where(f => Path.GetFileName(f) != "Utils.cs");
    foreach (var oldFile in oldFiles) File.Delete(oldFile);

    File.Copy(solution, Path.Combine("tester", "Solution.cs"));

    var name = Path.GetFileNameWithoutExtension(solution);

    var (student, group) = SplitName(name);

    Console.WriteLine($"--Testing {student}--");

    // Create the argumets for dotnet test, that allow the test run and stop one test passed 2 minutes, but only one test
    var info = new ProcessStartInfo("dotnet", "test --logger trx --blame-hang-timeout 2min");

    var process = Process.Start(info);

    process?.WaitForExit();

    var dict = new Dictionary<TestType, bool>();

    try
    {
        var trx = Directory.GetFiles("tester/TestResults", "*.trx").Single();
        File.Copy(trx, Path.Combine(".output", $"{name}.trx"));
        dict = TestResult.GetResults($".output/{name}.trx");
        // Directory.Delete("Tester/TestResults", true);
    }
    catch
    {
        File.AppendAllLines(Path.Combine(".output", "result.md"), new[]
        {
            $"| {student} | {( "🔴" )} | { "⚠️" } | { "⚠️" } " +
            $"| { "⚠️" } | { "⚠️" } | { "⚠️" } | { "⚠️" } | { "⚠️" } " +
            $"| { "⚠️" } | { "⚠️" } | { "⚠️" } | { "⚠️" } | { "⚠️" } "
        });

        continue;
    }

    File.AppendAllLines(Path.Combine(".output", "result.md"), new[]
    {
        $"| {student} {group}| {( TestResult.IsApproved(dict) ? "🟢" : "🔴" )} " +
        $"| {( dict[TestType.CreateCalculator] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckSum] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckSubtraction] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckMultiplication] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckDivision] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckDivisionByZero] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckUndo] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckMultipleUndo] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckRedo] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckMultipleRedo] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckAllOperations] ? "✅" : "❌" )} " +
        $"| {( dict[TestType.CheckEffectiveOperations] ? "✅" : "❌" )} " +
        $"|"

    });

    File.Delete($".output/{name}.trx");

    Console.WriteLine("--Done--");
}

foreach (var file in Directory.GetFiles("solutions/base", "*.cs"))
{
    File.Copy(file, Path.Combine("tester", Path.GetFileName(file)), true);
}

Directory.GetFiles(".output", "*.trx").ToList().ForEach(File.Delete);

static Tuple<string, string> SplitName(string fileName)
{
    string name = "";
    string group = "";

    for (int i = 0; i < fileName.Length; i++)
    {
        // Verifica si la letra es c
        if ((fileName[i] == 'c' || fileName[i] == 'C') && ((i + 1 < fileName.Length) && (char.IsNumber(fileName[i + 1]) || fileName[i + 1] == '-')))
        {
            group += "C";
        }
        else if (char.IsNumber(fileName[i]))
        {
            group += fileName[i];
        }
        else if (char.IsLetter(fileName[i]))
        {
            if (char.IsUpper(fileName[i]) && name.Length > 0)
            {
                name += " ";
            }
            name += fileName[i];
        }
    }
    return new Tuple<string, string>(name, group);
}