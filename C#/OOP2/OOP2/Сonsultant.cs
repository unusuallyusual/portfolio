using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP2
{
  /// <summary>
  /// Консультант
  /// </summary>
  class Сonsultant : Client
  {
    /// <summary>
    /// Создание экземпляра клиента
    /// </summary>
    /// <param name="Surname">Фамилия</param>
    /// <param name="Name">Имя</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="PhoneNumber">Номер телефона</param>
    /// <param name="Passport">Паспорт</param>
    public Сonsultant(string DateChanges, string Surname, string Name, string Patronymic, string PhoneNumber, string Passport, string RecentChanges)
      : base(DateChanges, Surname, Name, Patronymic, PhoneNumber, Passport)
    {
    }

    public Сonsultant() : this("сегодня/сейчас", "", "", "", "", "", "")
    {
    }

    /// <summary>
    /// Фамилия
    /// </summary>
    public new string Surname { get { return base.Surname; } }

    /// <summary>
    /// Имя
    /// </summary>
    public new string Name { get { return base.Name; } }

    /// <summary>
    /// Отчество
    /// </summary>
    public new string Patronymic { get { return base.Patronymic; } }

    /// <summary>
    /// Серия и номер паспорта. Данные не доступны для просмотра.
    /// </summary>
    public new string Passport { get { return new string('*', base.Passport.Length); } }

    protected string RecentChanges;

    /// <summary>
    /// Извлечение данных клиента
    /// </summary>
    private string ClientInfo()
    {
      return $"{DateChanges}#{Surname}#{Name}#{Patronymic}#{PhoneNumber}#{base.Passport}#{RecentChanges}";
    }

    /// <summary>
    /// Запись данных клиента в файл
    /// </summary>
    private void RecToFile(string path)
    {
      string contents = ClientInfo();
      File.AppendAllText(path, contents);
    }

    /// <summary>
    /// Вывод данных клиента для просмотра
    /// </summary>
    public virtual string PrintClientInfo()
    {
      return $"{DateChanges} >> {Surname} {Name} {Patronymic}.\nTeл. : {PhoneNumber}, Док-т : {Passport}";
    }

    /// <summary>
    /// Считывание данных клиента из файла
    /// </summary>
    public new Сonsultant ReadFile(string path)
    {
      string line = File.ReadAllText(path);
      string[] subs = line.Split('#');
      return new Сonsultant(subs[0], subs[1], subs[2], subs[3], subs[4], subs[5], subs[6]);
      }

    /// <summary>
    /// Редактирование данных клиента из файла
    /// </summary>
    public virtual void EditDataClient(string path)
    {
      Console.WriteLine("Изменить данные номера телефона клиента ?\n   Нажми Y/N :");
      char cha = Convert.ToChar(Console.ReadLine());
      if (Char.ToLower(cha) == 'y')
      {
        File.WriteAllText(path, string.Empty);
        Console.WriteLine("Введите номер телефона клиента :");
        PhoneNumber = Console.ReadLine();
        DateChanges = Convert.ToString(DateTime.Now);
        RecentChanges = "\nКонсультант отредактировал номер телефона клиента.";
        Console.Write("   Данные были отредактированы...\n");
        RecToFile(path);
      }
      else
      if (Char.ToLower(cha) == 'n')
        Console.Write("   Данные НЕ были отредактированы...\n");
      Console.WriteLine(PrintClientInfo());
    }
  }
}

