using System;
using System.Collections.Generic;
using Otus2.Data;

namespace Otus2.Blocks
{
    public class ManagerBlock
    {
        private List<BlockBase> _listBlock;

        public void ShowSelect()
        {
            Console.WriteLine("Выберите один из вариантов");
            Console.WriteLine("1 - Выход из программы");

            var index = 1;
            foreach (var block in _listBlock)
            {
                for (int i = 0; i < 2; i++)
                {
                    index++;
                    var action = i == 0 ? "Просмотр" : "Добавление";

                    Console.WriteLine($"{index.ToString()} - {block.Name} ({block.Caption}). {action}");
                }
            }
        }

        public void Action(string value)
        {
            if (value == "1")
            {
                return;
            }

            var valid = Validate(value);

            if (!valid)
            {
                Console.WriteLine("Вы ввели не корректное значение!");
            }
            else
            {
                var val = decimal.Parse(value) - 1;

                var indexBlock = (int)Math.Ceiling(val / 2);
                var actionType = val % 2;

                var block = _listBlock[indexBlock - 1];

                if (actionType == 1)
                {
                    block.Show();
                }
                else
                {
                    block.InsertRow();
                }

            }
        }

        private bool Validate(string value)
        {
            int val;

            if (!int.TryParse(value, out val))
            {
                return false;
            }

            if (val < 1 || val > _listBlock.Count * 2 + 1)
            {
                return false;
            }

            return true;
        }

        public ManagerBlock(OtusDbContext context)
        {
            _listBlock = new List<BlockBase>();
            _listBlock.Add(new ClientBlock(context));
            _listBlock.Add(new TrainingProgramBlock(context));
            _listBlock.Add(new TrainingBlock(context));
            _listBlock.Add(new ClientTrainingBlock(context));
        }
    }
}