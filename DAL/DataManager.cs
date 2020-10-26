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
        protected string savedCategories = @"savedCategories.xml";
        public List<string> categories = new List<string>();


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
        //    using (StreamWriter sw = File.AppendText(savedCategories))
        //    {
        //        sw.WriteLine(categoryList);
        //    }
            XmlSerializer xmlSerializer = new XmlSerializer(categoryList.GetType());
            using (FileStream outFile = new FileStream(savedCategories, FileMode.Create,
                FileAccess.Write))
            {
               // if(File.Exists(savedCategories))
                xmlSerializer.Serialize(outFile, categoryList);
            }
        }

        public List<Category> ReturnCategories()
        {
            //categories.Clear();
            //if (File.Exists(savedCategories) == true)
            //{
            //    using (StreamReader sr = new StreamReader(savedCategories))
            //    {
            //        string line;
            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            categories.Add(line);
            //        }
            //    }
            //}
            //return categories;
            List<Category> listOfCategoriesToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>));
            using (FileStream inFile = new FileStream(savedCategories, FileMode.Open,
                FileAccess.Read))
            {
                listOfCategoriesToBeReturned = (List<Category>)xmlSerializer.Deserialize(inFile);
            }
            return listOfCategoriesToBeReturned;

        }
    }
}
