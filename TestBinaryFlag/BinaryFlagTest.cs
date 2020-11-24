using System;
using IIG.BinaryFlag;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBinaryFlag
{
    [TestClass]
    public class BinaryFlagTest
    {
        // Test exception throwing if argument 'length' in constructor is less than 2
        [TestMethod]
        public void Test_Constructor_Min_Length_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(1));
        }

        // Test exception throwing if argument 'length' in constructor is bigger than 17179868704
        [TestMethod]
        public void Test_Constructor_Max_Length_Exception()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868705));
        }

        // Test success constructing if argument 'length' in constructor is equal to 2
        [TestMethod]
        public void Test_Constructor_Min_Length_Success()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(2));
        }

        // Test success constructing if argument 'length' in constructor is equal to 17179868704
        [TestMethod]
        public void Test_Constructor_Max_Length_Success()
        {
            Assert.IsNotNull(new MultipleBinaryFlag(17179868704));
        }

        MultipleBinaryFlag mbf1 = new MultipleBinaryFlag(8);
        MultipleBinaryFlag mbf2 = new MultipleBinaryFlag(8, false);
        MultipleBinaryFlag mbf3 = new MultipleBinaryFlag(10);
        MultipleBinaryFlag mbf4 = new MultipleBinaryFlag(8, true);

        // Test that all created MultipleBinaryFlag objects are not null
        [TestMethod]
        public void Test_Flags_Not_Null()
        {
            Assert.IsNotNull(mbf1);
            Assert.IsNotNull(mbf2);
            Assert.IsNotNull(mbf3);
            Assert.IsNotNull(mbf4);
        }

        // Test that all created objects are objects of MultipleBinaryFlag class
        [TestMethod]
        public void Test_GetType()
        {
            Assert.AreEqual(mbf1.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
            Assert.AreEqual(mbf2.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
            Assert.AreEqual(mbf3.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
            Assert.AreEqual(mbf4.GetType().ToString(), "IIG.BinaryFlag.MultipleBinaryFlag");
        }

        // Test that two flags with different arguments while constructing are not equal
        [TestMethod]
        public void Test_Two_Flags_Not_Equal_1()
        {
            Assert.AreNotEqual(mbf1, mbf2);
        }

        // Test that two flags with same arguments while constructing are not equal
        [TestMethod]
        public void Test_Two_Flags_Not_Equal_2()
        {
            Assert.AreNotEqual(mbf1, mbf4);
        }

        // Test that two flags with different argument 'initialValue' while constructing have different states
        [TestMethod]
        public void Test_Two_Flags_Different_State()
        {
            Assert.AreNotEqual(mbf1.GetFlag(), mbf2.GetFlag());
        }

        // Test that two flags with same argument 'initialValue' while constructing have same states
        [TestMethod]
        public void Test_Two_Flags_Same_State()
        {
            Assert.AreEqual(mbf1.GetFlag(), mbf3.GetFlag());
        }

        // Test that flag has false state if only one position is true (through SetFlag method)
        [TestMethod]
        public void Test_SetFlag_One_Position()
        {
            mbf2.SetFlag(3);
            Assert.IsFalse(mbf2.GetFlag());
        }

        // Test that flag has true state if all positions are true (through SetFlag method)
        [TestMethod]
        public void Test_SetFlag_All_Positions()
        {
            for (ulong i = 0; i < 8; i++)
            {
                mbf2.SetFlag(i);
            }
            Assert.IsTrue(mbf2.GetFlag());
        }

        // Test exception throwing if argument 'position' in SetFlag method is bigger than flag length
        [TestMethod]
        public void Test_SetFlag_Out_Of_Range()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mbf2.SetFlag(9));
        }

        // Test that flag has false state if only one position is false (through ResetFlag method)
        [TestMethod]
        public void Test_ResetFlag_One_Position()
        {
            mbf1.ResetFlag(3);
            Assert.IsFalse(mbf1.GetFlag());
        }

        // Test that flag has false state if all positions are false (through ResetFlag method)
        [TestMethod]
        public void Test_ResetFlag_All_Positions()
        {
            for (ulong i = 0; i < 8; i++)
            {
                mbf1.ResetFlag(i);
            }
            Assert.IsFalse(mbf1.GetFlag());
        }

        // Test exception throwing if argument 'position' in ResetFlag method is bigger than flag length
        [TestMethod]
        public void Test_ResetFlag_Out_Of_Range()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mbf1.ResetFlag(9));
        }

        // Test correct output of ToString method
        [TestMethod]
        public void Test_ToString()
        {
            Assert.AreEqual(mbf1.ToString(), "TTTTTTTT");
            Assert.AreEqual(mbf2.ToString(), "FFFFFFFF");
        }

        // Test ToString method output after using of SetFlag method on one position
        [TestMethod]
        public void Test_ToString_After_SetFlag_One_Position()
        {
            mbf2.SetFlag(3);
            Assert.AreEqual(mbf2.ToString(), "FFFTFFFF");
        }

        // Test ToString method output after using of SetFlag method on all positions
        [TestMethod]
        public void Test_ToString_After_SetFlag_All_Positions()
        {
            for (ulong i = 0; i < 8; i++)
            {
                mbf2.SetFlag(i);
            }
            Assert.AreEqual(mbf2.ToString(), "TTTTTTTT");
        }

        // Test ToString method output after using of ResetFlag method on one position
        [TestMethod]
        public void Test_ToString_After_ResetFlag_One_Position()
        {
            mbf1.ResetFlag(3);
            Assert.AreEqual(mbf1.ToString(), "TTTFTTTT");
        }

        // Test ToString method output after using of ResetFlag method on all positions
        [TestMethod]
        public void Test_ToString_After_ResetFlag_All_Positions()
        {
            for (ulong i = 0; i < 8; i++)
            {
                mbf1.ResetFlag(i);
            }
            Assert.AreEqual(mbf1.ToString(), "FFFFFFFF");
        }

        // Test object is null or not null after disposing
        [TestMethod]
        public void Test_Dispose_Not_Null()
        {
            mbf1.Dispose();
            Assert.IsNotNull(mbf1);
        }
    }
}
