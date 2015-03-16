using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace UnityTest {
	[TestFixture]
	[Category("Report Saver Tests")]
	internal class ReportFormValidatorTests {

		ReportFormValidator validator;

		[SetUp]
		public void SetUp(){
			validator = new ReportFormValidator ();
		}

		[Test]
		[Category("Empty Field")]
		public void TestDayValueIsInvalidIfInputFieldIsEmptyString() {
			const string INVALID_DAY_INPUT="";
			validator.Day = INVALID_DAY_INPUT;
			Assert.IsFalse (validator.IsValid);
		}

		[Test]
		[Category("Empty Field")]
		public void TestDayValueIsInvalidIfInputFieldIsZero() {
			const string INVALID_DAY="0";
			validator.Day=INVALID_DAY;
			Assert.IsFalse (validator.IsValid);
		}

		[Test]
		public void TestDayValueIsValidIfNumberIsGreaterThan0() {
			const string VALID_DAY="1";
			validator.Day=VALID_DAY;
			Assert.IsTrue (validator.IsValid);
		}

		[Test]
		public void TestDayValueIsInValidIfNumberIsGreaterThan31() {
			const string INVALID_DAY="32";
			validator.Day=INVALID_DAY;
			Assert.IsFalse (validator.IsValid);
		}
	}
}
