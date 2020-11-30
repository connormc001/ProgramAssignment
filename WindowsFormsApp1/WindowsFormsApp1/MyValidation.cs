using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MyValidation
    {
        public static bool validLength(string txt, int min, int max)
        {
            bool ok = true;
            if (string.IsNullOrEmpty(txt))
                ok = false;
            else if (txt.Length < min || txt.Length > max)
                ok = false;
            return ok;
        }



        public static bool ValidNumber(string txt)
        {
            bool ok = true;
            for (int x = 0; x < txt.Length; x++)
            {
                if (!(char.IsNumber(txt[x])))
                {
                    ok = false;
                }

            }
            return ok;
        }
        public static bool validLetter(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsNumber(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }
        public static bool validLetterWhitespace(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }
        public static bool validLetterNumberWhitespace(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(char.IsNumber(txt[x])))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validForename(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validSurname(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validMachineName(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validPartDesc(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }

        public static bool validEmail(string txt)
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsNumber(txt[x])) && !((txt[x].Equals('@'))) && !((txt[x].Equals('-'))) && !((txt[x].Equals('_')))
                        && !((txt[x].Equals('.'))))
                    {
                        ok = false;
                    }

                }


            }
            return ok;
        }
        public static bool validDogColour(string txt) //kept because will probs use later 
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !((txt[x].Equals('@'))) && !((txt[x].Equals('-'))) && !((txt[x].Equals(' ')))
                         && !((txt[x].Equals('/'))))
                    {
                        ok = false;
                    }

                }
            }
            return ok;
        }

        public static bool validDogDOB(string txt)//kept because will probs use later 
        {
            DateTime currentDate = DateTime.Now;
            DateTime dogDOB = Convert.ToDateTime(txt);

            TimeSpan t = currentDate - dogDOB;
            double NoOfDays = t.TotalDays;
            bool ok = true;

            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                if (NoOfDays <= 56)
                    ok = false;
            }
            return ok;
        }

        public static bool validDogDOB2(DateTime dogDOB) //kept because will probs use later 
        {
            DateTime currentDate = DateTime.Now;

            TimeSpan t = currentDate - dogDOB;
            double NoOfDays = t.TotalDays;

            bool ok = true;
            if (NoOfDays <= 56)
                ok = false;

            return ok;
        }

        public static String firstLetterEachWordToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            if (Char.IsLower(array[0]))
            {
                array[0] = Char.ToUpper(array[0]);
            }
            // go through array and check for spaces. Make sure any lowercase letters after a space uppercase

            for (int x = 1; x < array.Length; x++)
            {
                if (array[x - 1] == ' ')
                {
                    if (Char.IsLower(array[x]))
                    {
                        array[x] = Char.ToUpper(array[x]);
                    }

                }

                else
                    array[x] = Char.ToLower(array[x]);
            }

            return new String(array);
        }

        public static String EachLetterToUpper(String word)
        {
            Char[] array = word.ToCharArray();

            for (int x = 0; x < array.Length; x++)
            {
                if (Char.IsLower(array[x]))
                {
                    array[x] = Char.ToUpper(array[x]);
                }
            }
            return new string(array);
        }
        ///////////////////////////////////////////////////
        public static bool validDogname(string txt) //kept because will probs use later 
        {
            bool ok = true;
            if (txt.Trim().Length == 0)
            {
                ok = false;
            }
            else
            {
                for (int x = 0; x < txt.Length; x++)
                {
                    if (!(char.IsLetter(txt[x])) && !(char.IsWhiteSpace(txt[x])) && !(txt[x].Equals('-')))
                        ok = false;
                }
            }
            return ok;
        }
    }
}

