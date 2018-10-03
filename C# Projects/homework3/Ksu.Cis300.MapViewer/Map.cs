/* Map.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class Map : UserControl
    {
        /// <summary>
        /// max zoom level
        /// </summary>
        private const int _maxZoom = 6;

        /// <summary>
        /// current scale factor
        /// </summary>
        private int _scale;

        /// <summary>
        /// current zoom level
        /// </summary>
        private int _zoom = 0;

        /// <summary>
        /// contains the map data
        /// </summary>
        private QuadTree _data;

        /// <summary>
        /// Construtor for Map
        /// </summary>
        /// <param name="streets">list of streets needed to be drawn</param>
        /// <param name="bounds">rectange that</param>
        /// <param name="scale">scale of </param>
        public Map(List<StreetSegment> streets, RectangleF bounds, int scale)
        {
            for (int i = 0; i < streets.Count; i++)
            {
                if (!IsWithinBounds(streets[i].Start, bounds) && !IsWithinBounds(streets[i].End, bounds))
                {
                    throw new ArgumentException("Street " + i + " is not within the given bounds.");
                }
            }

            InitializeComponent();

            _data = new QuadTree(streets, bounds, _maxZoom);

            _scale = scale;

            Size = new Size ((int) bounds.Width * scale, (int) bounds.Height * scale);   
        }

        /// <summary>
        /// can the map be zoomed in
        /// </summary>
        public bool CanZoomIn
        {
            get
            { 
                return (_zoom < 0);
            }
        }

        /// <summary>
        /// can the map be zoomed out
        /// </summary>
        public bool CanZoomOut
        {
            get
            {
                return (_zoom > _maxZoom);
            }
        }

        /// <summary>
        /// zooms the map in by a factor of 2
        /// </summary>
        public void ZoomIn()
        {
            if (CanZoomIn)
            {
                _zoom += 1;
                _scale *= 2;
                Size = new Size(Size.Width * 2, Size.Height * 2);
            }

            Invalidate();
        }

        /// <summary>
        /// zooms the map out by a factor of 2
        /// </summary>
        public void ZoomOut()
        {
            if (CanZoomOut)
            {
                _zoom =- 1;
                _scale /= 2;
                Size = new Size(Size.Width / 2, Size.Height / 2);
            }

            Invalidate();
        }

        /// <summary>
        /// check to see if a given point is in the bounds of a given rectange
        /// </summary>
        /// <param name="point">point to check</param>
        /// <param name="rectangle">rectange for bounds</param>
        /// <returns>true or false if point in is bounds</returns>
        private static bool IsWithinBounds(PointF point, RectangleF rectangle)
        {
            if ((point.X >= rectangle.Left && point.X <= rectangle.Right) && (point.Y >= rectangle.Top && point.Y <= rectangle.Bottom))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// redraws on the map
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle clip = e.ClipRectangle;

            e.Graphics.Clip = new Region(clip);

            _data.Draw(e.Graphics, _scale, _zoom);
        }

    } // end Map class
}