using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Otus2.Data;
using Otus2.Exceptions;

namespace Otus2.Blocks
{
    public class ClientTrainingBlock : BlockBase
    {
        public ClientTrainingBlock(OtusDbContext dbContext) : base(dbContext)
        {
            _fields.Add(new FieldBlock() { Caption = "Id", Size = 3, Type = TypeBlock.Int, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Id тренинга (trainings)", Size = 45, Type = TypeBlock.Int, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Id клиента (clients)", Size = 45, Type = TypeBlock.Int, NotNull = true });

            _caption = "Клиенты на тренинге";
            _name = "ClientTraining";
        }

        public override void InsertRow()
        {
            Console.WriteLine("Что бы прервать введите значение \"exit\"");
            try
            {
                var item = new ClientTraining();

                var idTran = int.Parse(ReadValueField(1));
                var train = _dbContext.Trainings.SingleOrDefault(t => t.Id == idTran);

                if (train == null)
                {
                    throw new InvalidRelException($"id={idTran} не найдена в таблице trainings");
                }
                item.Training = train;

                var idClient = int.Parse(ReadValueField(2));
                var client = _dbContext.Clients.SingleOrDefault(t => t.Id == idClient);

                if (client == null)
                {
                    throw new InvalidRelException($"id={idClient} не найдена в таблице clients");
                }
                item.Client = client;

                _dbContext.ClientTrainings.Add(item);
                _dbContext.SaveChanges();

                Console.WriteLine("Запись успешно добавлена!");
            }
            catch (BreakInsertRow)
            {
                Console.WriteLine("Пользователь прервал добавление новой записи!");
            }
            catch (InvalidRelException ex)
            {
                Console.WriteLine($"Указана не правильна ссылка {ex.Message}");
            }
        }

        public override void PrintBodyTable()
        {
            var format = FormatData();
            foreach (var trainClient in _dbContext.ClientTrainings.Include(t => t.Training).Include(t => t.Client).ToList())
            {
                Console.WriteLine(format, trainClient.Id, $"{trainClient?.Training?.Id} ({trainClient?.Training?.StartDateTraining})", $"{trainClient?.Client?.Id} ({trainClient?.Client?.Surname})");
                PrintLine();
            }
        }
    }
}