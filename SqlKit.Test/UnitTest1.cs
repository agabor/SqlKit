using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SqlKit.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var table = new Table
            {
                Name = "Persons",
                Columns = new List<Column> {
                    new Column {
                        Name = "PersonID",
                        Type = "int"
                    },
                    new Column {
                        Name = "LastName",
                        Type = "varchar(255)"
                    },
                    new Column {
                        Name = "FirstName",
                        Type = "varchar(255)"
                    },
                    new Column {
                        Name = "Address",
                        Type = "varchar(255)"
                    },
                    new Column {
                        Name = "City",
                        Type = "varchar(255)"
                    },
                }
            };
            AssertScriptEqual(
                @"CREATE TABLE Persons (
                    PersonID int,
                    LastName varchar(255),
                    FirstName varchar(255),
                    Address varchar(255),
                    City varchar(255)
                );",
                table.CreateTableStatement);
        }
        private void AssertScriptEqual(string a, string b)
        {
            Assert.AreEqual(FormatScript(a), FormatScript(b));
        }
        private string FormatScript(string a)
        {
            return Regex.Replace(a.Replace("(", " ( ").Replace(")", " ) ").Replace(",", " , ").Replace(";", " ; "), @"\s+", " ");
        }

    }
}
