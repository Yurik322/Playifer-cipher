//-----------------------------------------------------------------------
// <copyright file="Functions.cs" company="My Company">
//    Created by yurik_322 on 19/11/13.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Def
{
    /// <summary>
    /// functions class
    /// </summary>
    class Functions
    {
        /// <summary>
        /// Reading a file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>read Text</returns>
        public static string ReadFile(string path)
        {
            string text = File.ReadAllText(path);

            return text.ToLower();
        }

        /// <summary>
        /// Writing to a file
        /// </summary>
        /// <param name="str">string from file</param>
        static public void WriteFile(string str)
        {
            using (StreamWriter writer = new StreamWriter("Encoded.txt"))
            {
                writer.WriteLine(str);
            }
        }

        /// <summary>
        /// We take two letters, but when it is an odd word, then we have to add some letter to the last letter so that no one understands, I took 'й'
        /// </summary>
        /// <param name="ch1">first position</param>
        /// <param name="ch2">second position</param>
        /// <returns>returned string</returns>
        public static string GetEncryption(char ch1, char ch2)
        {
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0, pr1 = 0, pr2 = 0;
            int len = Alphabet.n - 1;
            for (int i = 0; i <= len; i++)
            {
                for (int j = 0; j <= len; j++)
                {
                    if (Alphabet.alf[i, j] == ch1)
                    {
                        i1 = i;
                        j1 = j;
                        pr1 = 1;
                    }

                    if (Alphabet.alf[i, j] == ch2)
                    {
                        i2 = i;
                        j2 = j;
                        pr2 = 1;
                    }
                }
            }

            if (pr1 == 0 || pr2 == 0)
            {
                Console.WriteLine("Error!");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                }

                Environment.Exit(1);
            }

            if (i1 != i2 && j1 != j2)
            {
                pr1 = i1;
                i1 = i2;
                i2 = pr1;
            }

            if (i1 == i2 && j1 != j2)
            {
                pr1 = j1;
                j1++;
                j2++;
            }

            if (i1 != i2 && j1 == j2)
            {
                pr1 = i1;
                i1++;
                i2++;
            }

            if (i1 == i2 && j1 == j2)
            {
                j1++;
                j2++;
            }

            if (j2 > len)
            {
                j2 = 0;
            }

            if (j1 > len)
            {
                j1 = 0;
            }

            if (i2 > len)
            {
                i2 = 0;
            }

            if (i1 > len)
            {
                i1 = 0;
            }

            string str = Alphabet.alf[i1, j1].ToString() + Alphabet.alf[i2, j2].ToString();

            return str;
        }

        /// <summary>
        /// Function for get a decryption
        /// </summary>
        /// <param name="ch1">first position</param>
        /// <param name="ch2">second position</param>
        /// <returns>return sting</returns>
        public static string GetDecryption(char ch1, char ch2)
        {
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0, pr;
            int len = Alphabet.n - 1;
            for (int i = 0; i <= len; i++)
            {
                for (int j = 0; j <= len; j++)
                {
                    if (Alphabet.alf[i, j] == ch1)
                    {
                        i1 = i;
                        j1 = j;
                    }

                    if (Alphabet.alf[i, j] == ch2)
                    {
                        i2 = i;
                        j2 = j;
                    }
                }
            }

            if (i1 != i2 && j1 != j2)
            {
                pr = i1;
                i1 = i2;
                i2 = pr;
            }

            if (i1 == i2 && j1 != j2)
            {
                pr = j1;
                j1--;
                j2--;
            }

            if (i1 != i2 && j1 == j2)
            {
                pr = i1;
                i1--;
                i2--;
            }

            if (i1 == i2 && j1 == j2)
            {
                j1--;
                j2--;
            }

            if (j2 < 0)
            {
                j2 = len;
            }

            if (j1 < 0)
            {
                j1 = len;
            }

            if (i1 < 0)
            {
                i1 = len;
            }

            if (i2 < 0)
            {
                i2 = len;
            }

            string str = Alphabet.alf[i1, j1].ToString() + Alphabet.alf[i2, j2].ToString();

            return str;
        }

        /// <summary>
        /// Encryption function
        /// </summary>
        /// <param name="line">string for encryption</param>
        /// <returns>return encryption string</returns>
        public static string EncryptionStr(string line)
        {
            int lengthTxt = line.Length;
            string encryptStr = "";

            for (int i = 0; i < lengthTxt; i += 2)
            {
                if (i == lengthTxt - 1)
                {
                    encryptStr += GetEncryption(line[i], 'i');
                }
                else
                {
                    encryptStr += GetEncryption(line[i], line[i + 1]);
                }
            }

            // Writing to a file:
            using (StreamWriter writer = new StreamWriter("Encoded.txt"))
            {
                writer.WriteLine(encryptStr);
            }

            return encryptStr;
        }

        /// <summary>
        /// Decryption function
        /// </summary>
        /// <param name="line">string for decryption</param>
        /// <returns>return decryption string</returns>
        public static string DecryptionStr(string line)
        {
            int lengthTxt = line.Length;
            string dencryptStr = "";

            for (int i = 0; i < lengthTxt; i += 2)
            {
                dencryptStr += GetDecryption(line[i], line[i + 1]);
            }

            if (dencryptStr[lengthTxt - 1] == 'і')
            { 
                dencryptStr = dencryptStr.Substring(0, lengthTxt - 1);
            }

            // Writing to a file:
            using (StreamWriter writer = new StreamWriter("Decoded.txt"))
            {
                writer.WriteLine(dencryptStr);
            }

            return dencryptStr;
        }
    }
}
