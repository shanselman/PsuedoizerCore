﻿using System;
using System.Text;

namespace Utils
{
    public class Pseudoizer
    {
        public static String ConvertToFakeInternationalized(String inputString)
        {

            //check if the input string is a http or https link... if it is, do not localize
            if (inputString.Contains("http://") || inputString.Contains("https://"))
            {
                return inputString;
            }

            // Calculate the extra space necessary for pseudo
            // internationalization.  The rules, according to "Developing
            // International Software" is that < 10  characters you should grow
            // by 400% while >= 10 characters should grow by 30%.

            int OrigLen = inputString.Length;
            int PseudoLen = 0;
            if (OrigLen < 10)
            {
                PseudoLen = (OrigLen * 4) + OrigLen;
            }
            else
            {
                PseudoLen = ((int)(OrigLen * 0.3)) + OrigLen;
            }

            StringBuilder sb = new StringBuilder(PseudoLen);

            // The pseudo string will always start with a "[" and end
            // with a "]" so you can tell if strings are not built
            // correctly in the UI.
            sb.Append("[");

            bool waitingForEndBrace = false;
            bool waitingForGreaterThan = false;
            foreach (Char currChar in inputString)
            {
                switch (currChar)
                {
                    case '{':
                        waitingForEndBrace = true;
                        break;
                    case '}':
                        waitingForEndBrace = false;
                        break;
                    case '<':
                        waitingForGreaterThan = true;
                        break;
                    case '>':
                        waitingForGreaterThan = false;
                        break;
                }
                if (waitingForEndBrace || waitingForGreaterThan)
                {
                    sb.Append(currChar);
                    continue;
                }
                switch (currChar)
                {
                    case 'A':
                        sb.Append('Å');
                        break;
                    case 'B':
                        sb.Append('ß');
                        break;
                    case 'C':
                        sb.Append('C');
                        break;
                    case 'D':
                        sb.Append('Đ');
                        break;
                    case 'E':
                        sb.Append('Ē');
                        break;
                    case 'F':
                        sb.Append('F');
                        break;
                    case 'G':
                        sb.Append('Ğ');
                        break;
                    case 'H':
                        sb.Append('Ħ');
                        break;
                    case 'I':
                        sb.Append('Ĩ');
                        break;
                    case 'J':
                        sb.Append('Ĵ');
                        break;
                    case 'K':
                        sb.Append('Ķ');
                        break;
                    case 'L':
                        sb.Append('Ŀ');
                        break;
                    case 'M':
                        sb.Append('M');
                        break;
                    case 'N':
                        sb.Append('Ń');
                        break;
                    case 'O':
                        sb.Append('Ø');
                        break;
                    case 'P':
                        sb.Append('P');
                        break;
                    case 'Q':
                        sb.Append('Q');
                        break;
                    case 'R':
                        sb.Append('Ŗ');
                        break;
                    case 'S':
                        sb.Append('Ŝ');
                        break;
                    case 'T':
                        sb.Append('Ŧ');
                        break;
                    case 'U':
                        sb.Append('Ů');
                        break;
                    case 'V':
                        sb.Append('V');
                        break;
                    case 'W':
                        sb.Append('Ŵ');
                        break;
                    case 'X':
                        sb.Append('X');
                        break;
                    case 'Y':
                        sb.Append('Ÿ');
                        break;
                    case 'Z':
                        sb.Append('Ż');
                        break;


                    case 'a':
                        sb.Append('ä');
                        break;
                    case 'b':
                        sb.Append('þ');
                        break;
                    case 'c':
                        sb.Append('č');
                        break;
                    case 'd':
                        sb.Append('đ');
                        break;
                    case 'e':
                        sb.Append('ę');
                        break;
                    case 'f':
                        sb.Append('ƒ');
                        break;
                    case 'g':
                        sb.Append('ģ');
                        break;
                    case 'h':
                        sb.Append('ĥ');
                        break;
                    case 'i':
                        sb.Append('į');
                        break;
                    case 'j':
                        sb.Append('ĵ');
                        break;
                    case 'k':
                        sb.Append('ĸ');
                        break;
                    case 'l':
                        sb.Append('ľ');
                        break;
                    case 'm':
                        sb.Append('m');
                        break;
                    case 'n':
                        sb.Append('ŉ');
                        break;
                    case 'o':
                        sb.Append('ő');
                        break;
                    case 'p':
                        sb.Append('p');
                        break;
                    case 'q':
                        sb.Append('q');
                        break;
                    case 'r':
                        sb.Append('ř');
                        break;
                    case 's':
                        sb.Append('ş');
                        break;
                    case 't':
                        sb.Append('ŧ');
                        break;
                    case 'u':
                        sb.Append('ū');
                        break;
                    case 'v':
                        sb.Append('v');
                        break;
                    case 'w':
                        sb.Append('ŵ');
                        break;
                    case 'x':
                        sb.Append('χ');
                        break;
                    case 'y':
                        sb.Append('y');
                        break;
                    case 'z':
                        sb.Append('ž');
                        break;
                    default:
                        sb.Append(currChar);
                        break;
                }
            }

            // Poke on extra text to fill out the string.
            const String PadStr = " !!!";
            int PadCount = (PseudoLen - OrigLen - 2) / PadStr.Length;
            if (PadCount < 2)
            {
                PadCount = 2;
            }

            for (int x = 0; x < PadCount; x++)
            {
                sb.Append(PadStr);
            }

            // Pop on the trailing "]"
            sb.Append("]");

            return (sb.ToString());
        }
    }
}
