using Really.Learn;
using System;
using Xamarin.Forms;

namespace Really
{
	public partial class MainPage : ContentPage
	{
        
        Lesson lesson;
        int i = 0;
        public MainPage()
		{
			InitializeComponent();
            lesson = Lesson.Init(Helpers.Helper.GetResourceText("lesson17.txt"));
            ShowCurrentSentence();
        }

        private void ShowCurrentSentence()
        {
            ShowSentence(i);
        }
        

        private void ShowSentence(int i)
        {
            labCh.Text = lesson.Sentences[i].Chinese;
            labEn.Text = lesson.Sentences[i].English;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            

        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            i++;
            i = i % lesson.Sentences.Count;
            ShowCurrentSentence();
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {
            ReallShared.AudioPlay.Play("yu.mp3");
        }

        private void btnPrev_Clicked(object sender, EventArgs e)
        {
            i--;
            if (i<0) i= lesson.Sentences.Count-1;
            ShowCurrentSentence();
        }
    }
}
