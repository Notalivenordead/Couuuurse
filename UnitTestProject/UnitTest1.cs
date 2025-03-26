using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Apllication4Course.Views;
using Apllication4Course.ViewModels;
using Apllication4Course.Models;
using Apllication4Course.Services;
using System;
using System.Windows.Controls;
using Moq;
using System.Linq;
using System.Security.Policy;

namespace UnitTestProject
{
    [TestClass]
    public class RegisterViewModelTests : IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly UserService _userService;
        private readonly RegisterViewModel _viewModel;

        public RegisterViewModelTests()
        {
            _context = DatabaseContext.Instance;
            _userService = new UserService(_context);
            _viewModel = new RegisterViewModel(_userService);
            _context.Database.BeginTransaction();
        }
        [TestMethod]
        public void CheckRegister_SuccessfulRegistration()
        {
            // Arrange
            string login = "lab_tech", password = "L01-b_T272!ch", lastname = "Морозов", firstname = "Игорь", position = "Лаборант",
                phone = "+70084091111", fathername = "Демидович", email = "IDMoroz@mail.com";

            Console.WriteLine($"Testing with Login: {login}, Password: {password}, LN: {lastname}," +
                $" SN: {firstname}, pos: {position}, phone: {phone}, FN: {fathername}, email: {email}");

            // Act
            int result = ToReg(login, password, lastname, firstname, position, phone, fathername, email);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CheckRegister_UserAlreadyExists()
        {

            string login = "head_admin", password = "h272D_Ad!n", lastname = "Топазов", firstname = "Артём", position = "Администратор",
             phone = "+79804368641", fathername = "Григорьевич", email = "efrem3839@gmail.com";

            Console.WriteLine($"Testing with Login: {login}, Password: {password}, LN: {lastname}," +
                $" SN: {firstname}, pos: {position}, phone: {phone}, FN: {fathername}, email: {email}");

            // Act
            int result = ToReg(login, password, lastname, firstname, position, phone, fathername, email);

            // Assert
            Assert.AreEqual(-5, result);
        }
        [TestMethod]
        public void GoodFullRegOrCheckTheReg()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "Демидович", pos = "Лаборант", ph = "+70084091111", em = "IDMoroz@mail.com";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(1, res); // Успешная регистрация
        }

        [TestMethod]
        public void GoodMainReg()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(1, res); // Успешная регистрация (без отчества и email)
        }

        [TestMethod]
        public void BadPhomeReg_1()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "88888888888888", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-4, res); // Неверный формат телефона
        }

        [TestMethod]
        public void BadPhomeReg_2()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+78888888888888898989", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-4, res); // Неверный формат телефона
        }

        [TestMethod]
        public void BadPhomeReg_3()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+788", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-4, res); // Неверный формат телефона
        }

        [TestMethod]
        public void GoodNoMailReg()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "Демидович", pos = "Лаборант", ph = "+70084091111", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(1, res); // Успешная регистрация (без email)
        }

        [TestMethod]
        public void GoodNoMidnameReg()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmail.com";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(1, res); // Успешная регистрация (без отчества)
        }

        [TestMethod]
        public void NullCheckReg()
        {
            // Arrange
            string un = "", ps = "", ln = "", fn = "",
                mn = "", pos = "Лаборант", ph = "", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-1, res); // Пустые поля
        }

        [TestMethod]
        public void SpacesCheckReg()
        {
            // Arrange
            string un = " ", ps = " ", ln = " ", fn = " ",
                mn = " ", pos = "Лаборант", ph = " ", em = " ";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-1, res); // Пустые поля (только пробелы)
        }

        [TestMethod]
        public void EasyPassReg()
        {
            // Arrange
            string un = "lab_tech", ps = "lab_tech123", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-2, res); // Слабый пароль
        }

        [TestMethod]
        public void WrMailReg_1()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony.gmail.com";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-3, res); // Неверный формат email
        }

        [TestMethod]
        public void WrMailReg_2()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmailcom";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-3, res); // Неверный формат email
        }

        [TestMethod]
        public void WrMailReg_3()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "@gmail.com";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-3, res); // Неверный формат email
        }

        [TestMethod]
        public void WrMailReg_4()
        {
            // Arrange
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                 mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmail";

            Console.WriteLine($"Testing with Login: {un} , Password:  {ps}, LN: {ln}," +
                $" SN: {fn}, pos: {pos}, phone: {ph}, FN: {mn}, email: {em}");

            // Act
            int res = ToReg(un, ps, ln, fn, pos, ph, mn, em);

            // Assert
            Assert.AreEqual(-3, res); // Неверный формат email
        }

        public void Dispose() => _context.Database.CurrentTransaction?.Rollback();

        private int ToReg(string login, string password, string lastname, string firstname, string position, string phone, string fathername,
            string email) => _viewModel.CheckRegister(login, password, lastname, firstname, position, phone, fathername, email);
    }


    [TestClass]
    public class AuthUnitTest
    {
        public int ToLogin(string userName, string password)
        {
            Console.WriteLine($"ToLogin called with Login: {userName}, Password: {password}");
            var page = new LoginViewModel();
            int res = page.CanLoginExecute2(userName, password);
            return res;
        }

        [TestMethod]
        public void ExsistingUser_1()
        {
            string login = "head_admin", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_2()
        {
            string login = "general_manager", password = "g272L_mAn!r";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_3()
        {
            string login = "deputy_head", password = "d27P2y_h56D!a";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_4()
        {
            string login = "head_pathologist", password = "h272D_pA9843o!s";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_5()
        {
            string login = "head_assistant", password = "h272D_As63is!t";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void LostLogin()
        {
            string login = "", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void BadLogin()
        {
            string login = "1231231323121221212", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void LostPass()
        {
            string login = "head_admin", password = "";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void BadPass()
        {
            string login = "head_admin", password = "12_+-PPPooodd_=12";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void NotExsistingUser()
        {
            string login = "head_admin87878", password = "h272D_Ad!n89898";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void SpacesCheck()
        {
            string login = "", password = "";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");
            int res = ToLogin(login, password);
            Assert.AreEqual(res, -1);
        }
    }


    /* NotWorking
    [TestClass]
    public class RegUnitTest
    {
        public int ToReg(string userName, string password,
            string lastname, string firstname, string position,
            string phone, string fathername, string email)
        {
            var page = new RegisterViewModel();
            int res = CheckRegister(userName, password, lastname,
                firstname, position, phone, fathername, email);
            return res;
        }

        [TestMethod]
        public void GoodFullRegOrCheckTheReg()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "Демидович", pos = "Лаборант", ph = "+70084091111", em = "IDMoroz@mail.com";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, 1);
            Assert.AreEqual(res, -5);
        }

        [TestMethod]
        public void GoodMainReg()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, 1);
            Assert.AreEqual(res, -5);
        }

        [TestMethod]
        public void BadPhomeReg_1()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "88888888888888", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -4);
        }

        [TestMethod]
        public void BadPhomeReg_2()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+78888888888888898989", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -4);
        }

        [TestMethod]
        public void BadPhomeReg_3()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+788", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -4);
        }

        [TestMethod]
        public void GoodNoMailReg()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "Демидович", pos = "Лаборант", ph = "+70084091111", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, 1);
            Assert.AreEqual(res, -5);
        }

        [TestMethod]
        public void GoodNoMidnameReg()
        {
            string un = "lab_tech", ps = "L01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmail.com";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, 1);
            Assert.AreEqual(res, -5);
        }

        [TestMethod]
        public void NullCheckReg()
        {
            string un = "", ps = "", ln = "", fn = "",
                mn = "", pos = "Лаборант", ph = "", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void SpacesCheckReg()
        {
            string un = " ", ps = " ", ln = " ", fn = " ",
                mn = " ", pos = "Лаборант", ph = " ", em = " ";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void EasyPassReg()
        {
            string un = "lab_tech", ps = "lab_tech123", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -2);
        }

        [TestMethod]
        public void WrMailReg_1()
        {
            string un = "lab_tech", ps = "l01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony.gmail.com";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -3);
        }

        [TestMethod]
        public void WrMailReg_2()
        {
            string un = "lab_tech", ps = "l01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmailcom";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -3);
        }

        [TestMethod]
        public void WrMailReg_3()
        {
            string un = "lab_tech", ps = "l01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "@gmail.com";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -3);
        }

        [TestMethod]
        public void WrMailReg_4()
        {
            string un = "lab_tech", ps = "l01-b_T272!ch", ln = "Морозов", fn = "Игорь",
                mn = "", pos = "Лаборант", ph = "+70084091111", em = "antony@gmail";
            int res = ToReg(un, ps, ln, fn, ps, ph, mn, em);
            Assert.AreEqual(res, -3);
        }
    }
    */
}