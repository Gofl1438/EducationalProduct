﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites;
using static EducationalProduct.Classes.StateRepeatButton;

namespace EducationalProduct.Classes
{
    public static class ManagerButtonRepeat
    {
        public static List<ButtonRepeat> ButtonRepeat = new List<ButtonRepeat>();
        private static CancellationTokenSource _buttonDelayCts = new CancellationTokenSource();
        private static List<int> _currentSequence = new List<int>();
        private static Random random = new Random();

        public static void AddDefaultButtonsRepeat()
        {
            ButtonRepeatType[] buttonRepeatTypes = (ButtonRepeatType[])Enum.GetValues(typeof(ButtonRepeatType));

            for (int i = 0; i < buttonRepeatTypes.Length; i++)
            {
                ButtonRepeat buttonRepeat = new ButtonRepeat(i, buttonRepeatTypes[i]);
                ButtonRepeat.Add(buttonRepeat);
            }
        }
        public static void Dispose()
        {
            foreach (var bt in ButtonRepeat)
            {
                bt.Dispose();
            }
        }
        
        public static void DeleteManagerButtonRepeat()
        {

            _currentSequence.Clear();
            ButtonRepeat.Clear();
        }

        public static async Task NewSequence()
        {
            int randomButtonId = random.Next(0, ButtonRepeat.Count);
            _currentSequence.Add(randomButtonId);
            await PlaySequence(StateRepeatButton.cts.Token);
        }

        public static void ChangeButtonConditionEnd()
        {
            if (GameConfig.RepeatAction.MaxQuntitySequence == СurrentQuntitySequence)
            {
                foreach (var button in ButtonRepeat)
                {
                    button.IsActiveInSequence = true;
                }
            }
        }

        public static async Task PlaySequence(CancellationToken cancellationToken = default)
        {
            IsPlayingSequence = true;
            try
            {
                foreach (var buttonId in _currentSequence)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    if (StateRepeatButton.ErorClickButton)
                    {
                        ButtonRepeat[buttonId].IsActiveInSequence = false;
                        IsPlayingSequence = false;
                        return;
                    }

                    await Task.Delay(1000, cancellationToken);

                    ButtonRepeat[buttonId].IsActiveInSequence = true;
                    using (var player = new SoundPlayer(Properties.Resources.RepeatButtonClick))
                    {
                        ManagerSound.activePlayersRepeatAction.Add(player);
                        player.Play();
                    }

                    await Task.Delay(1000, cancellationToken);
                    ButtonRepeat[buttonId].IsActiveInSequence = false;
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                foreach (var button in ButtonRepeat)
                {
                    button.IsActiveInSequence = false;
                }
                IsPlayingSequence = false;
            }
        }

        public static async Task PressButton(int buttonId)
        {
            if (ButtonRepeat[buttonId].IsActiveInSequence)
            {
                StateRepeatButton.PressButtonAnimation = true;
                await Task.Delay(500, _buttonDelayCts.Token);
                ButtonRepeat[buttonId].IsActiveInSequence = false;
                StateRepeatButton.PressButtonAnimation = false;
            }
        }

        public static bool TryPressButton(int buttonId)
        {
            if (_currentSequence[CurrentStep] == buttonId)
            {
                CurrentStep++;
                if (CurrentStep == _currentSequence.Count)
                {
                    Debug.WriteLine(CurrentStep);
                    StateRepeatButton.СurrentQuntitySequence++;
                    SequenceСompleted = true;
                    CurrentStep = 0;
                }
                return true;
            }
            _currentSequence.Clear();
            CurrentStep = 0;
            GameOver();
            return false;
        }

        private static async Task GameOver()
        {
            IsSceneGameOver = true;
            SoundPlayer player = new SoundPlayer(Properties.Resources.RepeatButtonGameOver);
            ManagerSound.activePlayersRepeatAction.Add(player);
            player.Play();
            for (int i = 0; i < GameConfig.RepeatAction.FrequencyGameOver; i++)
            {
                foreach (var button in ButtonRepeat)
                {
                    button.IsActiveInSequence = true;
                }
                await Task.Delay(100);
                foreach (var button in ButtonRepeat)
                {
                    button.IsActiveInSequence = false;
                }
                await Task.Delay(100);
            }
            player.Stop();
            player.Dispose();
            IsSceneGameOver = false;
        }
    }
}
