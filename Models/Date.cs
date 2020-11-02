namespace Models
{
    public abstract class Date
    {
        //A virtual method that returns a string
        public virtual string GetDateInfo(string url, Episode episode)
        {
            string stringToBeReturned = "This method gets overridden by a sub-class to display the date an episode was published.";
            return stringToBeReturned;
        }
    }
}
