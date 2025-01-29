using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StoreTest
{
    [TestClass]
    public class AuthPageTests
    {
        private AuthPage authPage;

        [TestInitialize]
        public void Setup()
        {
            authPage = new AuthPage();
        }

        [TestMethod]
        public void testAuth()
        {
            String s1 = "";
            String s2 = "";

            var result = authPage.ValidateUserCredentials(s1,s2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void testAuth1()
        {
            String s1 = "123";
            String s2 = "222";

            var result = authPage.ValidateUserCredentials(s1, s2);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void testAuth2()
        {
            String s1 = "123";
            String s2 = "123";

            var result = authPage.ValidateUserCredentials(s1, s2);

            Assert.IsNotNull(result);
        }

    }
}