using System;
using Otus2.Data;
using Otus2.Exceptions;

namespace Otus2.Blocks
{
    public class ClientBlock : BlockBase
    {

        public override void PrintBodyTable()
        {
            var format = FormatData();
            foreach (var client in _dbContext.Clients)
            {
                Console.WriteLine(format, client.Id, client.Surname, client.Name, client.MiddleName, client.Email, client.DateBirth);
                PrintLine();
            }
        }

        public override void InsertRow()
        {
            Console.WriteLine("Что бы прервать введите значение \"exit\"");
            try
            {
                var item = new Client();
                item.Surname = ReadValueField(1);
                item.Name = ReadValueField(2);
                item.MiddleName = ReadValueField(3);
                item.Email = ReadValueField(4);
                item.DateBirth = DateTime.Parse(ReadValueField(5));

                _dbContext.Clients.Add(item);
                _dbContext.SaveChanges();

                Console.WriteLine("Запись успешно добавлена!");

            }
            catch (BreakInsertRow)
            {
                Console.WriteLine("Пользователь прервал добавление новой записи!");
            }
        }

        public ClientBlock(OtusDbContext dbContext) : base(dbContext)
        {

            _fields.Add(new FieldBlock() { Caption = "Id", Size = 3, Type = TypeBlock.Int, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Фамилия", Size = 20, Type = TypeBlock.String });
            _fields.Add(new FieldBlock() { Caption = "Имя", Size = 20, Type = TypeBlock.String });
            _fields.Add(new FieldBlock() { Caption = "Отчестно", Size = 20, Type = TypeBlock.String });
            _fields.Add(new FieldBlock() { Caption = "Email", Size = 30, Type = TypeBlock.String });
            _fields.Add(new FieldBlock() { Caption = "Дата рождения", Size = 20, Type = TypeBlock.Date });

            _caption = "Клиенты";
            _name = "Client";
        }
    }
}