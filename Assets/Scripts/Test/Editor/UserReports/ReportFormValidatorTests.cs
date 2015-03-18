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
		const string EMPTY_INPUT="";
		const string INVALID_DIGIT_NUMBER = "1";

		[SetUp]
		public void SetUp(){
			validator = new ReportFormValidator ();
		}

		[Test]
		[Category("Day Field")]
		public void TestDayValueIsInvalidIfInputFieldIsEmptyString() {
			validator.Day = EMPTY_INPUT;
			Assert.IsFalse (validator.IsValidDay());
		}

		[Test]
		[Category("Day Field")]
		public void TestDayValueIsValidIfInputFieldIsBetween1And31() {
			const string VALID_DAY="01";
			validator.Day = VALID_DAY;
			Assert.IsTrue (validator.IsValidDay());
		}

		[Test]
		[Category("Day Field")]
		public void TestDayValueIsInvalidIfInputFieldIsOutside1To31Range() {
			const string INVALID_DAY="32";
			validator.Day = INVALID_DAY;
			Assert.IsFalse (validator.IsValidDay());
		}

		[Test]
		[Category("Day Field")]
		public void TestDayInputIsInvalidIfHasLessThan2Digits(){
			validator.Day=INVALID_DIGIT_NUMBER;
			Assert.IsFalse (validator.IsValidDay());
		}

		[Test]
		[Category("Month Field")]
		public void TestMonthValueIsInvalidIfIsEmptyString(){
			validator.Month=EMPTY_INPUT;
			Assert.IsFalse(validator.IsValidDay());
		}

		[Test]
		[Category("Month Field")]
		public void TestMonthValueIsValidIfInputFieldIsBetween1And12(){
			const string VALID_MONTH="01";
			validator.Month=VALID_MONTH;
			Assert.IsTrue (validator.IsValidMonth());
		}

		[Test]
		[Category("Month Field")]
		public void TestMonthValueIsInvalidIfInputFieldIsOutside1To12Range() {
			const string INVALID_MONTH="13";
			validator.Month=INVALID_MONTH;
			Assert.IsFalse (validator.IsValidMonth());
		}

		[Test]
		[Category("Month Field")]
		public void TestMonthInputIsInvalidIfHasLessThan2Digits(){
			validator.Month=INVALID_DIGIT_NUMBER;
			Assert.IsFalse (validator.IsValidMonth());
		}

		[Test]
		[Category("Year Field")]
		public void TestYearValueIsInvalidIfIsEmptyString(){
			validator.Year=EMPTY_INPUT;
			Assert.IsFalse(validator.IsValidYear());
		}

		[Test]
		[Category("Year Field")]
		public void TestYearValueIsInvalidIfHasMoreThan5Digits(){
			const string INVALID_HOUR="12345";
			validator.Year=INVALID_HOUR;
			Assert.IsFalse(validator.IsValidYear());
		}

		[Test]
		[Category("Year Field")]
		public void TestMonthInputIsInvalidIfHasLessThan5Digits(){
			validator.Year=INVALID_DIGIT_NUMBER;
			Assert.IsFalse (validator.IsValidYear());
		}
		
		[Test]
		[Category("Hour Field")]
		public void TestHourValueIsInvalidIfIsEmptyString(){
			validator.Hour=EMPTY_INPUT;
			Assert.IsFalse(validator.IsValidHour());
		}

		[Test]
		[Category("Hour Field")]
		public void TestHourValueIsValidIfInputFieldIsBetween0And23() {
			const string VALID_HOUR="00";
			validator.Hour=VALID_HOUR;
			Assert.IsTrue (validator.IsValidHour());
		}

		[Test]
		[Category("Hour Field")]
		public void TestHourValueIsInvalidIfInputFieldIsOutside0To23Range() {
			const string INVALID_HOUR="24";
			validator.Hour=INVALID_HOUR;
			Assert.IsFalse (validator.IsValidHour());
		}

		[Test]
		[Category("Hour Field")]
		public void TestHourInputIsInvalidIfHasLessThan2Digits(){
			validator.Hour=INVALID_DIGIT_NUMBER;
			Assert.IsFalse (validator.IsValidHour());
		}

		[Test]
		[Category("Minute Field")]
		public void TestMinuteValueIsInvalidIfIsEmptyString(){
			validator.Minute=EMPTY_INPUT;
			Assert.IsFalse(validator.IsValidMinute());
		}

		[Test]
		[Category("Minute Field")]
		public void TestHourValueIsValidIfInputFieldIsBetween0And59() {
			const string VALID_MINUTE="00";
			validator.Minute=VALID_MINUTE;
			Assert.IsTrue (validator.IsValidMinute());
		}

		[Test]
		[Category("Minute Field")]
		public void TestHourValueIsInvalidIfInputFieldIsOutside0To59Range() {
			const string INVALID_MINUTE="60";
			validator.Minute=INVALID_MINUTE;
			Assert.IsFalse (validator.IsValidMinute());
		}

		[Test]
		[Category("Minute Field")]
		public void TestMinuteInputIsInvalidIfHasLessThan2Digits(){
			validator.Minute=INVALID_DIGIT_NUMBER;
			Assert.IsFalse (validator.IsValidMinute());
		}

		[Test]
		[Category("Comments Field")]
		public void TestCommentsValueIsInvalidIfIsEmptyString(){
			validator.Comments=EMPTY_INPUT;
			Assert.IsFalse(validator.IsValidComment());
		}

	}
}
