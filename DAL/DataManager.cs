using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using DAL.Repositories;

namespace DAL
{
    public class DataManager
    {
        private readonly string fileOfPodcasts = @"Podcasts.xml";
        public List<Podcast> listOfPodcasts = new List<Podcast>();
        protected string savedCategories = @"savedCategories.txt";
        public List<Category> categories = new List<Category>();


        public void SavePodcastList(List<Podcast> podcastList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podcastList.GetType());
            using (FileStream outFile = new FileStream(fileOfPodcasts, FileMode.Create,
                FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, podcastList);
            }
        }

        public List<Podcast> ReturnPodcasts()
        {
            List<Podcast> listOfPodcastsToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            using (FileStream inFile = new FileStream(fileOfPodcasts, FileMode.Open,
                FileAccess.Read))
            {
                listOfPodcastsToBeReturned = (List<Podcast>)xmlSerializer.Deserialize(inFile);
            }
            return listOfPodcastsToBeReturned;
        }

        public void SaveCategoryList(List<Category> categoryList)
        {
            using (StreamWriter sw = File.AppendText(savedCategories))
            {
                sw.WriteLine(categoryList);
            }
            //    XmlSerializer xmlSerializer = new XmlSerializer(categoryList.GetType());
            //    using (FileStream outFile = new FileStream(savedCategories, FileMode.Create,
            //        FileAccess.Write))
            //    {
            //        xmlSerializer.Serialize(outFile, categoryList);
            //    }
        }

        public List<Category> ReturnCategories()
        {

            List<Category> listOfCategoriesToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
            using (FileStream inFile = new FileStream(savedCategories, FileMode.Open,
                FileAccess.Read))
            {
                listOfCategoriesToBeReturned = (List<Category>)xmlSerializer.Deserialize(inFile);
            }
            return listOfCategoriesToBeReturned;

            //    using (StreamReader sr = new StreamReader(savedCategories))
            //    {
            //        categories line;
            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            categories.Add(line);
            //        }
            //    }
            //}
            //return categories;
        }
    }
}
