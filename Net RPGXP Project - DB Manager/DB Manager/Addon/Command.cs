using System.Linq;
using System.Text.RegularExpressions;

namespace DB_Manager
{
    class Command
    {
        public Regex formula;

        public Command(string _cmd)
        {
            formula = new Regex(_cmd);
        }

        public bool isMatch(string str) { return formula.IsMatch(str); }
        public string[] MatchData(string str)
        {
            string[] data;
            MatchCollection mc = formula.Matches(str);

            data = new string[mc[0].Groups.Count];

            for (int i = 0; i < data.Length; i++)
                data[i] = mc[0].Groups[i].ToString();

            return data;
        }
    }
}
