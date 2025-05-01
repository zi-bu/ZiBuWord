using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Services
{
    /// <summary>
    /// 彩蛋服务类，用于管理所有彩蛋相关的功能
    /// </summary>
    public class EasterEggService
    {
        private readonly Form _form;
        private int _counter = 0;
        private readonly List<string> _hiddenMessages = new List<string> { "喵", "喵喵", "喵喵喵" };
        private bool _isSpecialMode = false;
        private Point _lastClickPoint;
        private DateTime _lastClickTime = DateTime.MinValue;
        private readonly Random _random = new Random();
        private readonly Timer _animationTimer;
        private bool _isCtrlPressed = false;
        private int _catX = 0;
        private int _catY = 0;
        private bool _isEasterEggVisible = false;

        public EasterEggService(Form form)
        {
            _form = form;
            _form.DoubleBuffered = true;
            _form.KeyPreview = true;

            _animationTimer = new Timer();
            _animationTimer.Interval = 50;
            _animationTimer.Tick += OnTimerTick;

            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            _form.MouseClick += OnMouseClick;
            _form.KeyDown += OnKeyDown;
            _form.KeyUp += OnKeyUp;
            _form.Paint += OnPaint;

            foreach (Control control in _form.Controls)
            {
                control.MouseEnter += OnControlMouseEnter;
            }
        }

        private void OnControlMouseEnter(object sender, EventArgs e)
        {
            _counter++;
            if (_counter % 7 == 0 && !_isSpecialMode)
            {
                _isSpecialMode = true;
                _animationTimer.Start();
            }
        }

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            _lastClickPoint = e.Location;
            var now = DateTime.Now;

            if ((now - _lastClickTime).TotalMilliseconds < 500)
            {
                _counter++;
                if (_counter >= 3 && _isCtrlPressed)
                {
                    ActivateEasterEgg();
                }
            }
            _lastClickTime = now;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _isCtrlPressed = true;
            }
            else if (e.KeyCode == Keys.Escape && _isEasterEggVisible)
            {
                DeactivateEasterEgg();
            }
            else if (_isSpecialMode)
            {
                _counter++;
                if (_counter % 5 == 0)
                {
                    ShowHiddenMessage();
                }
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _isCtrlPressed = false;
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (_isEasterEggVisible)
            {
                _catX += 5;
                if (_catX > _form.ClientSize.Width)
                {
                    _catX = -100;
                    _catY = _random.Next(0, _form.ClientSize.Height - 100);
                }
                _form.Invalidate();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (_isEasterEggVisible)
            {
                using (Font font = new Font("Arial", 12))
                {
                    e.Graphics.DrawString("(=^･ω･^=)", font, Brushes.Black, _catX, _catY);
                }
            }
        }

        private void ActivateEasterEgg()
        {
            _isEasterEggVisible = true;
            _catX = _lastClickPoint.X;
            _catY = _lastClickPoint.Y;
            _animationTimer.Start();
            _form.Invalidate();
        }

        private void DeactivateEasterEgg()
        {
            _isEasterEggVisible = false;
            _animationTimer.Stop();
            _form.Invalidate();
        }

        private void ShowHiddenMessage()
        {
            string message = _hiddenMessages[_random.Next(_hiddenMessages.Count)];
            MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowEasterEggMessage()
        {
            MessageBox.Show("恭喜你发现了彩蛋，关注子布喵喵喵");
        }
    }
} 