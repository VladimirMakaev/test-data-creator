using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataCreator.Tests
{
    [TestClass]
    public class TestDataTests
    {
        private TestData subject;

        [TestInitialize]
        public void InitializeTest()
        {
            subject = new TestData();
        }

        [TestMethod]
        public void CreateSingle_CircularReferencesForObjectsOneToOne_ReferencesAreSet()
        {
            var root = subject.CreateSingle<Root>();
            Assert.IsNotNull(root, "root object is null");
            Assert.IsNotNull(root.Child, "root.Child is null");
            Assert.AreSame(root, root.Child.Root);
            Assert.AreSame(root.Child, root.Child2.Child1);
            Assert.AreSame(root, root.Child2.Root);
        }

        public void CreateMulti_CircularReferncesForObjectsOneToOne_InstancesAreUniqueForEachRoot()
        {
        }

        public class InnerChild
        {
            public Root Root
            {
                get;
                set;
            }
        }

        public class InnerChild2
        {
            public InnerChild Child1
            {
                get;
                set;
            }

            public Root Root
            {
                get;
                set;
            }
        }

        public class Root
        {
            public InnerChild Child
            {
                get;
                set;
            }

            public InnerChild2 Child2
            {
                get;
                set;
            }
        }
    }
}