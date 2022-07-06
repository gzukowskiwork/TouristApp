using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Infrastructure.FileStore
{
    public class GpxProcessor : IGpxProcessor
    {
        public List<Coordinate> LoadGPXWaypoints(string sFile)
        {
            XDocument gpxDoc = GetGpxDoc(sFile);
            XNamespace gpx = GetGpxNameSpace();
            List<Coordinate> waypointsList = new List<Coordinate>();

            int trackPointIdCounter = 0;

            var waypoints = from waypoint in gpxDoc.Descendants(gpx + "wpt")
                            select new Coordinate
                            {
                                TrackPointId = trackPointIdCounter++,
                                Latitude = double.Parse(waypoint.Attribute("lat").Value, CultureInfo.InvariantCulture),
                                Longitude = double.Parse(waypoint.Attribute("lon").Value, CultureInfo.InvariantCulture),
                                Altitude = waypoint.Element(gpx + "ele") != null ?
                                double.Parse(waypoint.Element(gpx + "ele").Value, CultureInfo.InvariantCulture) : null
                            };

            foreach (var wpt in waypoints)
            {
                waypointsList.Add(wpt);
            }

            return waypointsList;
        }

        public List<Coordinate> LoadGPXTracks(string sFile)
        {
            XDocument gpxDoc = GetGpxDoc(sFile);
            XNamespace gpx = GetGpxNameSpace();

            int trackPointIdCounter = 0;

            var tracks = from track in gpxDoc.Descendants(gpx + "trk")
                         select new
                         {
                             Name = track.Element(gpx + "name") != null ?
                            track.Element(gpx + "name").Value : null,
                             Segs = from trackpoint in track.Descendants(gpx + "trkpt")
                                    select new Coordinate
                                    {
                                        TrackPointId = trackPointIdCounter++,
                                        Latitude = double.Parse(trackpoint.Attribute("lat").Value, CultureInfo.InvariantCulture),
                                        Longitude = double.Parse(trackpoint.Attribute("lon").Value, CultureInfo.InvariantCulture),
                                        Altitude = trackpoint.Element(gpx + "ele") != null ?
                                        double.Parse(trackpoint.Element(gpx + "ele").Value, CultureInfo.InvariantCulture) : null
                                    }
                         };

            List<Coordinate> waypointsList = new List<Coordinate>();

            foreach (var trk in tracks)
            {
                foreach (var trkSeg in trk.Segs)
                {
                    waypointsList.Add(trkSeg);
                }
            }
            return waypointsList;
        }

        private XDocument GetGpxDoc(string sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);
            return gpxDoc;
        }

        private XNamespace GetGpxNameSpace()
        {
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return gpx;
        }
    }
}
