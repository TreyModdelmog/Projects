/* StreetSegment.cs
 * Author: Trey Moddelmog
 */

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.MapViewer
{
    public struct StreetSegment
    {
        /// <summary>
        /// end point for the street segment
        /// </summary>
        PointF _end;

        /// <summary>
        /// start point for the street segment
        /// </summary>
        PointF _start;

        /// <summary>
        /// pen to draw streets
        /// </summary>
        Pen _pen;

        /// <summary>
        /// number of levels visible at given zoom
        /// </summary>
        int _visibleLevels;

        /// <summary>
        /// Getter and Setter for _end
        /// </summary>
        public PointF End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }

        /// <summary>
        /// Getter and Setter for _start
        /// </summary>
        public PointF Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }

        /// <summary>
        /// Getter and Setter for _visibleLevels
        /// </summary>
        public int VisibleLevels
        {
            get
            {
                return _visibleLevels;
            }
        }

        /// <summary>
        /// constructor for StreetSegment
        /// </summary>
        /// <param name="end">set to _end</param>
        /// <param name="start">set to _start</param>
        /// <param name="c">used to construct a Pen</param>
        /// <param name="width">used to construct a Pen</param>
        /// <param name="levels">set to _visibleLevels</param>
        public StreetSegment(PointF end, PointF start, Color c, float width, int levels)
        {
            _end = end;
            _start = start;
            _pen = new Pen(c, width);
            _visibleLevels = levels;
        }

        /// <summary>
        /// draws the street segment
        /// </summary>
        /// <param name="graphics">context on which to draw</param>
        /// <param name="scale">the scale factor for translating the map coordinates to pixel coordinates</param>
        public void Draw(Graphics graphics, int scale)
        {
            graphics.DrawLine(_pen, (_start.X * scale), (_start.Y * scale), (_end.X * scale), (_end.Y * scale));
        }
    }
}
