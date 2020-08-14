using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechElevator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Exercises.Tests;

namespace TechElevator.Classes.Tests
{
    [TestClass()]
    public class DogTests
    {
        private Type type;
        private Dog dog;

        [TestInitialize]
        public void Before()
        {
            type = typeof(Dog);
            dog = (Dog)Activator.CreateInstance(type);
        }

        [TestMethod]
        public void Dog_IsSleepingProperty()
        {
            PropertyInfo prop = type.GetProperty("IsSleeping");
            PropertyValidator.ValidateReadOnly(prop, "IsSleeping", typeof(bool));
        }

        [TestMethod]
        public void Dog_MakeSoundMethod()
        {
            MethodInfo mi = type.GetMethod("MakeSound");
            Assert.IsNotNull(mi, "Dog class needs the MakeSound method.");
            Assert.AreEqual(typeof(string), mi.ReturnType, "MakeSound() method needs to return type: string");
        }

        [TestMethod]
        public void Dog_SleepMethod()
        {
            MethodInfo mi = type.GetMethod("Sleep");
            Assert.IsNotNull(mi, "Dog class needs the Sleep() method.");
            Assert.AreEqual(typeof(void), mi.ReturnType, "Sleep() method needs to return type: void");
        }

        [TestMethod]
        public void Dog_WakeUpMethod()
        {
            MethodInfo mi = type.GetMethod("WakeUp");
            Assert.IsNotNull(mi, "Dog class needs the WakeUp() method.");
            Assert.AreEqual(typeof(void), mi.ReturnType, "WakeUp() method needs to return type: void");
        }



        [TestMethod()]
        public void Dog_DefaultTest()
        {
            PropertyInfo pi = type.GetProperty("IsSleeping");
            Assert.AreEqual(false, pi.GetValue(dog), "New dogs should be awake by default");
        }

        [TestMethod()]
        public void Dog_MakeSound()
        {
            MethodInfo mi = type.GetMethod("MakeSound");
            Assert.AreEqual("Woof!", mi.Invoke(dog, null), "The dog should say \"Woof!\" when awake.");

            type.GetProperty("IsSleeping").SetValue(dog, true);

            Assert.AreEqual("Zzzzz...", mi.Invoke(dog, null), "The dog should say \"Zzzzz...\" when asleep.");
        }

        [TestMethod]
        public void Dog_SleepTest()
        {
            type.GetMethod("Sleep").Invoke(dog, null);

            Assert.AreEqual(true, type.GetProperty("IsSleeping").GetValue(dog), "The dog should be sleeping after Sleep() is called.");

        }



        [TestMethod()]
        public void Dog_WakeUpTest()
        {
            type.GetProperty("IsSleeping").SetValue(dog, true);

            type.GetMethod("WakeUp").Invoke(dog, null);

            Assert.AreEqual(false, type.GetProperty("IsSleeping").GetValue(dog), "The dog should be awake after WakeUp() is called.");
        }
    }
}