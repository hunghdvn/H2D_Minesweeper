namespace H2D_Minesweeper
{
    public class CellBlock
    {
        public int NumMine { get; set; }
        public BlockType BlockType { get; set; }
    }

    public enum BlockType
    {
        None,
        Open,
        Flag
    }
}
