/* UserInterface.cs
 * Author: Trey Moddelmog
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.MapViewer
{
    public partial class UserInterface : Form
    {
        /// <summary>
        /// initial scale for map viewer
        /// </summary>
        private int _initialScale = 10;

        /// <summary>
        /// Current map
        /// </summary>
        private Map _currentMap;

        public UserInterface()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// reads in a file giving points and bounds for map
        /// </summary>
        /// <param name="fn">name of file to be open</param>
        /// <param name="bounds">bounds of the map</param>
        /// <returns>list of street segments to construct map</returns>
        private List<StreetSegment> ReadFile(string fn, out RectangleF bounds)
        {
            using (StreamReader input = new StreamReader(fn))
            {
                string[] line = input.ReadLine().Split(',');

                bounds = new RectangleF(0, 0, Convert.ToSingle(line[0]), Convert.ToSingle(line[1]));

                List<StreetSegment> streets = new List<StreetSegment>();

                while (!input.EndOfStream)
                {
                    line = input.ReadLine().Split(',');

                    PointF start = new PointF(Convert.ToSingle(line[0]), Convert.ToSingle(line[1]));
                    PointF end = new PointF(Convert.ToSingle(line[2]), Convert.ToSingle(line[3]));
                    Color color = Color.FromArgb(Convert.ToInt32(line[4]));
                    float width = Convert.ToSingle(line[5]);
                    int visibleLevels = Convert.ToInt32(line[6]);

                    streets.Add(new StreetSegment(end, start, color, width, visibleLevels));
                }
                return streets;
            } // end using
        }

        /// <summary>
        /// opens file dialog and reads in file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenMap_Click(object sender, EventArgs e)
        {
            if (uxOpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RectangleF rectangle;
                    List<StreetSegment> streets = ReadFile(uxOpenDialog.FileName, out rectangle);

                    _currentMap = new Map(streets, rectangle, _initialScale);

                    uxMapContainer.Controls.Clear();
                    uxMapContainer.Controls.Add(_currentMap);

                    uxZoomIn.Enabled = true;
                    uxZoomOut.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// zooms in on map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomIn_Click(object sender, EventArgs e)
        {
            Point currentScrollPos = uxMapContainer.AutoScrollPosition;
            currentScrollPos.X *= -1;
            currentScrollPos.Y *= -1;

            _currentMap.ZoomIn();

            //uxZoomIn.Enabled = _currentMap.CanZoomIn;
            //uxZoomOut.Enabled = _currentMap.CanZoomOut;

            if (_currentMap.CanZoomIn)
            {
                uxZoomIn.Enabled = true;
                uxZoomOut.Enabled = true;
            }
            else
            {
                uxZoomIn.Enabled = false;
                uxZoomOut.Enabled = true;
            }


            Size s = uxMapContainer.ClientSize;
            uxMapContainer.AutoScrollPosition = new Point(currentScrollPos.X * 2 + s.Width / 2, currentScrollPos.Y * 2 + s.Height / 2);
        }

        /// <summary>
        /// zooms out on map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxZoomOut_Click(object sender, EventArgs e)
        {
            Point currentScrollPos = uxMapContainer.AutoScrollPosition;
            currentScrollPos.X *= -1;
            currentScrollPos.Y *= -1;

            _currentMap.ZoomOut();

            //uxZoomIn.Enabled = _currentMap.CanZoomIn;
            //uxZoomOut.Enabled = _currentMap.CanZoomOut;

            if (_currentMap.CanZoomOut)
            {
                uxZoomIn.Enabled = true;
                uxZoomOut.Enabled = true;
            }
            else
            {
                uxZoomIn.Enabled = true;
                uxZoomOut.Enabled = false;
            }

            Size s = uxMapContainer.ClientSize;
            uxMapContainer.AutoScrollPosition = new Point(currentScrollPos.X / 2 - s.Width / 2, currentScrollPos.Y / 2 - s.Height / 2);
        }
    } // end UserInterface
}