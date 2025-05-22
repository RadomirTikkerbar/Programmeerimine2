namespace KooliProjekt.BlazorApp
{
    public class Result
    {
        public Dictionary<string, List<string>> Errors { get; set; }

        public Result()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public bool HasError
        {
            get
            {
                return (Errors.Count > 0);
            }
        }

        public void AddError(string property, string error)
        {
            if (!Errors.ContainsKey(property))
            {
                Errors.Add(property, new List<string>());
            }

            Errors[property].Add(error);
        }
    }
}