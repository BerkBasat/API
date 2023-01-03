using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() => new() {
                new User
                {
                    Name = "Test1",
                    Email = "test1@gmail.com",
                    Address = new Address()
                    {
                        Street = "Test",
                        City = "Istanbul",
                        ZipCode = "34841"
                    }
                },
                new User
                {
                    Name = "Test2",
                    Email = "test2@gmail.com",
                    Address = new Address()
                    {
                        Street = "Test",
                        City = "Istanbul",
                        ZipCode = "34841"
                    }
                },
                new User
                {
                    Name = "Test3",
                    Email = "test3@gmail.com",
                    Address = new Address()
                    {
                        Street = "Test",
                        City = "Istanbul",
                        ZipCode = "34841"
                    }
                },
            };
    }
}
