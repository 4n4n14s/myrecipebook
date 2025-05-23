﻿namespace MyRecipeBook.Communcation.Response
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(string error)
        {
            Errors = new List<string> { error};
        }

        public ResponseErrorJson(IList<string> errors)
        {
            Errors = errors;
        }

        public IList<string> Errors { get; set; }
    }
}
