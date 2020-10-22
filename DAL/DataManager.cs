using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using Newtonsoft.Json;

namespace DAL
{
    public class DataManager
    {
        public void Serialize(List<Podcast> podcastList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podcastList.GetType());
            using (FileStream outFile = new FileStream("Podcasts.xml", FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, personList);
            }
        }

        public List<Podcast> Deserialize()
        {
            List<Podcast> listOfPodcastsToBeReturned;
            XmlSerialzer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            using FileStream inFile = new FileStream("Podcasts.xml", FileMode.Open,
                FileAccess.Read))
            {
                listOfPersonsToBeReturned = (List<Podcast>)xmlSerializer.Deserialize(inFile);
            }
            return listOfPodcastsToBeReturned;
        }
    }
}
