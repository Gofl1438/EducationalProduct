using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle;

namespace EducationalProduct.Classes
{
    public class ManagerPuzzle
    {
        public static List<Puzzle> Puzzles = new List<Puzzle>();

        public static void AddDefaultPuzzles()
        {
            PuzzlesType[] puzzleTypes = (PuzzlesType[])Enum.GetValues(typeof(PuzzlesType));

            foreach (PuzzlesType type in puzzleTypes)
            {
                Puzzle puzzle = new Puzzle(type);
                Puzzles.Add(puzzle);
            }
        }

        public static void ApplyPhysics()
        {
            foreach (var puzzle in ManagerPuzzle.Puzzles)
            {
                puzzle.Physics.UpdatePhysics();
            }
        }

        public static bool CheckCorrectPoisiton()
        {
            bool IsFree = false;
            foreach (Puzzle puzzle in Puzzles)
            {
                if (!puzzle.Physics.IsCorrectPosition)
                {
                    IsFree = true;
                }
            }
            return IsFree;
        }

    }
}
