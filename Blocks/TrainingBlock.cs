using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Otus2.Data;
using Otus2.Exceptions;

namespace Otus2.Blocks
{
    public class TrainingBlock : BlockBase
    {
        public override void InsertRow()
        {
            Console.WriteLine("Что бы прервать введите значение \"exit\"");
            try
            {
                var item = new Training();
                item.StartDateTraining = DateTime.Parse(ReadValueField(1));
                item.EndDateTraining = DateTime.Parse(ReadValueField(2));
                item.DateIssueCertificates = DateTime.Parse(ReadValueField(3));

                var idTranProg = int.Parse(ReadValueField(4));
                var trainProg = _dbContext.TrainingPrograms.SingleOrDefault(t => t.Id == idTranProg);

                if (trainProg == null)
                {
                    throw new InvalidRelException($"id={idTranProg} не найдена в таблице training_programs");
                }

                item.TrainingProgram = trainProg;

                _dbContext.Trainings.Add(item);
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
            foreach (var train in _dbContext.Trainings.Include(t => t.TrainingProgram).ToList())
            {
                Console.WriteLine(format, train.Id, train?.StartDateTraining, train?.EndDateTraining, train?.DateIssueCertificates, $"{train?.TrainingProgram?.Id} ({train?.TrainingProgram?.Name})");
                PrintLine();
            }
        }

        public TrainingBlock(OtusDbContext dbContext) : base(dbContext)
        {
            _fields.Add(new FieldBlock() { Caption = "Id", Size = 3, Type = TypeBlock.Int, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Начала тренинга", Size = 30, Type = TypeBlock.Date, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Окончание тренинга", Size = 30, Type = TypeBlock.Date, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Дата выдачи сертификата", Size = 30, Type = TypeBlock.Date, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Id программы обучения (training_programs)", Size = 45, Type = TypeBlock.Int, NotNull = true });

            _caption = "Тренинги";
            _name = "Training";
        }
    }
}