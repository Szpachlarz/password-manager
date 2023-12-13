using PasswordManager.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.WPF.Commands
{
    class GeneratePasswordCommand : ICommand
    {
        internal static char[] chars = "".ToCharArray();
        internal static readonly char[] chars1 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        internal static readonly char[] chars2 = "1234567890".ToCharArray();
        internal static readonly char[] chars3 = "!@#$%^&*()_-+=".ToCharArray();

        internal int size;
        internal bool enableNumbersInGenerator;
        internal bool enableSpecialCharsInGenerator;

        public event EventHandler? CanExecuteChanged;
        public AddRecordViewModel addRecordViewModel;
        public GeneratePasswordCommand(AddRecordViewModel addRecordViewModel)
        {
            this.addRecordViewModel = addRecordViewModel;
        }

        public string GetUniqueKey()
        {
            int charCase = 0;
            if (enableNumbersInGenerator == false && enableSpecialCharsInGenerator == false)
            {
                chars = chars1;
                charCase = 1;
            }
            else if (enableNumbersInGenerator == true && enableSpecialCharsInGenerator == false)
            {
                chars = chars1.Concat(chars2).ToArray();
                charCase = 2;
            }
            else if (enableNumbersInGenerator == false && enableSpecialCharsInGenerator == true)
            {
                chars = chars1.Concat(chars3).ToArray();
                charCase = 3;
            }
            else if (enableNumbersInGenerator == true && enableSpecialCharsInGenerator == true)
            {
                chars = chars1.Concat(chars2).Concat(chars3).ToArray();
                charCase = 4;
            }
            byte[] data = new byte[4 * size];
            bool hasLetters = false;
            bool hasNumbers = false;
            bool hasSpecialChars = false;
            StringBuilder result = new StringBuilder(size);
            while (hasLetters == false || hasNumbers == false || hasSpecialChars == false)
            {
                result.Clear();
                hasLetters = false;
                if (charCase == 1)
                {
                    hasNumbers = true; hasSpecialChars = true;
                }
                else if (charCase == 2)
                {
                    hasNumbers = false; hasSpecialChars = true;
                }
                else if (charCase == 3)
                {
                    hasNumbers = true; hasSpecialChars = false;
                }
                else if (charCase == 4)
                {
                    hasNumbers = false; hasSpecialChars = false;
                }

                using (var crypto = RandomNumberGenerator.Create())
                {
                    crypto.GetBytes(data);
                }
                for (int i = 0; i < size; i++)
                {
                    var rnd = BitConverter.ToUInt32(data, i * 4);
                    var idx = rnd % chars.Length;
                    char currentChar = chars[idx];
                    result.Append(chars[idx]);

                    if (chars1.Contains(currentChar)) hasLetters = true;
                    else if (Char.IsDigit(currentChar)) hasNumbers = true;
                    else if (chars3.Contains(currentChar)) hasSpecialChars = true;
                }
            }
            Console.WriteLine(result);
            return result.ToString();
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            size = 8;
            enableNumbersInGenerator = addRecordViewModel.IsNumber;
            enableSpecialCharsInGenerator = addRecordViewModel.IsSpecial;
            addRecordViewModel.Password = GetUniqueKey();
        }
    }
}
