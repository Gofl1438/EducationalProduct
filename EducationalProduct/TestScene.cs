using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct
{
    public partial class TestScene : Form
    {
        Rectangle workingArea;
        public TestScene()
        {
            InitializeComponent();
            СalibrationSize();
            StateExitMenu.Init();
            StateChooseAnswer.Init();
            ManagerUI.AddTestInterfaceElements();
            ManagerUI.AddTestRepeatAction();
            ManagerUI.AddTestCatchBones();
            ManagerUI.AddTestCollectPuzzle();
            ManagerUI.AddTestDodgeMeteorites();
            ManagerUI.AddBtnClosedElement();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasTestScene.Size.Width, CanvasTestScene.Size.Height));
        }

        private void TestScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
            {
                ManagerUI.BtnClosedElement[i].DrawSprite(g);
            }

            for (int i = 0; i < ManagerUI.TestInterfaceElements.Count; i++)
            {
                if ((ManagerUI.TestInterfaceElements[i] == CashElementUI.TestInterfaceElements.btnNextPlay && !StateChooseAnswer.goNext) || 
                    (ManagerUI.TestInterfaceElements[i] == CashElementUI.TestInterfaceElements.success && !StateChooseAnswer.showSuccess) ||
                    (ManagerUI.TestInterfaceElements[i] == CashElementUI.TestInterfaceElements.btnAnswer && !StateChooseAnswer.chooseAnswer))
                    continue;

                ManagerUI.TestInterfaceElements[i].DrawSprite(g);
            }

            for (int i = 0; i < ManagerUI.TestRepeatActionElements.Count; i++)
            {
                if (((i == 1) && !StateChooseAnswer.showTip))
                    continue;

                if (StateCurrentScene.RepeatActionScene)
                    ManagerUI.TestRepeatActionElements[i].DrawSprite(g);

                if (StateCurrentScene.CatchBonesScene)
                    ManagerUI.TestCatchBonesElements[i].DrawSprite(g);

                if (StateCurrentScene.CollectPuzzleScene)
                    ManagerUI.TestCollectPuzzleElements[i].DrawSprite(g);

                if (StateCurrentScene.DodgeMeteoritesScene)
                    ManagerUI.TestDodgeMeteoritesElements[i].DrawSprite(g);
            }

            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }

        private void TestScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);

            if (StateExitMenu.CurrentStateMenuExitTestScene) return;

            if (!StateChooseAnswer.answerIsGiven)
            {
                CheckMouseDownAnswer(e);
                CheckMouseDownBtnAnswer(e);
                return;
            }

            if (new RectangleF(new PointF(GameConfig.TestInterface.BtnNextPlay.PositionOx, GameConfig.TestInterface.BtnNextPlay.PositionOy),
                new Size(GameConfig.TestInterface.BtnNextPlay.Width, GameConfig.TestInterface.BtnNextPlay.Height)).Contains(e.Location))
            {
                if (StateCurrentScene.RepeatActionScene)
                {
                    RuleCatchBonesScene scene = new RuleCatchBonesScene();

                    scene.Opacity = 0;
                    scene.Show();
                    scene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        scene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }

                if (StateCurrentScene.CatchBonesScene)
                {
                    RuleCollectPuzzleScene scene = new RuleCollectPuzzleScene();

                    scene.Opacity = 0;
                    scene.Show();
                    scene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        scene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }

                if (StateCurrentScene.CollectPuzzleScene)
                {
                    RuleDodgeMeteoritesScene scene = new RuleDodgeMeteoritesScene();

                    scene.Opacity = 0;
                    scene.Show();
                    scene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        scene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }

                if (StateCurrentScene.DodgeMeteoritesScene)
                {
                    EndScene scene = new EndScene();

                    scene.Opacity = 0;
                    scene.Show();
                    scene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        scene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitTestScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasTestScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitTestScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitTestScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateExitMenu.CurrentStateMenuExitTestScene = false;
                if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
                {
                    mainForm.Opacity = 0;
                    mainForm.Show();
                    mainForm.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        mainForm.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                        CanvasTestScene.Invalidate();
                    }
                    ManagerUI.TotalElementsMenuExit.Clear();
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitTestScene = false;
                CanvasTestScene.Invalidate();
            }
        }

        private void CheckMouseDownAnswer(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TestRepeatAction.Answer1.PositionOx, GameConfig.TestRepeatAction.Answer1.PositionOy),
                new Size(GameConfig.TestRepeatAction.Answer1.Width, GameConfig.TestRepeatAction.Answer1.Height)).Contains(e.Location))
            {
                StateChooseAnswer.chooseAnswer = true;

                if (StateCurrentScene.RepeatActionScene)
                    StateChooseAnswer.trueAnswer = true;
                else
                    StateChooseAnswer.trueAnswer = false;

                //AnswerHighlight.Highlight("TRA1");
                CanvasTestScene.Invalidate();
            }

            else if (new RectangleF(new PointF(GameConfig.TestRepeatAction.Answer2.PositionOx, GameConfig.TestRepeatAction.Answer2.PositionOy),
                new Size(GameConfig.TestRepeatAction.Answer2.Width, GameConfig.TestRepeatAction.Answer2.Height)).Contains(e.Location))
            {
                StateChooseAnswer.chooseAnswer = true;

                if (StateCurrentScene.DodgeMeteoritesScene)
                    StateChooseAnswer.trueAnswer = true;
                else
                    StateChooseAnswer.trueAnswer = false;

                //AnswerHighlight.Highlight("TRA2");
                CanvasTestScene.Invalidate();
            }

            else if (new RectangleF(new PointF(GameConfig.TestRepeatAction.Answer3.PositionOx, GameConfig.TestRepeatAction.Answer3.PositionOy),
                new Size(GameConfig.TestRepeatAction.Answer3.Width, GameConfig.TestRepeatAction.Answer3.Height)).Contains(e.Location))
            {
                StateChooseAnswer.chooseAnswer = true;

                if (StateCurrentScene.CollectPuzzleScene)
                    StateChooseAnswer.trueAnswer = true;
                else
                    StateChooseAnswer.trueAnswer = false;

                //AnswerHighlight.Highlight("TRA3");
                CanvasTestScene.Invalidate();
            }

            else if (new RectangleF(new PointF(GameConfig.TestRepeatAction.Answer4.PositionOx, GameConfig.TestRepeatAction.Answer4.PositionOy),
                new Size(GameConfig.TestRepeatAction.Answer4.Width, GameConfig.TestRepeatAction.Answer4.Height)).Contains(e.Location))
            {
                StateChooseAnswer.chooseAnswer = true;

                if (StateCurrentScene.CatchBonesScene)
                    StateChooseAnswer.trueAnswer = true;
                else
                    StateChooseAnswer.trueAnswer = false;

                //AnswerHighlight.Highlight("TRA4");
                CanvasTestScene.Invalidate();
            }
        }

        private void CheckMouseDownBtnAnswer(MouseEventArgs e)
        {
            if (StateChooseAnswer.chooseAnswer)
                if (new RectangleF(new PointF(GameConfig.TestInterface.BtnAnswer.PositionOx, GameConfig.TestInterface.BtnAnswer.PositionOy),
                    new Size(GameConfig.TestInterface.BtnAnswer.Width, GameConfig.TestInterface.BtnAnswer.Height)).Contains(e.Location))
                {
                    StateChooseAnswer.goNext = true;

                    if (StateChooseAnswer.trueAnswer)
                        StateChooseAnswer.showSuccess = true;
                    else
                        StateChooseAnswer.showTip = true;

                    StateChooseAnswer.answerIsGiven = true;
                    CanvasTestScene.Invalidate();
                }
        }
        private void TestScene_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
            {
                mainForm.Dispose();
            }
            Application.Exit();
        }
    }
}
