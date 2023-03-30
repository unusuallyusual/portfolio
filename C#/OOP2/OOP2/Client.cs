using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP2
{
    enum SortedCriterion
    {
        Surname,
        DateChanges
    }

    /// <summary>
    /// Клиент
    /// </summary>
    internal partial class Client
    {
        private string phonenumber;

        /// <summary>
    /// Создание экземпляра клиента
    /// </summary>
    /// <param name="DateChanges">Время создание записи/param>
    /// <param name="Surname">Фамилия</param>
    /// <param name="Name">Имя</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="PhoneNumber">Номер телефона</param>
    /// <param name="Passport">Паспорт</param>
        public Client(string DateChanges, string Surname, string Name, string Patronymic, string PhoneNumber, string Passport, string DepName)
        {
            this.DateChanges = DateChanges;
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.Passport = Passport;
            this.PhoneNumber = PhoneNumber;
            this.DepartamentName = DepName;
        }
        
        public Client() : this(Convert.ToString(DateTime.Now), "", "", "", "", "", "") { }
        public string DateChanges { get; set; }

        /// <summary>
    /// Фамилия
    /// </summary>
        public string Surname { get; set; }

        /// <summary>
    /// Имя
    /// </summary>
        public string Name { get; set; }

        /// <summary>
  /// Отчество
  /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
  /// Номер телефона
  /// </summary>
        public string PhoneNumber
    {
      get
      {
        return phonenumber;
      }
      set
      {
        if (value != String.Empty)
          this.phonenumber = value;
        else
          phonenumber = "нет данных..";
      }
    }

        /// <summary>
    /// Серия и номер паспорта
    /// </summary>
        public string Passport { get; set; }

        /// <summary>
    /// Название департамента
    /// </summary>
        public string DepartamentName { get; set; }

        public string ClientInfo()
        {
            return $"{DateChanges}#{Surname}#{Name}#{Patronymic}#{PhoneNumber}#{Passport}#{DepartamentName}";
        }

        public void RecToFile(string path)
        {
            string contents = ClientInfo();
            File.AppendAllText(path, contents + "\n");
        }
        
        private class SortBySurname : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return String.Compare(X.Surname, Y.Surname);
            }
        }
        
        private class SortByDateChanges : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                Client X = (Client)x;
                Client Y = (Client)y;

                return String.Compare(Y.DateChanges, X.DateChanges);
            }
        }
        
        public static IComparer<Client> SortedBy(SortedCriterion Criterion)
        {
            if (Criterion == SortedCriterion.Surname) return new SortBySurname();
            else return new SortByDateChanges();
        }
    }
}
