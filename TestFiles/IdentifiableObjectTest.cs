using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class IdentifiableObjectTest
    {

        private IdentifiableObject _testObject;
        private string _testString;

        private IdentifiableObject _testObject_emp;
        private string _testString_emp;

        [SetUp]
        public void Setup()
        {
            _testString = "fred";
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });

            _testString_emp = "";
            _testObject_emp = new IdentifiableObject(new string[] { });
        }

        [Test]
        public void TestAreYou()
        {
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
            _testString = "fred";
            Assert.IsTrue(_testObject.AreYou(_testString));
        }

        [Test]
        public void TestNotAreYou()
        {
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
            _testString = "Boby";
            Assert.IsFalse(_testObject.AreYou(_testString));
        }

        [Test]
        public void Insensitive()
        {
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
            _testString = "BOB";
            Assert.IsTrue(_testObject.AreYou(_testString));
        }

        [Test]
        public void TestFirstId()
        {
            _testObject = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(_testObject.FirstID, Is.EqualTo("fred"));
            Assert.That(_testObject.FirstID, Is.Not.EqualTo("bob"));
        }

        [Test]
        public void TestEmpty()
        {
            Assert.That(_testObject_emp.FirstID, Is.EqualTo(""));
        }
    }
}