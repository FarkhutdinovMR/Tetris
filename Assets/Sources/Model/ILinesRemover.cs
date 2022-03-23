namespace Tetris.Models
{
    public interface ILinesRemover
    {
        public void Remove(int[] lines);

        public void Update(float deltaTime);
    }
}