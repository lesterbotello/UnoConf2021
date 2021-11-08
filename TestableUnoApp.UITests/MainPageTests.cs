using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.UITest.Helpers.Queries;

namespace TestableUnoApp.UITests
{
    class MainPageTests : TestBase
    {
        [Test(Description = "When email is invalid, error message should be displayed")]
        public void WhenEmailIsInvalid_ErrorMessageShouldBeDisplayed()
        {
            // You can write your tests like this:

            //var errorLabel = Query("ErrorMessageLabel");
            //var userNameField = Query("UsernameTextBox");
            //var validateButton = Query("ValidateUserName");
            //var errorMessage = Query("ErrorMessage");

            //App.WaitForElement(userNameField);
            //App.Tap(userNameField);
            //App.EnterText("qwerty");
            //App.Flash(validateButton);
            //App.Tap(validateButton);

            //var result = App.Query(q => errorMessage(q)
            //                                .GetDependencyPropertyValue("Text")
            //                                .Value<string>())
            //    .FirstOrDefault();

            //Assert.IsTrue(result == "Please enter a valid email address");

            // ... or you can use the shorter, base-class powered version :)

            EnterTextWhenReady("qwerty", "UsernameTextBox");
            TapElementWhenReady("ValidateUserName", true);
            AssertAreEqual("ErrorMessage", "Text", "Please enter a valid email address");
        }

        [Test(Description = "When email is valid, error message should not be displayed")]
        public void WhenEmailIsValid_ErrorMessageShouldNotBeDisplayed()
        {
            // You can write your tests like this:

            //var errorLabel = Query("ErrorMessageLabel");
            //var userNameField = Query("UsernameTextBox");
            //var validateButton = Query("ValidateUserName");
            //var errorMessage = Query("ErrorMessage");

            //App.WaitForElement(userNameField);
            //App.Tap(userNameField);
            //App.EnterText("lesterbotello@gmail.com");
            //App.Flash(validateButton);
            //App.Tap(validateButton);

            //var result = App.Query(q => errorMessage(q)
            //                                .GetDependencyPropertyValue("Text")
            //                                .Value<string>())
            //    .FirstOrDefault();

            //Assert.IsTrue(result == string.Empty);

            // ... or you can use the shorter, base-class powered version :)

            EnterTextWhenReady("lesterbotello@gmail.com", "UsernameTextBox");
            TapElementWhenReady("ValidateUserName", true);
            AssertAreEqual("ErrorMessage", "Text", string.Empty);
        }

        [Test(Description = "When email is invalid, password field should be hidden")]
        public void WhenEmailIsInvalid_PasswordFieldShouldBeHidden()
        {
            // You can write your tests like this:

            //var query = Query("UsernameTextBox");
            //App.Tap(query);
            //App.Tap(query); // Tap again to dismiss autofill, which would show up if enabled...
            //App.EnterText("qwerty");
            //App.Tap(Query("ValidateUserName"));
            //var result = App.Query(Query("PasswordContainer"));
            //Assert.IsTrue(result.Length == 0);

            // ... or you can use the shorter, base-class powered version :)

            EnterTextWhenReady("qwerty", "UsernameTextBox");
            TapElementWhenReady("ValidateUserName", true);
            var result = App.Query(Query("PasswordContainer"));
            Assert.IsTrue(result.Length == 0);
        }

        [Test(Description = "When email is valid, password field should be visible")]
        public void WhenEmailIsValid_PasswordFieldShoudBeVisible()
        {
            // You can write your tests like this:

            //var query = Query("UsernameTextBox");
            //App.Tap(query);
            //App.Tap(query); // Tap again to dismiss autofill, which would show up if enabled...
            //App.EnterText("qwerty");
            //App.Tap(Query("ValidateUserName"));
            //var result = App.Query(Query("PasswordContainer"));
            //Assert.IsTrue(result.Length > 0);

            // ... or you can use the shorter, base-class powered version :)

            EnterTextWhenReady("lesterbotello@gmail.com", "UsernameTextBox");
            TapElementWhenReady("ValidateUserName", true);
            var result = App.Query(Query("PasswordContainer"));
            Assert.IsTrue(result.Length > 0);
        }
    }
}
