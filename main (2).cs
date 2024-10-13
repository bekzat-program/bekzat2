using System;

namespace BankAccountApp
{
    // Класс BankAccount, который описывает банковский счет
    public class BankAccount
    {
        // Свойство: номер счета
        public string AccountNumber { get; private set; }

        // Свойство: баланс счета
        public decimal Balance { get; private set; }

        // Свойство: владелец счета
        public string Owner { get; private set; }

        // Конструктор, принимающий номер счета и владельца, устанавливая баланс в 0
        public BankAccount(string accountNumber, string owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = 0; // Начальный баланс
        }

        // Метод для пополнения баланса
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма депозита должна быть положительной.");
            }
            Balance += amount;
        }

        // Метод для снятия средств с баланса
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма снятия должна быть положительной.");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Недостаточно средств на счете.");
            }
            Balance -= amount;
        }

        // Метод для получения информации о счете
        public string GetAccountInfo()
        {
            return $"Номер счета: {AccountNumber}, Владелец: {Owner}, Баланс: {Balance}";
        }

        // Метод для перевода средств с одного счета на другой
        public void Transfer(BankAccount targetAccount, decimal amount)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount), "Целевой счет не может быть пустым.");
            }
            Withdraw(amount); // Снимаем деньги с текущего счета
            targetAccount.Deposit(amount); // Пополняем целевой счет
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования класса BankAccount
            BankAccount account1 = new BankAccount("123456", "Иван Иванов");
            BankAccount account2 = new BankAccount("654321", "Петр Петров");

            // Пополнение счета
            account1.Deposit(500);
            Console.WriteLine(account1.GetAccountInfo());

            // Перевод средств
            account1.Transfer(account2, 200);
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());

            // Снятие средств
            account2.Withdraw(50);
            Console.WriteLine(account2.GetAccountInfo());
        }
    }
}
