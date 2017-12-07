﻿using ReallyLearn.Learn;
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
        string LessonFile = "lesson17.txt";
        public MainPage()
        {
            InitializeComponent();
            this.Player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            this.Player.Load(Helpers.Helper.GetResourceStream($"{this.LessonFile}.mp3"));
            labDuration.Text = this.Player.Duration.ToString();
            Lesson = Lesson.Init(Helpers.Helper.GetResourceText(this.LessonFile));
            ShowCurrentSentence();
        }

        private void ShowCurrentSentence()
        {
            ShowSentence(i);
        }


        private void ShowSentence(int i)
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
            Player.Seek(slider.Value);
            Player.Play();
        }

        private void btnPrev_Clicked(object sender, EventArgs e)
        {
            i--;
            if (i < 0) i = Lesson.Sentences.Count - 1;
            ShowCurrentSentence();
        }
    }
}