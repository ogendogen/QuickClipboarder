using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Models;
using Types;
using Type = Types.Type;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;

namespace QuickClipboarder
{
    public class EventValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Event target = (value as BindingGroup).Items[0] as Event;
            
            switch (target.Type)
            {
                case Type.File:
                    if (!File.Exists(target.Source))
                    {
                        return new ValidationResult(false, "File not exists");
                    }
                    break;

                case Type.Image:
                    if (!File.Exists(target.Source))
                    {
                        return new ValidationResult(false, "Image not exists");
                    }
                    break;
                    // todo: check if it is an image

                case Type.Url:
                    Uri uriResult;
                    bool result = Uri.TryCreate(target.Source, UriKind.Absolute, out uriResult)
                        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                    if (!result)
                    {
                        return new ValidationResult(false, "Invalid URL");
                    }
                    break;
            }

            if (target.Action == Types.Action.Open && target.Type == Type.Text)
            {
                return new ValidationResult(false, "You can't open text type!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
