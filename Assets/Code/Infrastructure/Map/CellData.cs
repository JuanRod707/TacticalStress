namespace Code.Infrastructure.Map
{
    public class CellData
    {
        public Coordinate Coordinate { get; private set; }

        public bool Passable { get; set; }

        public CellData(int x, int z)
        {
            Coordinate = new Coordinate(x, z);
        }
    }
}
