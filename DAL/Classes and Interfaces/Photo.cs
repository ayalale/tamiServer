namespace ProjectChanuka.Classes_and_Interfaces
{
    public class Photo:IPhoto
    {
        public string Get()
        {
            return "hear photoes";
        }
        public void Put(string str)
        {
            Console.WriteLine("description " + str);
        }

        public bool Delete()
        {
            return true;
        }
        public string Post()
        {
            return "the photo for you";
        }
    
    }
}
