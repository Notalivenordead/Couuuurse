﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using Apllication4Course.Models;

namespace Apllication4Course.Services
{
    public class UserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        // Хэширование пароля (Для автотестов сменил на public)
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Проверка логина и пароля
        public bool Authenticate(string login, string password)
        {
            var user = _context.Сотрудники.FirstOrDefault(u => u.Логин.Equals(login, StringComparison.OrdinalIgnoreCase));
            var hashedPassword = HashPassword(password);
            if (user == null || password == null)
            {
                Console.WriteLine("Заполните все поля (логин и пароль)");
                return false;
            }

            if (user.ПарольHash == hashedPassword)
            {
                Console.WriteLine("Пароль совпадает.");
                return true;
            }
            else
            {
                Console.WriteLine("Пароль не совпадает.");
                return false;
            }
        }

        // Регистрация нового пользователя
        public bool Register(Сотрудники user)
        {
            if (_context.Сотрудники.Any(u => u.Логин == user.Логин))
            {
                Console.WriteLine($"такой пользователь уже существует.");
                return false;
            }

            user.ПарольHash = HashPassword(user.ПарольHash);
            _context.Сотрудники.Add(user);
            _context.SaveChanges();
            Console.WriteLine($"Пользователь {user.Логин} успешно зарегистрирован.");
            return true;
        }
    }
}