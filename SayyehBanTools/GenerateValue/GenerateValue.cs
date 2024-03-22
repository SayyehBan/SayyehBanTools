﻿using System.Security.Cryptography;

namespace SayyehBanTools.GenerateValue;

public class GenerateValue
{
    /// <summary>
    /// تولید عدد تصادفی 8 رقمی
    /// </summary>
    /// <returns></returns>
    public static string Generate_Unique_Number()
    {
        var bytes = new byte[4];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
        return String.Format("{0:D8}", random);
    }
   /// <summary>
   /// تولید عدد و حروف تصادفی به تعداد 16 تا
   /// </summary>
   /// <returns></returns>
    public static string Generate16ValueRandome()
    {
        // Create a new Random instance inside the function
        Random rnd = new Random();

        string letters = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "0123456789";
        int length = 16;

        string randomString = "";
        for (int i = 0; i < length; i++)
        {
            int choice = rnd.Next(2);

            if (choice == 0)
            {
                randomString += letters[rnd.Next(letters.Length)];
            }
            else
            {
                randomString += numbers[rnd.Next(numbers.Length)];
            }
        }

        return randomString;
    }
}
