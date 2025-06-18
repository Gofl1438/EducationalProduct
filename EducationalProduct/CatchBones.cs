using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalProduct
{
    public partial class CatchBones : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        Bitmap _cachedBackground;
        Bitmap _cachedButtonUI;
        public CatchBones()
        {
            InitializeComponent();
            StateCatchBones.Init();
            StateRuleMenu.Init();
            StateExitMenu.Init();
            СalibrationSize();
            ManagerBone.AddDefaultQuantityBones();
            ManagerUI.AddCatchBonesElements();
            ManagerUI.AddTotalElements();
            DrawElementsUI();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            if (StateExitMenu.СurrentStateMenuExitCatchBones) return;

            if (StateRuleMenu.СurrentStateMenuRuleCatchBones) return;

            if (!StateCatchBones.SingleView)
            {
                MenuRuleCheck();
                StateCatchBones.SingleView = true;
            }

            foreach (Bone bone in ManagerBone.Bones)
            {
                bone.Physics.MoveBone();
                CanvasCatchBones.Invalidate();
            }
            ManagerBone.ApplyPhysicsCollideMoveBone();
            ManagerBone.DeleteTouchBones();
            if (StateCatchBones.СurrentQuntityBones == GameConfig.CatchBones.Bone.DefaultQuantityBone)
            {
                if (!StateTransitonScene.IsNotCallCatchBonesAwait)
                {
                    Await();
                    StateTransitonScene.IsNotCallCatchBonesAwait = true;
                }
                if (StateTransitonScene.IsTransitonCatchBonesAwait)
                {
                    timer.Stop();
                    timer.Tick -= Update;
                    timer.Dispose();
                    TestScene testScene = new TestScene(); //указать нужную сцену//
                    testScene.Opacity = 0;
                    testScene.Show();
                    testScene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        testScene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    ManagerBone.Dispose();
                    ManagerUI.CatchBonesElements.Clear();
                    ManagerSound.DeleteActivePlayersCatchBones();
                    _cachedBackground.Dispose();
                    _cachedButtonUI.Dispose();
                    this.Hide();
                    this.Dispose();
                }
            }
        }

        private async Task Await()
        {
            await Task.Delay(1200);
            StateTransitonScene.IsTransitonCatchBonesAwait = true;
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasCatchBones.Size.Width, CanvasCatchBones.Size.Height));
        }
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                ManagerBone.Bones[i].DrawSprite(g);
            }
            DrawResult(g);
            g.DrawImage(_cachedButtonUI, 0, 0);
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleElementsCatchBones.Count; i++)
            {
                ManagerUI.RuleElementsCatchBones[i].DrawSprite(g);
            }
        }

        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButtonUI = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.CatchBonesElements.Count; i++)
                {
                    ManagerUI.CatchBonesElements[i].DrawSprite(bgGraphics);
                }
            }
            using (var bgGraphics = Graphics.FromImage(cachedButtonUI))
            {
                for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
                {
                    ManagerUI.TotalElements[i].DrawSprite(bgGraphics);
                }
            }
            _cachedBackground = cachedBackground;
            _cachedButtonUI = cachedButtonUI;
        }


        private void DrawResult(Graphics g)
        {
            string text = $"{StateCatchBones.СurrentQuntityBones} из {GameConfig.CatchBones.Bone.DefaultQuantityBone}";
            Font font = new Font(GameConfig.NumberPointsCatchBones.pfc.Families[0], GameConfig.NumberPointsCatchBones.SizeResult, GameConfig.NumberPointsCatchBones.StyleResult);

            g.DrawString(text, font, GameConfig.NumberPointsCatchBones.shadowBrush, GameConfig.NumberPointsCatchBones.shadowRect, GameConfig.NumberPointsCatchBones.format);

            g.DrawString(text, font, GameConfig.NumberPointsCatchBones.CustomBrush, GameConfig.NumberPointsCatchBones.rectangleResult, GameConfig.NumberPointsCatchBones.format);

            font.Dispose();
        }

        private void CatchBones_MouseDown(object sender, MouseEventArgs e)
        {
            if (!StateExitMenu.СurrentStateMenuExitCatchBones)
            {
                CheckMouseDownRule(e);
            }

            if (!StateRuleMenu.СurrentStateMenuRuleCatchBones)
            {
                CheckMouseDownExit(e);
            }

            if (!StateCatchBones.SingleView)
            {
                MenuRuleCheck();
                StateCatchBones.SingleView = true;
            }

            if (StateExitMenu.СurrentStateMenuExitCatchBones) return;

            if (StateRuleMenu.СurrentStateMenuRuleCatchBones) return;

            if (StateCatchBones.СurrentStateMenuClick)
            {
                StateCatchBones.СurrentStateMenuClick = false;
                return;
            }

            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var bone = ManagerBone.Bones[i];
                Size size = ManagerBone.Bones[i].Physics.Size;
                if (new RectangleF(new PointF(bone.Transform.Position.X, bone.Transform.Position.Y),
                    size).Contains(e.Location))
                {
                    ManagerBone.Bones[i].IsTouchedUser = true;
                    using (var player = new SoundPlayer(Properties.Resources.CatchBonesClickBones))
                    {
                        ManagerSound.activePlayersCatchBones.Add(player);
                        player.Play();
                    }
                    StateCatchBones.СurrentQuntityBones += 1;
                }
            }
        }
        private void CheckMouseDownRule(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnQuestion.PositionOx, GameConfig.TotalElement.BtnQuestion.PositionOy),
               new Size(GameConfig.TotalElement.BtnQuestion.Width, GameConfig.TotalElement.BtnQuestion.Height)).Contains(e.Location))
            {
                if (!StateRuleMenu.СurrentStateMenuRuleCatchBones)
                {
                    MenuRuleCheck();
                }
            }

            if (!StateRuleMenu.СurrentStateMenuRuleCatchBones) return;

            if (new RectangleF(new PointF(GameConfig.RuleInfScene.ButtonApply.PositionOx, GameConfig.RuleInfScene.ButtonApply.PositionOy),
                new Size(GameConfig.RuleInfScene.ButtonApply.Width, GameConfig.RuleInfScene.ButtonApply.Height)).Contains(e.Location))
            {
                ManagerUI.RuleElementsCatchBones.Clear();
                StateRuleMenu.СurrentStateMenuRuleCatchBones = false;
                StateCatchBones.СurrentStateMenuClick = true;
            }
        }
        private void MenuRuleCheck()
        {
            ManagerUI.AddRuleElementsCatchBones();
            ManagerSound.DeleteActivePlayersCatchBones();
            CanvasCatchBones.Invalidate();
            StateRuleMenu.СurrentStateMenuRuleCatchBones = true;
            StateCatchBones.СurrentStateMenuClick = true;
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.СurrentStateMenuExitCatchBones)
                {
                    ManagerSound.DeleteActivePlayersCatchBones();
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasCatchBones.Invalidate();
                    StateExitMenu.СurrentStateMenuExitCatchBones = true;
                    StateCatchBones.СurrentStateMenuClick = true;
                }
            }

            if (!StateExitMenu.СurrentStateMenuExitCatchBones) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateCatchBones.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitCatchBones = false;
                timer.Stop();
                timer.Tick -= Update;
                timer.Dispose();
                if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
                {
                    mainForm.Opacity = 0;
                    mainForm.Show();
                    mainForm.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        mainForm.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                        CanvasCatchBones.Invalidate();
                    }
                    ManagerBone.Dispose();
                    ManagerUI.CatchBonesElements.Clear();
                    ManagerUI.TotalElementsMenuExit.Clear();
                    ManagerSound.DeleteActivePlayersCatchBones();
                    _cachedBackground.Dispose();
                    _cachedButtonUI.Dispose();
                    this.Hide();
                    this.Dispose();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.СurrentStateMenuExitCatchBones = false;
                StateCatchBones.СurrentStateMenuClick = true;
            }
        }

        private void CatchBones_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagerBone.Dispose();
            _cachedBackground.Dispose();
            _cachedButtonUI.Dispose();
            timer.Stop();
            timer.Tick -= Update;
            timer.Dispose();
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
