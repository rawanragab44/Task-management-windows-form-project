using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationProject
{
    public partial class reportChart : UserControl
    {
        //public ReportProirty()
        //{
        //    InitializeComponent();
        //}

        private void reportChart_Load(object sender, EventArgs e)
        {

        }
        private int _value = 0;
        private int _maxValue = 100;
        private Color _progressColor = Color.Blue;
        private Color _backgroundColor = Color.LightGray;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = Math.Max(0, Math.Min(value, _maxValue)); // Keep within range
                Invalidate(); // Redraw control
            }
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = Math.Max(1, value); // Avoid division by zero
                Invalidate();
            }
        }

        public Color ProgressColor
        {
            get { return _progressColor; }
            set { _progressColor = value; Invalidate(); }
        }

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; Invalidate(); }
        }

        public reportChart()
        {
            InitializeComponent();
            this.Size = new Size(100, 100); // Default size
            this.DoubleBuffered = true; // Prevent flickering
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int width = this.Width;
            int height = this.Height;
            int thickness = 10; // Thickness of progress bar

            using (Pen backgroundPen = new Pen(_backgroundColor, thickness))
            using (Pen progressPen = new Pen(_progressColor, thickness))
            {
                g.DrawArc(backgroundPen, thickness, thickness, width - (2 * thickness), height - (2 * thickness), 0, 360);

                float sweepAngle = 360f * _value / _maxValue;
                g.DrawArc(progressPen, thickness, thickness, width - (2 * thickness), height - (2 * thickness), -90, sweepAngle);
            }

            // Draw percentage text
            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                string text = $"{_value}/{_maxValue}";
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, brush, (width - textSize.Width) / 2, (height - textSize.Height) / 2);
            }
        }
    }
}