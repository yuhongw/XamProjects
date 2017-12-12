using ReallyLearn.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ReallyLearn
{
    public partial class MainPage : ContentPage
    {

        Lesson Lesson;
        Plugin.SimpleAudioPlayer.Abstractions.ISimpleAudioPlayer Player;
        int i = 0;
        int k = 0;
        string LessonFile = "1.rtf.txt";
        string vocFile = "1.mp3";
        
        public MainPage()
        {
            InitializeComponent();
            this.Player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            this.Player.Load(Helpers.Helper.GetResourceStream(vocFile));

            Lesson =  LessonTxtParser1.Instance.Parse(Helpers.Helper.GetResourceText(this.LessonFile));
            //Lesson = Lesson.Init(Helpers.Helper.GetResourceText(this.LessonFile));
            ShowCurrentSentence();
            RepeatExec(1000, () => { k++; labTest.Text = k.ToString(); });
            
        }

        private async Task RepeatExec(int milisec,  Action actionToExecute)
        {
            while (true)
            {
                await Task.Delay(milisec);
                actionToExecute();
            }
        }

        private void ShowCurrentSentence()
        {
            labCh.Text = Lesson.Sentences[i].Chinese;
            labEn.Text = Lesson.Sentences[i].English;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {


        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            i++;
            i = i % Lesson.Sentences.Count;
            ShowCurrentSentence();
        }

        private void btnPlay_Clicked(object sender, EventArgs e)
        {

            if (Player.IsPlaying)
            {
                Player.Stop();
            }
            Player.Seek(this.Lesson.Sentences[i].VocSt);
            Player.Play();
            
        }

        private void btnPrev_Clicked(object sender, EventArgs e)
        {
            i--;
            if (i < 0) i = Lesson.Sentences.Count - 1;
            ShowCurrentSentence();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            labDuration.Text = this.Player.Duration.ToString();
            slider.Maximum = this.Player.Duration;
            
        }
    }
}
