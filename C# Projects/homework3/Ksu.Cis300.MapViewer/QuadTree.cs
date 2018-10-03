/* QuadTree.cs
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
    public class QuadTree
    {   
        /// <summary>
        /// tree holding all child in the southwest
        /// </summary>
        private QuadTree _southwestChild;

        /// <summary>
        /// tree holding all child in the southeast
        /// </summary>
        private QuadTree _southeastChild;

        /// <summary>
        /// tree holding all child in the northwest
        /// </summary>
        private QuadTree _northwestChild;

        /// <summary>
        /// tree holding all child in the northeast
        /// </summary>
        private QuadTree _northeastChild;

        /// <summary>
        /// rectangle giving the bounds of the map
        /// </summary>
        private RectangleF _bounds;

        /// <summary>
        /// list holding all of the street segments
        /// </summary>
        private List<StreetSegment> _streets;

        /// <summary>
        /// constructor for a QuadTree
        /// </summary>
        /// <param name="streets">list of street segments</param>
        /// <param name="rectangle">bounds of the map</param>
        /// <param name="height">level height</param>
        public QuadTree(List<StreetSegment> streets, RectangleF rectangle, int height)
        {
            _bounds = rectangle;

            if (height == 0)
            {
                _streets = streets;
                //_southwestChild = null;
                //_southeastChild = null;
                //_northwestChild = null;
                //_northeastChild = null;
            }
            else
            {
                List<StreetSegment> visible = new List<StreetSegment>();
                List<StreetSegment> invisible = new List<StreetSegment>();

                SplitHeight(streets, height, visible, invisible);

                _streets = visible;
                
                List<StreetSegment> east = new List<StreetSegment>();
                List<StreetSegment> west = new List<StreetSegment>();
                List<StreetSegment> north = new List<StreetSegment>();
                List<StreetSegment> south = new List<StreetSegment>();

                float x = (rectangle.Width / 2) + rectangle.Left;
                float y = (rectangle.Height / 2) + rectangle.Top;

                SplitEastWest(streets, x, west, east);
                SplitNorthSouth(streets, y, north, south);

                List<StreetSegment> southwest = new List<StreetSegment>();
                List<StreetSegment> southeast = new List<StreetSegment>();
                List<StreetSegment> northwest = new List<StreetSegment>();
                List<StreetSegment> northeast = new List<StreetSegment>();

                SplitEastWest(north, x, northwest, northeast);
                SplitEastWest(south, x, southwest, southeast);

                _southwestChild = new QuadTree(southwest, new RectangleF(rectangle.Left, height/2, rectangle.Width/2, rectangle.Height/2), height-1);
                _southeastChild = new QuadTree(southeast, new RectangleF(x, y, rectangle.Width / 2, rectangle.Height / 2), height - 1);
                _northwestChild = new QuadTree(northwest, new RectangleF(rectangle.Left, rectangle.Top, rectangle.Width / 2, rectangle.Height/2), height-1);
                _northeastChild = new QuadTree(northeast, new RectangleF(x, rectangle.Top, rectangle.Width / 2, rectangle.Height / 2), height - 1);
            }
        }

        /// <summary>
        /// Draws the contents of the tree
        /// </summary>
        /// <param name="graphics">the graphic being drawn on</param>
        /// <param name="scale">scale factor for pixel coordinates</param>
        /// <param name="depth">depth of the tree nodes</param>
        public void Draw(Graphics graphics, int scale, int depth)
        {
            RectangleF newRect = new RectangleF(graphics.ClipBounds.X/scale, graphics.ClipBounds.Y / scale, graphics.ClipBounds.Width / scale, graphics.ClipBounds.Height / scale);

            if (_bounds.IntersectsWith(newRect))
            {
                for (int i = 0; i < _streets.Count; i++)
                {
                    _streets[i].Draw(graphics, scale);
                }

                if (depth > 0)
                {
                    _southwestChild.Draw(graphics, scale, depth - 1);
                    _southeastChild.Draw(graphics, scale, depth - 1);
                    _northwestChild.Draw(graphics, scale, depth - 1);
                    _northeastChild.Draw(graphics, scale, depth - 1);

                }
            }
        }

        /// <summary>
        /// splits list of streets into east and west
        /// </summary>
        /// <param name="streets">list of streets to split</param>
        /// <param name="x">point to determine east and west sides</param>
        /// <param name="west">list to put all west street segments</param>
        /// <param name="east">list to put all east street segments</param>
        private static void SplitEastWest(List<StreetSegment> streets, float x, List<StreetSegment> west, List<StreetSegment> east)
        {
            for (int i = 0; i < streets.Count; i++)
            {
                if (streets[i].Start.X <= x && streets[i].End.X <= x)
                {
                    west.Add(streets[i]);
                }
                else if (streets[i].Start.X >= x && streets[i].End.X >= x)
                {
                    east.Add(streets[i]);
                }
                else
                {
                    float y = (((streets[i].End.Y - streets[i].Start.Y) * (x - streets[i].Start.X)) / (streets[i].End.X - streets[i].Start.X)) + streets[i].Start.Y;

                    StreetSegment copy1 = streets[i];
                    StreetSegment copy2 = streets[i];

                    copy1.Start = new PointF(x, y);
                    copy2.End = new PointF(x, y);

                    if (copy1.End.X <= x)
                    {
                        west.Add(copy1);
                        east.Add(copy2);
                    }
                    else
                    {
                        west.Add(copy2);
                        east.Add(copy1);
                    }


                }
            }
        }

        /// <summary>
        /// splits list of streets into east and west
        /// </summary>
        /// <param name="streets">list of streets to split</param>
        /// <param name="y">point to determine north and south sides</param>
        /// <param name="north">list to put all north street segments</param>
        /// <param name="south">list to put all south street segments</param>
        private static void SplitNorthSouth(List<StreetSegment> streets, float y, List<StreetSegment> north, List<StreetSegment> south)
        {
            for (int i = 0; i < streets.Count; i++)
            {
                if (streets[i].Start.Y <= y && streets[i].End.Y <= y)
                {
                    south.Add(streets[i]);
                }
                else if (streets[i].Start.Y >= y && streets[i].End.Y >= y)
                {
                    north.Add(streets[i]);
                }
                else
                {
                    float x = (((streets[i].End.X - streets[i].Start.X) * (y - streets[i].Start.Y)) / (streets[i].End.Y - streets[i].Start.Y)) + streets[i].Start.X;

                    StreetSegment copy1 = streets[i];
                    StreetSegment copy2 = streets[i];

                    copy1.Start = new PointF(x, y);
                    copy2.End = new PointF(x, y);

                    if (copy1.End.Y <= y)
                    {
                        south.Add(copy1);
                        north.Add(copy2);
                    }
                    else
                    {
                        south.Add(copy2);
                        north.Add(copy1);
                    }

                }
            }
        }

        /// <summary>
        /// splits the list of street segments into visible and invisible by by height
        /// </summary>
        /// <param name="streets">list of streets to split</param>
        /// <param name="height">height to compare for visibility</param>
        /// <param name="visible">ist to put all visible street segments</param>
        /// <param name="invisible">ist to put all invisible street segments</param>
        private static void SplitHeight(List<StreetSegment> streets, int height, List<StreetSegment> visible, List<StreetSegment> invisible)
        {
            for (int i = 0; i < streets.Count; i++)
            {
                if (streets[i].VisibleLevels > height)
                {
                    visible.Add(streets[i]);
                }
                else
                {
                    invisible.Add(streets[i]);
                }
            }
        }
    } // end QuadTree
}
