using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OxyPlot;

namespace fishing
{
    class graphs
    {
        public string Title { get; private set; }
        public IList<DataPoint> orangef { get; private set; }
        public IList<DataPoint> bluef { get; private set; }
        public IList<DataPoint> tango { get; private set; }

        public graphs()
        {
            Title = "Ribolucia";
            orangef = new List<DataPoint>();
            bluef = new List<DataPoint>();
            tango = new List<DataPoint>();
            XDocument xdoc = XDocument.Load("D:\\Program\\fishing\\fishing\\stats.xml");

            foreach (XElement elem in xdoc.Element("simulation").Elements("round"))
            {
                XAttribute roundname = elem.Attribute("number");
                XElement ofcount = elem.Element("OrangeFish");
                XElement bfcount = elem.Element("BlueFish");
                double tcount = 30;
                if (roundname != null && ofcount != null && bfcount != null)
                {
                    DataPoint point1 = new DataPoint(double.Parse(roundname.Value), double.Parse(ofcount.Value));
                    DataPoint point2 = new DataPoint(double.Parse(roundname.Value), double.Parse(bfcount.Value));
                    DataPoint point3 = new DataPoint(double.Parse(roundname.Value), tcount);
                    orangef.Add(point1);
                    bluef.Add(point2);
                    tango.Add(point3);
                }
            }
        }
    }
}
