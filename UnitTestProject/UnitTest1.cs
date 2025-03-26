using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Apllication4Course.Views;
using Apllication4Course.ViewModels;
using Apllication4Course.Models;
using Apllication4Course.Services;
using System;
using System.Windows.Controls;
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
            // Arrange
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
            Assert.AreEqual(1, res);
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
            Assert.AreEqual(1, res);
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
            Assert.AreEqual(-4, res);
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
            Assert.AreEqual(-4, res);
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
            Assert.AreEqual(-4, res);
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
            Assert.AreEqual(1, res);
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
            Assert.AreEqual(1, res);
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
            Assert.AreEqual(-1, res);
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
            Assert.AreEqual(-1, res);
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
            Assert.AreEqual(-2, res);
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
            Assert.AreEqual(-3, res);
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
            Assert.AreEqual(-3, res);
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
            Assert.AreEqual(-3, res);
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
            Assert.AreEqual(-3, res);
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
            // Arrange
            string login = "head_admin", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_2()
        {
            // Arrange
            string login = "general_manager", password = "g272L_mAn!r";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_3()
        {
            // Arrange
            string login = "deputy_head", password = "d27P2y_h56D!a";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_4()
        {
            // Arrange
            string login = "head_pathologist", password = "h272D_pA9843o!s";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void ExsistingUser_5()
        {
            // Arrange
            string login = "head_assistant", password = "h272D_As63is!t";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 1);

        }

        [TestMethod]
        public void LostLogin()
        {
            // Arrange
            string login = "", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void BadLogin()
        {
            // Arrange
            string login = "1231231323121221212", password = "h272D_Ad!n";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void LostPass()
        {
            // Arrange
            string login = "head_admin", password = "";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void BadPass()
        {
            // Arrange
            string login = "head_admin", password = "12_+-PPPooodd_=12";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void NotExsistingUser()
        {
            string login = "head_admin87878", password = "h272D_Ad!n89898";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void SpacesCheck()
        {
            // Arrange
            string login = "", password = "";
            Console.WriteLine($"Testing with Login: {login}, Password: {password}");

            // Act
            int res = ToLogin(login, password);

            // Assert
            Assert.AreEqual(res, -1);
        }
    }


    [TestClass]
    public class CapchaUnitTest
    {
        public int CheckUpInput(string inserted_capcha, string text_capcha, int mistakes = 0)
        {
            var page = new LoginViewModel();
            int res = page.CapchaValidate(inserted_capcha, text_capcha, mistakes);
            return res;
        }

        [TestMethod]
        public void GoodCapchaInsert()
        {
            // Arrange
            string i_cap = "qwT563", t_cap = "qwT563";
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}");

            // Act
            int res = CheckUpInput(i_cap, t_cap);

            // Assert
            Assert.AreEqual(res, 1);
        }

        [TestMethod]
        public void CapchaGenerationTrouble()
        {
            // Arrange
            string i_cap = "qwT563", t_cap = "";
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}");

            // Act
            int res = CheckUpInput(i_cap, t_cap);

            // Assert
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void BadCapchaInsert()
        {
            // Arrange
            string i_cap = "QwT563", t_cap = "qwT563";
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}");

            // Act
            int res = CheckUpInput(i_cap, t_cap);

            // Assert
            Assert.AreEqual(res, -2);
        }

        [TestMethod]
        public void TooManyAptemptsCapchaInsert_1()
        {
            // Arrange
            string i_cap = "QwT563", t_cap = "qwT563";
            int mistakes = 3;
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}, mistakes: {mistakes}");

            // Act
            int res = CheckUpInput(i_cap, t_cap, mistakes);

            // Assert
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void TooManyAptemptsCapchaInsert_2()
        {
            // Arrange
            string i_cap = "QwT563", t_cap = "qwT563";
            int mistakes = 100;
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}, mistakes: {mistakes}");

            // Act
            int res = CheckUpInput(i_cap, t_cap, mistakes);

            // Assert
            Assert.AreEqual(res, -1);
        }

        [TestMethod]
        public void NotTooManyAptemptsCapchaInsert_1()
        {
            // Arrange
            string i_cap = "QwT563", t_cap = "qwT563";
            int mistakes = 1;
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}, mistakes: {mistakes}");

            // Act
            int res = CheckUpInput(i_cap, t_cap, mistakes);

            // Assert
            Assert.AreEqual(res, -2);
        }

        [TestMethod]
        public void NotTooManyAptemptsCapchaInsert_2()
        {
            // Arrange
            string i_cap = "QwT563", t_cap = "qwT563";
            int mistakes = 2;
            Console.WriteLine($"Testing with inserted_capcha: {i_cap}, text_capcha: {t_cap}, mistakes: {mistakes}");

            // Act
            int res = CheckUpInput(i_cap, t_cap, mistakes);

            // Assert
            Assert.AreEqual(res, -2);
        }
    }
}