using System;

namespace SampleAlgorithms
{
    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    public enum GameResult
    {
        Win,
        Lose,
        Draw
    }

    public class RockPaperScissorsGame
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Simulates a round of Rock-Paper-Scissors against the computer.
        /// Returns the outcome of the round for the player.
        /// test comment
        /// </summary>
        public GameResult Play(Move playerMove)
        {
            var computerMove = (Move)_random.Next(0, 3);
            return DetermineResult(playerMove, computerMove);
        }

        /// <summary>
        /// Determines the game result between two moves.
        /// </summary>
        public GameResult DetermineResult(Move player, Move computer)
        {
            if (player == computer)
                return GameResult.Draw;

            if ((player == Move.Rock && computer == Move.Scissors) ||
                (player == Move.Paper && computer == Move.Rock) ||
                (player == Move.Scissors && computer == Move.Paper))
                return GameResult.Win;

            return GameResult.Lose;
        }
    }
}
