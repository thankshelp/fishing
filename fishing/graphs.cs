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
       

        public graphs()
        {
            Title = "Ribolucia";
            orangef = new List<DataPoint>();
            bluef = new List<DataPoint>();

            XDocument xdoc = XDocument.Load("C:\\Users\\Виктория\\Desktop\\fishing\\fishing\\stats.xml");

            foreach (XElement elem in xdoc.Element("simulation").Elements("round"))
            {
                XAttribute attrName = elem.Attribute("round");
                XElement ofcount = elem.Element("OrangeFish");
                XElement bfcount = elem.Element("BlueFish");

                if (attrName != null && ofcount != null && bfcount != null)
                {
                    DataPoint point1 = new DataPoint(double.Parse(attrName.Value), double.Parse(ofcount.Value));
                    DataPoint point2 = new DataPoint(double.Parse(attrName.Value), double.Parse(bfcount.Value));

                    orangef.Add(point1);
                    bluef.Add(point2);
                }
            }
        }
    }
}
