using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	internal class InputTest{

		public InputReader inputReader;
		public bool wascalled;
		InputGenerator generator;

		[SetUp]
		public void SetUp(){
			wascalled = false;
			inputReader = new InputReader ();
			generator = Substitute.For<InputGenerator> ();
			inputReader.SetGenerator (generator);
		}

		[Test]
		public void TestIsDoingLongPress(){
			generator.GeneratedLongPress ().Returns (true);
			inputReader.LongPressExecuted += HandleActionExecuted;
			AssertActionWasCalled ();
		}

		[Test]
		public void TestIsDoingTap(){
			generator.GeneratedTap ().Returns (true);
			inputReader.TapExecuted += HandleActionExecuted;
			AssertActionWasCalled ();
		}

		[Test]
		public void TestIfTapIsExecutedLongPressIsntExecuted(){
			generator.GeneratedTap ().Returns (true);
			generator.GeneratedLongPress ().Returns (false);
			bool tapWasCalled = false;
			bool longPressWasCalled = false;
			inputReader.TapExecuted += () => {
				tapWasCalled = true;
			};
			inputReader.LongPressExecuted += () => {
				longPressWasCalled = true;
			};
			inputReader.Update ();
			Assert.IsTrue(tapWasCalled);
			Assert.IsFalse(longPressWasCalled);
		}

		private void HandleActionExecuted() {
			wascalled = true;
		}

		private void AssertActionWasCalled(){
			inputReader.Update ();
			Assert.IsTrue(wascalled);
		}
	}
}
