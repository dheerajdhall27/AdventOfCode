
using System.Text.RegularExpressions;

var requiredFieldsSet = new HashSet<string>()
{ "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

var passportBatchFile = File.ReadAllText("input.txt");
var passports = passportBatchFile.Split("\r\n\r\n");


int validCount = 0;
foreach(var passport in passports)
{
    if(PassportHasAllFields(passport))
    {
        validCount++;
    }
}

bool PassportHasAllFields(string passport)
{
    var passportDetails = passport.Replace("\r\n", " ");

    var passportFields = passportDetails.Split(" ").Select(x => x.Split(":")[0]).ToHashSet();

    foreach (var field in requiredFieldsSet)
    {
        if (!passportFields.Contains(field))
        {
            if (field != "cid")
            {
                return false;
            }
        }
    }

    return true;
}


int validPassportCount = 0;
foreach(var passport in passports)
{
    if(PassportHasAllFields(passport))
    {
        var dictionary = passport.Replace("\r\n", " ").Split(" ").Select(x => x.Split(":")).ToDictionary(x => x[0], x => x[1]);

        bool isValid = true;
        foreach(var field in dictionary)
        {
            if (!IsPassportValueValid(field.Key, field.Value))
            {
                isValid = false;
                break;
            }
        }

        if(isValid)
        {
            validPassportCount++;
        }
    }
}

Console.WriteLine(validPassportCount);

bool IsPassportValueValid(string field, string value)
{
    switch(field)
    {
        case "byr":
            if (value.Length > 4) return false;

            int year = Convert.ToInt32(value);

            return IsYearInRange(year, 1920, 2002);
        case "iyr":
            if (value.Length > 4) return false;

            int iYear = Convert.ToInt32(value);

            return IsYearInRange(iYear, 2010, 2020);
        case "eyr":
            if (value.Length > 4) return false;

            int eYear = Convert.ToInt32(value);

            return IsYearInRange(eYear, 2020, 2030);
        case "hgt":
            Regex inchesRegex = new Regex(@"^[0-9]{2}in$");
            Regex cmRegex = new Regex(@"^[0-9]{3}cm$");
            if (!inchesRegex.IsMatch(value) && !cmRegex.IsMatch(value))
            {
                return false;
            }

            if(value.Contains("in"))
            {
                var height = Convert.ToInt32(value.Replace("in", ""));

                return height >= 59 && height <= 76;
            }
            else
            {
                var height = Convert.ToInt32(value.Replace("cm", ""));

                return height >= 150 && height <= 193;
            }
        case "hcl":
            Regex regexHcl = new Regex(@"^#[0-9a-f]{6}$");
            return regexHcl.IsMatch(value);
        case "ecl":
            var eyeColorHashSet = new HashSet<string>()
            { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            return eyeColorHashSet.Contains(value);
        case "pid":
            Regex passportRegex = new Regex(@"^[0-9]{9}$");

            return passportRegex.IsMatch(value);
        default:
            return true;
    }
}

bool IsYearInRange(int year, int min, int max)
{
    return year >= min && year <= max;
}