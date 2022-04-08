namespace Game.ScoreCounter
{
    public class ScoreCounter
    {
        private int _score = 0;

        public int GetCurrentScore() => 
            _score;

        public void AddScore() => 
            _score += 1;
    }
}