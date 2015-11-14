using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyWinFormsTcpApp
{
    public class XMLSerialize
    {
        [XmlElement("SocketConfiguration")]
        public SocketConfiguration SocketConfiguration { get; set; }
        [XmlIgnore]
        public string FileName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public XMLSerialize()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public XMLSerialize(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Constructor
        /// <param name="theResult"></param>
        /// <param name="sc"></param>
        /// <param name="fileName"></param>
        public XMLSerialize(SocketConfiguration sc, string fileName)
        {
            SocketConfiguration = sc;
            FileName = fileName;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="fileName"></param>
        public void Save()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLSerialize));

                var XmlWriter = new StreamWriter(FileName);
                serializer.Serialize(XmlWriter, this);
                XmlWriter.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="theResult"></param>
        /// <param name="sc"></param>
        public void Load(ref SocketConfiguration sc)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XMLSerialize));

                using (StreamReader rd = new StreamReader(FileName))
                {
                    var XmlImport = serializer.Deserialize(rd) as XMLSerialize;
                    sc = XmlImport.SocketConfiguration;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
