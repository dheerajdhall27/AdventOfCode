
var requiredFieldsSet = new HashSet<string>()
{ "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

var passportBatchFile = File.ReadAllText("input.txt");
var passports = passportBatchFile.Split("\n\n");

Console.WriteLine(passports);