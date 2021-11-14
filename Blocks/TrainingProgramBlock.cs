using System;
using Otus2.Data;
using Otus2.Exceptions;

namespace Otus2.Blocks
{
    public class TrainingProgramBlock : BlockBase
    {
        public override void InsertRow()
        {
            Console.WriteLine("Что бы прервать введите значение \"exit\"");
            try
            {
                var item = new TrainingProgram();
                item.Name = ReadValueField(1);

                _dbContext.TrainingPrograms.Add(item);
                _dbContext.SaveChanges();

                Console.WriteLine("Запись успешно добавлена!");

            }
            catch (BreakInsertRow)
            {
                Console.WriteLine("Пользователь прервал добавление новой записи!");
            }
        }

        public override void PrintBodyTable()
        {
            var format = FormatData();
            foreach (var prog in _dbContext.TrainingPrograms)
            {
                Console.WriteLine(format, prog.Id, prog.Name);
                PrintLine();
            }
        }

        public TrainingProgramBlock(OtusDbContext dbContext) : base(dbContext)
        {
            _fields.Add(new FieldBlock() { Caption = "Id", Size = 3, Type = TypeBlock.Int, NotNull = true });
            _fields.Add(new FieldBlock() { Caption = "Название", Size = 40, Type = TypeBlock.String });

            _caption = "Программы обучения";
            _name = "TrainingProgram";
        }
    }
}