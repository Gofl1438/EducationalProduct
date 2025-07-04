﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle;

namespace EducationalProduct.Classes
{
    public static class ManagerPuzzle
    {
        public static List<Puzzle> Puzzles = new List<Puzzle>();
        public static List<SolidRocketPuzzle> SolidRocketPuzzles = new List<SolidRocketPuzzle>();

        public static void AddDefaultPuzzles()
        {
            PuzzlesType[] puzzleTypes = (PuzzlesType[])Enum.GetValues(typeof(PuzzlesType));

            foreach (PuzzlesType type in puzzleTypes)
            {
                Puzzle puzzle = new Puzzle(type);
                Puzzles.Add(puzzle);
            }
        }

        public static void Dispose()
        {
            foreach (var type in Puzzles)
            {
                type.Dispose();
            }
            foreach (var type in SolidRocketPuzzles)
            {
                type.Dispose();
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
            if (StateCollectPuzzle.countFreePuzzles == 0 && !StateCollectPuzzle.rocketLaunch)
            {
                StateCollectPuzzle.rocketLaunch = true;
                foreach (var type in Puzzles)
                {
                    type.Dispose();
                }
                Puzzles.Clear();
                SolidRocketPuzzles.Add(new SolidRocketPuzzle());
                using (var player = new SoundPlayer(Properties.Resources.CollectPuzzleSingleRocketTakeoff))
                {
                    ManagerSound.activePlayersColleсtPuzzle.Add(player);
                    player.Play();
                }
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
                    SolidRocketPuzzles[i].Dispose();
                    SolidRocketPuzzles.Clear();
                    StateTransitonScene.IsTransitonColleсtPuzzle = true;
                }
            }
        }

        public static bool CheckCorrectPoisiton()
        {
            bool IsFree = false;
            StateCollectPuzzle.countFreePuzzles = 0;
            foreach (Puzzle puzzle in Puzzles)
            {
                if (!puzzle.Physics.IsCorrectPosition)
                {
                    IsFree = true;
                    StateCollectPuzzle.countFreePuzzles += 1;
                }
            }
            return IsFree;
        }

    }
}
