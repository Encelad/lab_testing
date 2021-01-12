using System;
using Xunit;
using IIG.BinaryFlag;

namespace Lab2
{
    public class UnitTest1
    {
        [Fact]
        public void LongLengthInput()
        {
            MultipleBinaryFlag multipleBinaryFlag1 = new MultipleBinaryFlag(ulong.MaxValue, false);
            MultipleBinaryFlag multipleBinaryFlag2 = new MultipleBinaryFlag(ulong.MaxValue - 1, false);

            Assert.False(multipleBinaryFlag1.GetFlag());
            Assert.False(multipleBinaryFlag2.GetFlag());
        }

        [Fact]
        public void MinimumLengthInput()
        {
            MultipleBinaryFlag multipleBinaryFlag1 = new MultipleBinaryFlag(ulong.MinValue, false);
            MultipleBinaryFlag multipleBinaryFlag2 = new MultipleBinaryFlag(ulong.MinValue + 1, false);

            Assert.False(multipleBinaryFlag1.GetFlag());
            Assert.False(multipleBinaryFlag2.GetFlag());
        }

        [Fact]
        public void ZeroLengthInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(0, false));
        }

        [Fact]
        public void Dispose()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            multipleBinaryFlag.Dispose();

            Assert.Null(multipleBinaryFlag);
        }

        [Fact]
        public void GetFlagAllFalse()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            Assert.False(multipleBinaryFlag.GetFlag());
        }

        [Fact]
        public void GetFlagAllTrue()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, true);

            Assert.True(multipleBinaryFlag.GetFlag());
        }

        [Fact]
        public void SetFlag()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            for (ulong i = 0; i < 10; i++)
            {
                multipleBinaryFlag.SetFlag(i);
            }

            Assert.True(multipleBinaryFlag.GetFlag());
        }

        [Fact]
        public void SetFlagThrowsError()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            Assert.Throws<ArgumentOutOfRangeException>(() => multipleBinaryFlag.SetFlag(10));
        }

        [Fact]
        public void ResetFlag()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, true);

            multipleBinaryFlag.ResetFlag(0);

            Assert.False(multipleBinaryFlag.GetFlag());
        }

        [Fact]
        public void ResetFlagThrowsError()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, true);

            Assert.Throws<ArgumentOutOfRangeException>(() => multipleBinaryFlag.ResetFlag(10));
        }
    }
}
