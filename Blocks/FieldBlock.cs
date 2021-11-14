using System;

namespace Otus2.Blocks
{
    public class FieldBlock
    {
        private bool notNull;

        public string Caption { get; set; }

        public TypeBlock Type { get; set; }

        public int Size { get; set; }

        public bool NotNull { get => notNull; set => notNull = value; }

        public FieldBlock()
        {
            notNull = false;
        }
    }
}