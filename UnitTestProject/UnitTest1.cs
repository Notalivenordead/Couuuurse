using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apllication4Course.Views;
using Apllication4Course.ViewModels;
using Apllication4Course.Models;
using Apllication4Course.Services;
using System;
using System.Windows.Controls;

namespace UnitTestProject
{
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
        public void ExsistingUser()
        {
            string login = "head_admin", password = "h272D_Ad!n";
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