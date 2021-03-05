using csGeoTools.Vincenty;
using SunamoExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace csGeoTools.Parsers
{
    public abstract class GeoPointParser
    {
static Type type = typeof(GeoPointParser);
        private static List<GeoPointParser> registeredParsers = new List<GeoPointParser>()
        {
            new DecimalDegreeParser()
        };
        
        public static GeoPointParser getParserFor(String coordinates)
        {
            return registeredParsers.Where(parser => parser.CanParse(coordinates)).First();
            ThrowExceptions.Custom(Exc.GetStackTrace(), type, Exc.CallingMethod(),"Could not find a parser for the given input");
        }
        
        public abstract bool CanParse(String input);
        
        public abstract GeoPoint Parse(String input, Ellipsoid referenceEllipsoid);
    }
}
