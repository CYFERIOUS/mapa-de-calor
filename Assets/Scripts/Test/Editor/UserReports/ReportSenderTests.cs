using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class ReportSenderTests {

		ReportFormValidator validator;

		[SetUp]
		public void SetUp(){
			validator = new ReportFormValidator ();
		}

		[Test]
		[Category("Empty Field")]
		public void TestDayValueIsInvalidIfInputFieldIsZero() {
			/*Color ExpectedEmptyFieldColor = Color.red;
			Color DayInputFieldColor=reportSender.dateFieldDay.image.color;
			Assert.Equals (ExpectedEmptyFieldColor, DayInputFieldColor);*/
			const int INVALID_DAY=0;
			validator.Day=INVALID_DAY;
			Assert.IsFalse (validator.IsValid);
		}

		[Test]
		public void TestDayValueIsValidIfNumberIsGreaterThan0() {
			const int VALID_DAY=1;
			validator.Day=VALID_DAY;
			Assert.IsTrue (validator.IsValid);
		}

		[Test]
		public void TestDayValueIsInValidIfNumberIsGreaterThan31() {
			const int INVALID_DAY=32;
			validator.Day=INVALID_DAY;
			Assert.IsFalse (validator.IsValid);
			/*validator.Day=31;
			Assert.IsFalse (validator.IsValid);*/
		}
	}
}
