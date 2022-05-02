using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthTest;
//using AuthLecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AuthLecture.Controllers;
using AuthTest.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthTest.Tests
{
    [TestClass()]
    public class JwtAuthenticationManagerTests
    {
        [TestMethod()]
        public void AuthenticateTest1()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("darkGustavoMarinBorges");

            User user = new User
            {
                username = "Gustavo",
                password = "EmptyHands"
            };

            Assert.IsNotNull(manager.Authenticate(user.username, user.password));
        }

        [TestMethod()]
        public void AuthenticateTest2()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("darkGustavoMarinBorges");

            User user = new User
            {
                username = "Gustavo",
                password = "EmptyHands"
            };

            var str = manager.Authenticate(user.username,user.password);

            Assert.IsTrue(str is String);
        }

        [TestMethod()]
        public void AuthenticateTest3()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("GustavoMarinBorges");

            User user = new User()
            {
                username = "Gustao",
                password = "EmptyHads"
            };

            var str = manager.Authenticate(user.username, user.password);
            if (!(str is String))
            {
                Assert.ThrowsException<Exception>(() => throw new Exception());
            }
        }

        [TestMethod()]
        public void AuthenticateTest4()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("GustavoMarinBorges");

            User user = new User()
            {
                username = "Gustao",
                password = "EmptyHads"
            };
            User user2 = new User()
            {
                username = "MarinBorges",
                password = "HandsOnFire"
            };

            var str1 = manager.Authenticate(user.username, user.password);
            var str2 = manager.Authenticate(user2.username, user2.password);

            Assert.AreNotEqual(str1, str2);
        }

        [TestMethod()]
        public void AuthenticateTest5()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("GustavoMarinBorges");

            User user = new User()
            {
                username = "Gustao",
                password = "EmptyHads"
            };
            User user2 = new User()
            {
                username = "MarinBorges",
                password = "HandsOnFire"
            };

            var str1 = manager.Authenticate(user.username, user.password);
            var str2 = manager.Authenticate(user2.username, user2.password);

            Assert.ReferenceEquals(str1, str2);
        }
    }
}