using System.Collections.Generic;
using System.Linq;

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
            return !string.IsNullOrWhiteSpace(byr)
                && !string.IsNullOrWhiteSpace(iyr)
                && !string.IsNullOrWhiteSpace(eyr)
                && !string.IsNullOrWhiteSpace(hgt)
                && !string.IsNullOrWhiteSpace(hcl)
                && !string.IsNullOrWhiteSpace(ecl)
                && !string.IsNullOrWhiteSpace(pid);
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