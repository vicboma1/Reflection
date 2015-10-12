using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class ReflectionTest
    {        
        [TestMethod]
        public void TestInstancePropertyPublic()
        {
            var foo = new Foo();
            var version = Reflection<String>.GetInstanceProperty(foo, Foo._Version);
            Assert.AreEqual(version, foo.Version);
        }

        [TestMethod]
        public void TestInstancePropertyNoPublic()
        {
            var foo = new Foo();
            var version = Reflection<String>.GetInstanceProperty(foo, Foo._NoPublicVersion);
            Assert.AreEqual(version, Foo.VersionNoPublic);
        }


        [TestMethod]
        public void TestInstancePropertyStaticPublic()
        {
            var foo = new Foo();
            var version = Reflection<String>.GetInstanceProperty(foo, Foo._VersionStatic);
            Assert.AreEqual(version, Foo.VersionStatic);
        }

        [TestMethod]
        public void TestInstanceField()
        {
            var foo = new Foo();
            var instance = Reflection<Foo>.GetInstanceField(foo, Foo.instanceToString);
            Assert.AreEqual(instance, foo.instance);
        }

        [TestMethod]
        public void TestInstancePrivateField()
        {
            var foo = new Foo();
            var instance = Reflection<Foo>.GetInstanceField(foo, Foo.noPublicInstanceToString);
            Assert.AreEqual(instance, foo);
        }

        [TestMethod]
        public void TestInstanceStaticField()
        {
            var foo = new Foo();
            var instance = Reflection<Foo>.GetInstanceField(foo, Foo.instanceStaticToString);
            Assert.AreEqual(instance, Foo.instanceStatic);
        }

        [TestMethod]
        public void TestCreateInstanceDefaultExpressionLambda()
        {
            var instance = Reflection<Foo>.CreateInstanceDefaultExpressionLambda(typeof(Foo));
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }

        [TestMethod]
        public void TestCreateActivatorInstance()
        {
            var instance = Reflection<Foo>.CreateActivatorInstance(typeof(Foo));
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }

        [TestMethod]
        public void TestCreateInstanceConstructor()
        {
            var instance = Reflection<Foo>.CreateInstanceConstructor(typeof(Foo));
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }

        [TestMethod]
        public void TestCreateInstanceConstructornamespace()
        {
            var instance = Reflection<Foo>.CreateActivatorInstance("UnitTestProject1.Foo");
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }

        [TestMethod]
        public void TestCreateInstanceConstructorWithParams()
        {
            var instance = Reflection<Foo>.CreateInstanceConstructor(typeof(Foo),new Type[]{typeof(Boolean)}, new Object[]{true});
            Assert.IsInstanceOfType(instance, typeof(Foo));
            Assert.IsTrue(instance.State);
        }

        [TestMethod]
        public void TestCreateActivatorInstanceWithParams()
        {
            var instance = Reflection<Foo>.CreateActivatorInstance(typeof(Foo), new Object[]{true});
            Assert.IsInstanceOfType(instance, typeof(Foo));
        }
    }

    
}
