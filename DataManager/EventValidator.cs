using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Models;
using Types;
using Type = Types.Type;

namespace DataManager
{
    public static class EventValidator
    {
        public static List<(bool result, string errorMessage)> ValidateAll(List<Event> targets)
        {
            List<(bool result, string errorMessage)> resultsReport = new List<(bool result, string errorMessage)>();
            
            bool result;
            string errorMessage;

            foreach (var target in targets)
            {
                result = Validate(target, out errorMessage);
                resultsReport.Add((result, errorMessage));
            }

            return resultsReport;
        }

        public static bool Validate(Event target, out string errorMessage)
        {
            bool ret = true;
            errorMessage = "";

            ValidateType(target, ref errorMessage, ref ret);

            if (!ret)
            {
                return false;
            }

            ValidateAction(target, ref errorMessage, ref ret);

            return ret;
        }

        private static void ValidateAction(Event target, ref string errorMessage, ref bool ret)
        {
            if (target.Action == Types.Action.Open && target.Type == Type.Text)
            {
                ret = false;
                errorMessage = "Unable to open text type";
            }
        }

        private static void ValidateType(Event target, ref string errorMessage, ref bool ret)
        {
            switch (target.Type)
            {
                case Type.File:
                    ret = File.Exists(target.Source);
                    if (!ret)
                    {
                        errorMessage = "File not exists";
                    }
                    break;

                case Type.Image:
                    ret = File.Exists(target.Source);
                    if (!ret)
                    {
                        errorMessage = "Image not exists";
                    }
                    break;
                // todo: check if it is an image

                case Type.Url:
                    Uri uriResult;
                    ret = Uri.TryCreate(target.Source, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (!ret)
                    {
                        errorMessage = "Invalid URL";
                    }
                    break;
            }
        }
    }
}
