using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Otus2.Data;
using Otus2.Exceptions;

namespace Otus2.Blocks
{
    public abstract class BlockBase
    {
        protected string _caption;

        protected string _name;

        protected OtusDbContext _dbContext;

        protected List<FieldBlock> _fields;

        public int NumberPosition { get; set; }

        public string Caption { get { return _caption; } }

        public string Name { get { return _name; } }


        /// <summary>
        /// Визуализация
        /// </summary>
        public void Show()
        {
            Console.WriteLine($"Таблица: {_name} ({_caption})");
            PrintLine();
            PrintHeader();
            PrintLine();
            PrintBodyTable();
        }

        protected void PrintLine()
        {
            var result = new StringBuilder();
            var flag = true;
            foreach (var field in _fields)
            {
                if (!flag)
                {
                    result.Append("+");
                }
                else
                {
                    flag = false;
                }

                result.Append(new string('-', field.Size));
            }
            result.Append("+");
            Console.WriteLine(result.ToString());
        }

        public BlockBase(OtusDbContext dbContext)
        {
            _dbContext = dbContext;
            _fields = new List<FieldBlock>();
        }

        public abstract void PrintBodyTable();

        private void PrintHeader()
        {
            //var val = new[] { "2", "324", "34", "43534", "342", "3423" };

            var val = _fields.Select(eee => eee.Caption.ToUpper()).ToArray();
            Console.WriteLine(FormatData(), val);
        }

        public abstract void InsertRow();

        protected string ReadValueField(int index)
        {
            var field = _fields[index];
            var value = "";
            var valid = false;
            do
            {
                Console.Write($"Введите значение поля \"{field.Caption}\": ");
                value = Console.ReadLine();

                if (value == "exit")
                {
                    throw new BreakInsertRow();
                }

                if (field.NotNull && String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Не допустимо NULL значение");
                    continue;
                }

                valid = IsValid(value, field.Type);
                if (!valid)
                {
                    ShowErrorValid(field.Type);
                }
            }
            while (!valid);

            return value;
        }

        private void ShowErrorValid(TypeBlock type)
        {
            switch (type)
            {
                case TypeBlock.Int:
                    Console.WriteLine("Введенное значение не соответсвует типу Int, попробуйте еще раз!");
                    break;
                case TypeBlock.String:
                    Console.WriteLine("Введенное значение не соответсвует типу String, попробуйте еще раз!");
                    break;
                case TypeBlock.Date:
                    Console.WriteLine("Введенное значение не соответсвует типу Date, формат ввода (YYYY-MM-DD), попробуйте еще раз!");
                    break;
            }
        }

        private bool IsValid(string value, TypeBlock type)
        {
            switch (type)
            {
                case TypeBlock.String:
                    return true;
                case TypeBlock.Int:
                    int val = 0;
                    return int.TryParse(value, out val);
                case TypeBlock.Date:
                    DateTime date;
                    return DateTime.TryParse(value, out date);
            }
            return false;
        }

        protected string FormatData()
        {
            var result = new StringBuilder();
            for (var i = 0; i < _fields.Count; i++)
            {
                result.Append("{");
                result.Append(i.ToString());
                result.Append(",");
                result.Append(_fields[i].Size);
                result.Append("}");
                result.Append("|");
            }
            return result.ToString();
        }
    }
}