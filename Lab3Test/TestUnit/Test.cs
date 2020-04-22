namespace TestUnit
{
    using System;
    using TestStack.White;
    using TestStack.White.UIItems;
    using System.Threading;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.Finders;
    using NUnit.Framework;
    using System.Windows.Automation;

    [TestFixture]
    public class Calculations
    {
        private Application _application;

        [Test]
        public void PlusTwoNumbers()
        {
            // открытие калькулятора
            _application = Application.Launch("C:\\Windows\\system32\\calc1.exe");
            Assert.IsNotNull(_application);
            GetButton("131").Click();
            GetButton("132").Click();
            GetButton("93").Click();
            GetButton("139").Click();
            GetButton("139").Click();
            GetButton("139").Click();
            GetButton("121").Click();
            GetButton("124").Click();
            GetButton("131").Click();
            GetButton("139").Click();
            GetButton("125").Click();
            GetButton("123").Click();
            Assert.AreEqual(ResultTextBox(), "1030");
            _application.Close();
        }

        // возврат результата операций 
        private object ResultTextBox()
        {
            return
            GetWindow().Get<Label>(SearchCriteria.ByAutomationId("150")).AutomationElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();

        }

        // метод поиска кнопки
        public Button GetButton(string nameWindow)
        {
            Button but = GetWindow().Get<Button>(SearchCriteria.ByAutomationId(nameWindow));
            return but;
        }

        // метод возврата главного окна калькулятора
        public Window GetWindow()
        {
            return _application.GetWindow("Калькулятор");
        }
    }
}