using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReallyLearn.Learn
{
    class LessonTxtParser1
    {
        private static LessonTxtParser1 _Instance;
        public static LessonTxtParser1 Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LessonTxtParser1();
                }
                return _Instance;
            }
        }

        public Lesson Parse(string txt)
        {
            Lesson lesson = new Lesson();
            string pattern = @"\*[\s\S]*?#0#0";
            MatchCollection mc =  Regex.Matches(txt, pattern);
            lesson.Sentences = new List<Sentence>();
            foreach (Match m in mc)
            {
                lesson.Sentences.Add(ParseSentence(m.Value));
            }
            return lesson;
        }

        private Sentence ParseSentence(string sentence)
        {
            string[] senArr = sentence.Split('#');
            Sentence sen = new Sentence();
            sen.English = senArr[0];
            sen.Chinese = senArr[1];
            sen.VocSt = float.Parse(senArr[senArr.Length - 4]);
            sen.VocEd = float.Parse(senArr[senArr.Length - 3]);
            return sen;
        }
    }
}
