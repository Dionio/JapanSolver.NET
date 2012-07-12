#define TEST

#if TEST

using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using JapanSolver.Model;
using System.Windows.Forms;

namespace JapanSolver.Tests
{
	[TestFixture]
	public class DigitGroupTest
	{
		[Test]
		public void TestMethod()
		{
			DigitGroup dg = new DigitGroup();
			dg.Add(1);
			dg.Add(3);
			dg.Add(1);
			dg.Add(1);
			Assert.AreEqual(9, dg.MinLength, "DigitGroup's property MinLength works wrong");
		}
		
		[TestFixtureSetUp]
		public void Init()
		{
			// TODO: Add Init code.
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			// TODO: Add tear down code.
		}
	}
}
#endif
