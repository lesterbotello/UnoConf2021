﻿using System;
using System.IO;
using NUnit.Framework;
using Uno.UITest;
using System.Linq;
using Uno.UITest.Selenium;
using Uno.UITests.Helpers;
using Uno.UITest.Helpers.Queries;

namespace TestableUnoApp.UITests
{
    public class TestBase
    {
        private IApp _app;

        static TestBase()
        {
            AppInitializer.TestEnvironment.AndroidAppName = Constants.AndroidAppName;
            AppInitializer.TestEnvironment.WebAssemblyDefaultUri = Constants.WebAssemblyDefaultUri;
            AppInitializer.TestEnvironment.iOSAppName = Constants.iOSAppName;
            AppInitializer.TestEnvironment.iOSDeviceNameOrId = Constants.iOSDeviceNameOrId;
            AppInitializer.TestEnvironment.CurrentPlatform = Constants.CurrentPlatform;


            // Start the app only once, so the tests runs don't restart it
            // and gain some time for the tests.
            AppInitializer.ColdStartApp();
        }

        protected IApp App
        {
            get => _app;
            private set
            {
                _app = value;
                Helpers.App = value;
            }
        }

        protected Func<IAppQuery, IAppQuery> Query(string element) => q => q.Marked(element);

        protected void TapElementWhenReady(string elementId, bool flashElement = false)
        {
            var query = Query(elementId);
            App.WaitForElement(query);

            if(flashElement)
            {
                App.Flash(query);
            }

            App.Tap(query);
        }

        protected void EnterTextWhenReady(string text, string elementId = null)
        {
            if(!string.IsNullOrEmpty(elementId))
            {
                TapElementWhenReady(elementId);
            }

            App.EnterText(text);
        }

        protected void AssertAreEqual<T>(string elementId, string propertyName, T expectedValue)
        {
            var result = App.Query(q => q.Marked(elementId)
                                            .GetDependencyPropertyValue(propertyName)
                                            .Value<T>())
                .FirstOrDefault();

            Assert.AreEqual(result, expectedValue);
        }

        [SetUp]
        public void SetUpTest()
        {
            App = AppInitializer.AttachToApp();
        }

        [TearDown]
        public void TearDownTest()
        {
            TakeScreenshot("teardown");
        }

        public FileInfo TakeScreenshot(string stepName)
        {
            var title = $"{TestContext.CurrentContext.Test.Name}_{stepName}"
                .Replace(" ", "_")
                .Replace(".", "_");

            var fileInfo = _app.Screenshot(title);

            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileInfo.Name);
            if (fileNameWithoutExt != title)
            {
                var destFileName = Path
                    .Combine(Path.GetDirectoryName(fileInfo.FullName), title + Path.GetExtension(fileInfo.Name));

                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }

                File.Move(fileInfo.FullName, destFileName);

                TestContext.AddTestAttachment(destFileName, stepName);

                fileInfo = new FileInfo(destFileName);
            }
            else
            {
                TestContext.AddTestAttachment(fileInfo.FullName, stepName);
            }

            return fileInfo;
        }

    }
}
