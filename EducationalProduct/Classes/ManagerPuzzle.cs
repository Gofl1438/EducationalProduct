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
        public static List<SolidRocketPuzzle> SolidRocketPuzzles = new List<SolidRocketPuzzle>();
        private static int countFreePuzzles = 0;
        private static bool rocketLaunch = false;

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
            if (!CheckCorrectPoisiton())
            {
                ApplyPhyscisSolidRocket();
            }
            foreach (var puzzle in Puzzles)
            {
                puzzle.Physics.UpdatePhysics();
            }
            if (countFreePuzzles == 0 && !rocketLaunch)
            {
                rocketLaunch = true;
                Puzzles.Clear();
                SolidRocketPuzzles.Add(new SolidRocketPuzzle());
            }
        }
        private static void ApplyPhyscisSolidRocket()
        {
            for (int i = 0; i < SolidRocketPuzzles.Count; i++)
            {
                SolidRocketPuzzles[i].MoveOxRight();
            }
            DeleteEndRocket();
        }

        private static void DeleteEndRocket()
        {
            for (int i = 0; i < SolidRocketPuzzles.Count; i++)
            {
                if (SolidRocketPuzzles[i].Transform.Position.X >= CanvasProduct.Width)
                {
                    SolidRocketPuzzles.Clear();
                    StateTransitonScene.IsTransitonColleсtPuzzle = true;
                }
            }
        }

        public static bool CheckCorrectPoisiton()
        {
            bool IsFree = false;
            countFreePuzzles = 0;
            foreach (Puzzle puzzle in Puzzles)
            {
                if (!puzzle.Physics.IsCorrectPosition)
                {
                    IsFree = true;
                    countFreePuzzles += 1;
                }
            }
            return IsFree;
        }

    }
}
