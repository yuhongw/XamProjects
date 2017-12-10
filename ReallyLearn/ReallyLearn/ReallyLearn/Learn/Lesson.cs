using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReallyLearn.Learn
{
    class Lesson
    {
        public string Name { get; set; }
        public List<Sentence> Sentences { get; set; }

        //public static Lesson Init(string text)
        //{
        //    /*
        //    Lesson lesson = new Lesson();
        //    lesson.Sentences = new List<Sentence>();
        //    List<string> textList = 
        //        text.Split(new string[] { "\r\n" },StringSplitOptions.RemoveEmptyEntries)
        //        .ToList();
        //    string ch = "";
        //    string en = "";
        //    for (int i = 0; i < textList.Count; i++)
        //    {
        //        if (i % 2 == 0)
        //            ch = textList[i];
        //        else
        //        {
        //            en = textList[i];
        //            lesson.Sentences.Add(new Sentence { Chinese = ch, English = en });
        //        }
        //    }
        //    return lesson;
        //    */
            
        //}
        
    }
}
