namespace AdventOfCode2016.DayEleven
{
    public struct Item
    {
        public Item(char code, bool generator)
        {
            Code = code;
            Generator = generator;
        }

        public char Code { get; }

        // If it is not a generator, it is a Microchip
        public bool Generator { get; }

        public bool Matches(Item item) =>
            item.Code == Code && item.Generator != Generator;

        public override string ToString() =>
            $"{Code}{(Generator ? 'G' : 'M')}";

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
                return false;
            Item item = (Item)obj;
            return item.Code == Code && item.Generator == Generator;
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}
