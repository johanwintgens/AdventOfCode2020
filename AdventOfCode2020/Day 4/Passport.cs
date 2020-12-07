using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day_4
{
    public class Passport
    {
        public string byr { get; private set; }
        public string iyr { get; private set; }
        public string eyr { get; private set; }
        public string hgt { get; private set; }
        public string hcl { get; private set; }
        public string ecl { get; private set; }
        public string pid { get; private set; }
        public string cid { get; private set; }

        public bool IsValid()
        {
            return CheckNumber(byr, 4, 1920, 2020)
                && CheckNumber(iyr, 4, 2010, 2020)
                && CheckNumber(eyr, 4, 2020, 2030)
                && CheckHeight()
                && CheckHairColor()
                && CheckEyeColor()
                && CheckPID();
        }

        bool CheckNumber(uint number, int minValue, int maxValue)
        {
            return number >= minValue && number <= maxValue;
        }

        bool CheckNumber(string s, uint numOfDigits, int minValue, int maxValue)
        {
            if (!uint.TryParse(s, out var number))
                return false;

            return s.Length == numOfDigits && CheckNumber(number, minValue, maxValue);
        }

        bool CheckHeight()
        {
            if (hgt == null) return false;

            if (hgt.EndsWith("cm"))
            {
                if (!uint.TryParse(hgt.Replace("cm", ""), out var number))
                    return false;

                return CheckNumber(number, 150, 193);
            }

            if (hgt.EndsWith("in"))
            {
                if (!uint.TryParse(hgt.Replace("in", ""), out var number))
                    return false;

                return CheckNumber(number, 59, 76);
            }

            return false;
        }

        bool CheckHairColor()
        {
            if (hcl == null) return false;

            var regex = new Regex($"#[a-z0-9]{{6}}");

            return regex.IsMatch(hcl);
        }

        bool CheckEyeColor()
        {
            switch (ecl)
            {
                default: return false;

                case "amb":
                case "blu":
                case "brn":
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return true;
            }
        }

        bool CheckPID()
        {
            if (!uint.TryParse(pid, out var number)
             || pid.Length != 9)
                return false;

            return true;
        }

        public static Passport FromLine(string line)
        {
            var dic = line.Split(' ')
                          .Select(x => x.Split(':'))
                          .ToDictionary(y => y[0], y => y[1]);

            var passport = new Passport();

            if (dic.ContainsKey("byr"))
                passport.byr = dic["byr"];

            if (dic.ContainsKey("iyr"))
                passport.iyr = dic["iyr"];

            if (dic.ContainsKey("eyr"))
                passport.eyr = dic["eyr"];

            if (dic.ContainsKey("hgt"))
                passport.hgt = dic["hgt"];

            if (dic.ContainsKey("hcl"))
                passport.hcl = dic["hcl"];

            if (dic.ContainsKey("ecl"))
                passport.ecl = dic["ecl"];

            if (dic.ContainsKey("pid"))
                passport.pid = dic["pid"];

            if (dic.ContainsKey("cid"))
                passport.cid = dic["cid"];

            return passport;
        }
    }
}