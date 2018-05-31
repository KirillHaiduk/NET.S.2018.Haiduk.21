using System;
using BLL.Interface.Services;

namespace BLL.Services
{
    public class StandartAccountNumberGenerator : IAccountNumberGenerator
    {
        public int GenerateNewAccountNumber()
        {
            Random random = new Random();
            return random.Next(1, 1000);
        }
    }
}
