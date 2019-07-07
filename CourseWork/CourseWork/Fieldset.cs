using AngleSharp.Html.Dom;
using System;

namespace CourseWork
{
    public class Fieldset
    {
        public Fieldset(IHtmlFieldSetElement element)
        {
                Type = GetType(element);
                Date = GetDate(element);
                Time = GetTime(element);
                Image = GetImageSource(element);
        }

        private string GetType(IHtmlFieldSetElement element)
        {
            string content = element.TextContent;
            string[] arr = content.Split(new string[] { "  " }, StringSplitOptions.None);

            if (arr[1].Length == 18)
                return "Image";
            return "Video";
        }

        private string GetDate(IHtmlFieldSetElement element)
        {
            string content = element.TextContent;
            string[] arr = content.Split(new string[] { "  " }, StringSplitOptions.None);
            string dateAndTime = arr[1].Substring(arr[1].Length - 18, 18);
            return dateAndTime.Substring(0, 10);
        }

        private string GetTime(IHtmlFieldSetElement element)
        {
            string content = element.TextContent;
            string[] arr = content.Split(new string[] { "  " }, StringSplitOptions.None);
            string dateAndTime = arr[1].Substring(arr[1].Length - 18, 18);
            return dateAndTime.Substring(10);
        }

        private string GetImageSource(IHtmlFieldSetElement element)
        {
            string source = ((IHtmlImageElement)(element.LastElementChild.FirstElementChild)).Source;
            return "html/" + source.Substring(9);
        }

        public string Date { get; private set; }
        public string Time { get; private set; }
        public string Type { get; private set; }
        public string Image { get; private set; }

    }
}
